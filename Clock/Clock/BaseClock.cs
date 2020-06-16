using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ClockProgram
{
    abstract class BaseClock
    {
        protected System.Windows.Controls.Label label;
        protected DispatcherTimer dispatcherTimer;
        protected string format = ClockFormating.hours24;

        public virtual void InitializeDispatcherTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer);
        }

        public abstract void DispatcherTimer(object sender, EventArgs e);

        public void UpdateVisuals(string output) => label.Content = output;
    }
}
