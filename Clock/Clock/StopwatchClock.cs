using ClockProgram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ClockProgram
{
    class StopwatchClock : BaseClock
    {
        protected Stopwatch Watch { get; } = new Stopwatch();
        public bool Running { get => Watch.IsRunning; }

        // public DateTime TimerEndTime = new DateTime();

        public StopwatchClock(System.Windows.Controls.Label label) : base(label)
        {
            this.label = label;
            InitializeDispatcherTimer();
        }

        public override void InitializeDispatcherTimer()
        {
            base.InitializeDispatcherTimer();
        }

        public override void DispatcherTimer(object sender, EventArgs e)
        {
            TimeSpan ts = Watch.Elapsed;

            UpdateVisuals(string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10));
        }

        public void Start()
        {
            dispatcherTimer.Start();
            Watch.Start();
        }

        public void Stop()
        {
            dispatcherTimer.Stop();
            Watch.Stop();
        }

        public void Reset()
        {
            Watch.Reset();
        }

        public TimeSpan GetTime()
        {
            return Watch.Elapsed;
        }
    }
}
