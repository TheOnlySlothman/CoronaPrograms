using ClockProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockProgram
{
    class TimerClock : BaseClock
    {
        DateTime TimerEndTime;
        public TimerClock(System.Windows.Controls.Label label)
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
            TimeSpan ts = (TimerEndTime - DateTime.Now);
            label.Content = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            if (TimerEndTime < DateTime.Now)
            {
                dispatcherTimer.Stop();
                TimerEndTime = DateTime.MinValue;
                label.Content = "00:00:00.00";
            }
        }

        public void Add(int[] values)
        {
            TimeSpan ts = new TimeSpan(values[0], values[1], values[2]);

            if (TimerEndTime == DateTime.MinValue)
            {
                TimerEndTime = DateTime.Now;
                dispatcherTimer.Start();
            }
            TimerEndTime += ts;
        }

        public void Subtract(int[] values)
        {
            TimeSpan ts = new TimeSpan(values[0], values[1], values[2]);

            if (TimerEndTime == DateTime.MinValue)
            {
                return;
            }
            TimerEndTime -= ts;
        }
    }
}
