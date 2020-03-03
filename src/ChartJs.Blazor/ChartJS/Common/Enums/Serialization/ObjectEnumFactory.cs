using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common.Enums.Serialization
{
    internal class ObjectEnumFactory
    {
        private static readonly ConcurrentDictionary<Type, ObjectEnumFactory> s_factorySingletons = new ConcurrentDictionary<Type, ObjectEnumFactory>();
        
        private readonly Lazy<Dictionary<Type, ConstructorInfo>> _constructorCache;
        protected Dictionary<Type, ConstructorInfo> ConstructorCache => _constructorCache.Value;

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
            _constructorCache = new Lazy<Dictionary<Type, ConstructorInfo>>(CreateConstructorDictionary);
        }

        public ObjectEnum Create(object value)
        {
            if (ConstructorCache.TryGetValue(value.GetType(), out ConstructorInfo constructor))
            {
                return (ObjectEnum)constructor.Invoke(new[] { value });
            }
            else
            {
                throw new NotSupportedException($"The object enum '{_enumType.FullName}' doesn't have a constructor which takes a single " +
                                                $"argument of type '{value.GetType().FullName}'.");
            }
        }

        private Dictionary<Type, ConstructorInfo> CreateConstructorDictionary()
        {
            var dict = new Dictionary<Type, ConstructorInfo>();
            ConstructorInfo[] constructors = _enumType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ConstructorInfo constructor in constructors)
            {
                ParameterInfo[] constructorParams = constructor.GetParameters();
                if (constructorParams.Length != 1)
                {
                    continue;
                }

                Type paramType = constructorParams[0].ParameterType;
                if (paramType != typeof(object))
                {
                    dict.Add(paramType, constructor);
                }
            }

            return dict;
        }
    }
}
