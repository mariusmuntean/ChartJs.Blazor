using System.Collections.Generic;
using System.Linq;

namespace ChartJs.Blazor.ChartJS.Common.Wrappers
{
    public static class WrapperExtensions
    {
        public static IEnumerable<T> UnWrap<T>(this IEnumerable<ValueWrapper<T>> wrappers) where T : struct
        {
            return wrappers.Select(v => v.Value);
        }

        public static IEnumerable<ByteWrapper> Wrap(this IEnumerable<byte> values)
        {
            return values.Select(v => (ByteWrapper)v);
        }

        public static IEnumerable<DoubleWrapper> Wrap(this IEnumerable<double> values)
        {
            return values.Select(v => (DoubleWrapper)v);
        }

        public static IEnumerable<FloatWrapper> Wrap(this IEnumerable<float> values)
        {
            return values.Select(v => (FloatWrapper)v);
        }

        public static IEnumerable<Int16Wrapper> Wrap(this IEnumerable<short> values)
        {
            return values.Select(v => (Int16Wrapper)v);
        }

        public static IEnumerable<Int32Wrapper> Wrap(this IEnumerable<int> values)
        {
            return values.Select(v => (Int32Wrapper)v);
        }

        public static IEnumerable<Int64Wrapper> Wrap(this IEnumerable<long> values)
        {
            return values.Select(v => (Int64Wrapper)v);
        }
    }
}
