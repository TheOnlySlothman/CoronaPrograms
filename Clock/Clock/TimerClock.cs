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
        TimeSpan ts;
        TimeSpan TimerAmount { get { return ts - stopwatch.Elapsed; } }
        readonly Stopwatch stopwatch;
        public TimerClock(System.Windows.Controls.Label label)
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
            UpdateVisuals(TimerAmount);

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
            UpdateVisuals(TimerAmount);
        }

        public void Subtract(int[] values)
        {
            ts -= new TimeSpan(values[0], values[1], values[2]);
            if (ts <= new TimeSpan(0))
            {
                ts = new TimeSpan(0);
                stopwatch.Reset();
            }
            UpdateVisuals(TimerAmount);
        }

        public void PauseOrResume()
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                dispatcherTimer.Stop();
            }
            else
            {
                stopwatch.Start();
                dispatcherTimer.Start();
            }
        }
    }
}
