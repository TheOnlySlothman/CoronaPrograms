using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClockProgram
{
    class Clock : BaseClock
    {
        public Clock(System.Windows.Controls.Label label)
        {
            this.label = label;
            InitializeDispatcherTimer();
        }

        public override void InitializeDispatcherTimer()
        {
            base.InitializeDispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        public override void DispatcherTimer(object sender, EventArgs e)
        {
            UpdateVisuals(DateTime.Now.ToString(format));
        }
    }
}
