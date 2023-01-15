using System;

namespace CustomEvent
{
    class Counter
    {
        public event EventHandler ThresholdReached;
        private readonly int threshold;
        private int total;

        public Counter(int threshold)
        {
            this.threshold = threshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                // Same as the shorter version.
                //if (ThresholdReached != null) ThresholdReached(total, EventArgs.Empty);
                ThresholdReached?.Invoke(total, EventArgs.Empty);
            }
        }
    }
}