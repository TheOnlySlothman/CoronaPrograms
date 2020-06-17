using ClockProgram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockProgram
{
    class TimerClock : BaseClock
    {
        //protected DateTime timerEndTime;
        TimeSpan ts;
        readonly Stopwatch stopwatch;
        public TimerClock(System.Windows.Controls.Label label) : base(label)
        {
            this.label = label;
            InitializeDispatcherTimer();
            stopwatch = new Stopwatch();
        }

        public override void InitializeDispatcherTimer()
        {
            base.InitializeDispatcherTimer();
        }

        public override void DispatcherTimer(object sender, EventArgs e)
        {
            TimeSpan span = ts - stopwatch.Elapsed;
            label.Content = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            span.Hours, span.Minutes, span.Seconds,
            span.Milliseconds / 10);

            if (ts < stopwatch.Elapsed)
            {
                dispatcherTimer.Stop();
                stopwatch.Reset();
                ts = new TimeSpan(0, 0, 0);
                label.Content = "00:00:00.00";
            }
        }

        public void Add(int[] values)
        {
            ts += new TimeSpan(values[0], values[1], values[2]);
            if (!stopwatch.IsRunning)
            {
                dispatcherTimer.Start();
                stopwatch.Start();
            }
        }

        public void Subtract(int[] values)
        {
            ts -= new TimeSpan(values[0], values[1], values[2]);
        }
    }
}
