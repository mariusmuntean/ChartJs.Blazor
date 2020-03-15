using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common.Enums.Serialization
{
    internal class ObjectEnumFactory
    {
        private static readonly ConcurrentDictionary<Type, ObjectEnumFactory> s_factorySingletons = new ConcurrentDictionary<Type, ObjectEnumFactory>();
        
        private readonly Dictionary<Type, ConstructorInfo> _constructorCache;
        private readonly Type _enumType;

        public static ObjectEnumFactory GetFactory(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            if (!typeof(ObjectEnum).IsAssignableFrom(enumType))
                throw new ArgumentException($"The type '{enumType.FullName}' doesn't inherit from '{typeof(ObjectEnum).FullName}'");

            return s_factorySingletons.GetOrAdd(enumType, type => new ObjectEnumFactory(type));
        }

        private ObjectEnumFactory(Type enumType)
        {
            // checks omitted because the constructor is non-public
            _enumType = enumType;
            _constructorCache = CreateConstructorDictionary();
        }

        public ObjectEnum Create(object value)
        {
            Type valueType = value.GetType();
            if (_constructorCache.TryGetValue(valueType, out ConstructorInfo constructor))
            {
                return (ObjectEnum)constructor.Invoke(new[] { value });
            }

            if (IsSupportedSerializationType(valueType))
            {
                throw new NotSupportedException($"The object enum '{_enumType.FullName}' doesn't have a constructor which takes a single " +
                                                $"argument of type '{valueType.FullName}'.");
            }
            else
            {
                throw new NotSupportedException($"The type '{valueType}' isn't supported for serialization within {nameof(ObjectEnum)}.");
            }
        }

        public bool CanConvertFrom(Type contentType) => _constructorCache.ContainsKey(contentType);

        private Dictionary<Type, ConstructorInfo> CreateConstructorDictionary()
        {
            Dictionary<Type, ConstructorInfo> dict = new Dictionary<Type, ConstructorInfo>();
            ConstructorInfo[] constructors = _enumType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ConstructorInfo constructor in constructors)
            {
                ParameterInfo[] constructorParams = constructor.GetParameters();
                if (constructorParams.Length != 1)
                {
                    continue;
                }

                Type paramType = constructorParams[0].ParameterType;
                if (IsSupportedSerializationType(paramType))
                {
                    dict.Add(paramType, constructor);
                }
            }

            if (dict.Count == 0)
            {
                throw new NotSupportedException($"The {nameof(ObjectEnum)} type '{_enumType.FullName}' doesn't have any " +
                                                $"suitable constructors for deserialization.");
            }

            return dict;
        }

        private bool IsSupportedSerializationType(Type type) => ObjectEnum.SupportedSerializationTypes.Contains(type);
    }
}
