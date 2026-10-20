using System;
using System.Threading;

namespace KT_22_Events
{
    public class CountdownTimer
    {
        public event EventHandler<int>? Tick;
        public event EventHandler? Finished;

        public void Start(int seconds)
        {
            for (int i = seconds; i >= 0; i--)
            {
                Tick?.Invoke(this, i);

                if (i == 0)
                {
                    Finished?.Invoke(this, EventArgs.Empty);
                    break;
                }

                Thread.Sleep(1000);
            }
        }
    }
}
