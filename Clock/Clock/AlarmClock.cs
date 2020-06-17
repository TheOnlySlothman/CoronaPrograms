using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace ClockProgram
{
    class AlarmClock : BaseClock
    {
        readonly string message;
        protected DateTime alarmTime;
        TimeSpan time;

        SoundPlayer player = new SoundPlayer();
        public AlarmClock(System.Windows.Controls.Label label, string message) : base(label)
        {
            this.label = label;
            this.message = message;
            InitializeDispatcherTimer();
            InitializeSound();
        }

        private void InitializeSound()
        {
            try
            {
                var curDir = Directory.GetCurrentDirectory();
                // Assign the selected file's path to 
                // the SoundPlayer object.  
                player.SoundLocation = $@"{curDir}\sounds\oof.wav";

                // Load the .wav file.
                player.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public override void InitializeDispatcherTimer()
        {
            base.InitializeDispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        public override void DispatcherTimer(object sender, EventArgs e)
        {
            if (alarmTime < DateTime.Now)
            {
                MessageBox.Show(message);
                player.PlaySync();
                dispatcherTimer.Stop();
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

        public void AddAlarm(int[] values)
        {
            time = new TimeSpan(values[0], values[1], values[2]);
            SetAlarm();
        }

        public void Add(TimeSpan ts)
        {
            alarmTime += ts;
            UpdateVisuals(alarmTime.ToString(format));
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
    }
}
