using System;

namespace ChildCare.MonitoringSystem.Common.Helpers
{
    /// <summary>
    /// This is a slightly modified version of Fisher-Yates Shuffle algorithm.
    /// Refer: https://stackoverflow.com/a/196065/540345
    /// </summary>
    public class PseudoRandom
    {
        private int[] values;
        private Random random = new Random();
        private int maxIndex;
        private object lockObject = new object();

        /// <summary>
        /// Initializes <see cref="PseudoRandom"/> with maximum random limit. The limit is memory hungry. So, use it wisely.
        /// </summary>
        /// <param name="maxValue">The maximum value (Internally allocates an array with this size).</param>
        public PseudoRandom(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new Exception("The max value cannot be less than 0");
            }

            values = new int[maxValue];

            for (var i = 0; i < maxValue; i++)
            {
                this.values[i] = i;
            }

            maxIndex = values.Length - 1;
        }

        public int Next()
        {
            lock (lockObject)
            {
                if (maxIndex == 0)
                {
                    maxIndex = values.Length - 1;
                }

                var r = random.Next(0, maxIndex);

                this.Swap(ref values, r, maxIndex);

                return values[maxIndex--];
            }
        }

        private void Swap(ref int[] arr, int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
