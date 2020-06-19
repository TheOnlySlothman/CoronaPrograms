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
        protected Stopwatch Watch = new Stopwatch();
        public TimeSpan lastLap;
        readonly System.Windows.Controls.Label lapLabel;
        public bool Running { get => Watch.IsRunning; }

        // public DateTime TimerEndTime = new DateTime();

        public StopwatchClock(System.Windows.Controls.Label label, System.Windows.Controls.Label labLabel)
        {
            this.label = label;
            this.lapLabel = labLabel;
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

            ts -= lastLap;

            lapLabel.Content = (string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
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
            lastLap = new TimeSpan(0);
        }

        public void Reset()
        {
            Watch.Reset();
        }

        public void Restart()
        {
            Watch.Restart();
        }

        public TimeSpan GetLapTime()
        {
            return Watch.Elapsed - lastLap;
        }

        public void CreateLap()
        {
            lastLap = Watch.Elapsed;
        }
    }
}
