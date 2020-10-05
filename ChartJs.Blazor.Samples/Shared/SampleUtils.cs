
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChartJs.Blazor.Samples.Shared
{
    public static class SampleUtils
    {
        private static readonly Random _rng = new Random();

        public static class ChartColors
        {
            public static IReadOnlyList<string> All { get; } = new string[7]
            {
                Red, Orange, Yellow, Green, Blue, Purple, Grey
            };

            public const string Red = "rgb(255, 99, 132)";
            public const string Orange = "rgb(255, 159, 64)";
            public const string Yellow = "rgb(255, 205, 86)";
            public const string Green = "rgb(75, 192, 192)";
            public const string Blue = "rgb(54, 162, 235)";
            public const string Purple = "rgb(153, 102, 255)";
            public const string Grey = "rgb(201, 203, 207";
        }

        public static IReadOnlyList<string> Months { get; } = new ReadOnlyCollection<string>(new[]
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        });

        private static int RandomScalingFactorThreadUnsafe() => _rng.Next(-100, 100);

        public static int RandomScalingFactor()
        {
            lock (_rng)
            {
                return RandomScalingFactorThreadUnsafe();
            }
        }

        public static IEnumerable<int> RandomScalingFactor(int count)
        {
            int[] factors = new int[count];
            lock (_rng)
            {
                for (int i = 0; i < count; i++)
                {
                    factors[i] = RandomScalingFactorThreadUnsafe();
                }
            }

            return factors;
        }
    }
}
