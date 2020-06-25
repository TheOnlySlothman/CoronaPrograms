using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ClockProgram
{
    class AlarmClock : BaseClock
    {
        string alarmMessage = "standard message";
        public DateTime alarmTime;
        TimeSpan time;
        TimeSpan snoozeAmount;
        readonly List<DayOfWeek> days;

        public bool IsRunning { get => dispatcherTimer.IsEnabled; set => dispatcherTimer.IsEnabled = value; }
        public AlarmClock()
        {
            InitializeDispatcherTimer();
        }

        public AlarmClock(TimeSpan timeSpan, List<DayOfWeek> days)
        {
            InitializeDispatcherTimer();
            time = timeSpan;
            this.days = days;
            SetAlarm();
        }

        public void AddMessage(string mess)
        {
            alarmMessage = mess;
        }

        public override void InitializeDispatcherTimer()
        {
            base.InitializeDispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        public override void DispatcherTimer(object sender, EventArgs e)
        {
            if (alarmTime + snoozeAmount < DateTime.Now)
            {

                if (days.Count == 0 || days.Contains(DateTime.Today.DayOfWeek))
                {

                    MessageBoxResult result = MessageBox.Show("Snooze?", alarmMessage, MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        Add(new TimeSpan(0, 1, 0));
                    }
                    else
                    {
                        snoozeAmount = new TimeSpan(0);
                        if (!days.Contains(DateTime.Today.DayOfWeek))
                        {
                            dispatcherTimer.Stop();
                        }
                        else
                        {
                            alarmTime += new TimeSpan(1, 0, 0, 0);
                        }
                    }
                }
                else
                {
                    alarmTime += new TimeSpan(1, 0, 0, 0);
                }
            }


        }

        private void SetAlarm()
        {

            alarmTime = DateTime.Today;
            Add(time);

            if (alarmTime < DateTime.Now)
            {
                Add(new TimeSpan(1, 0, 0, 0));
                return;
            }
        }

        public void AddAlarm(TimeSpan ts)
        {
            time = ts;
            SetAlarm();
        }

        public void Add(TimeSpan ts)
        {
            alarmTime += ts;
            // UpdateVisuals(alarmTime.ToString(format));
            dispatcherTimer.Start();
        }

        public void Snooze()
        {
            snoozeAmount += new TimeSpan(0, 5, 0);
            dispatcherTimer.Start();
        }

        public void OnOrOff()
        {
            if (!dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Start();
                SetAlarm();
            }
            else
            {
                dispatcherTimer.Stop();
            }
        }

        public object ToObject()
        {
            return
            new
            {
                Time = string.Format("{0:00}:{1:00}:{2:00}",
                    alarmTime.Hour, alarmTime.Minute, alarmTime.Second),

                Enabled = IsRunning.ToString(),

                Message = alarmMessage
            };
        }
    }
}
