using ClockProgram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClockProgram
{
    class TimerClock : BaseClock, IClock
    {
        TimeSpan ts;
        //TimeSpan tsMod;
        public TimeSpan TimerAmount { get { return ts - stopwatch.Elapsed; } }
        public readonly Stopwatch stopwatch;
        public TimerClock()
        {
            InitializeDispatcherTimer();
            stopwatch = new Stopwatch();
        }
        public TimerClock(TimeSpan span)
        {
            InitializeDispatcherTimer();
            stopwatch = new Stopwatch();
            Add(span);
        }

        public override void InitializeDispatcherTimer()
        {
            base.InitializeDispatcherTimer();
        }

        public override void DispatcherTimer(object sender, EventArgs e)
        {
            if (ts < stopwatch.Elapsed)
            {
                dispatcherTimer.Stop();
                stopwatch.Reset();
                MessageBox.Show(string.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds) + " Timer is up");
            }
        }




        public void Add(TimeSpan span)
        {
            ts += span;
        }

        public void Subtract(TimeSpan span)
        {
            ts -= span;
            if (ts <= new TimeSpan(0))
            {
                ts = new TimeSpan(0);
                stopwatch.Reset();
            }
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

        public string TimerFormat()
        {
            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    TimerAmount.Hours, TimerAmount.Minutes, TimerAmount.Seconds, TimerAmount.Milliseconds / 10);
        }
    }
}
