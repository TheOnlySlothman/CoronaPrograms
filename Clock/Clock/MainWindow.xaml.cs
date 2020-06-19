using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClockProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StopwatchClock stopwatchClock;
        private readonly TimerClock timerClock;
        private AlarmClock alarmClock;
        readonly Regex timeRegex = new Regex(@"([0-9]?[0-9])([\W\D][0-5]?[0-9]|[\W\D]60){2}$");
        private readonly char[] splitChArr = { ',', ' ', '.', ';', ':', '-' };
        public MainWindow()
        {
            InitializeComponent();
            _ = new Clock(ClockTimeLabel);

            stopwatchClock = new StopwatchClock(StopwatchTimeLabel, LapLabel);

            timerClock = new TimerClock(TimerTimeLabel);

            //alarmClock = new AlarmClock(AlarmTimeLabel, AlarmMessageTextBox);

            AlarmTimeTextBox.Text = string.Format("{0:00}:{1:00}:{2:00}",
                    DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        }

        


        private void Start_StopButton_Click(object sender, RoutedEventArgs e)
        {

            if (!stopwatchClock.Running)
            {
                stopwatchClock.Start();
            }
            else
            {
                stopwatchClock.Stop();
            }
        }

        private void Split_ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (!stopwatchClock.Running)
            {
                stopwatchClock.Reset();
                StopwatchTimeLabel.Content = "";
                LapLabel.Content = "";
                StopWatchLapListBox.Items.Clear();
            }
            else
            {
                TimeSpan ts = stopwatchClock.GetLapTime();
                StopWatchLapListBox.Items.Add(
                    string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10)
                );

                stopwatchClock.CreateLap();
            }
        }

        private void TimerAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (timeRegex.IsMatch(TimerAmount.Text))
            {
                string[] s = timeRegex.Match(TimerAmount.Text).Value.Split(splitChArr, 3);
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }
                timerClock.Add(values);
            }
        }

        private void TimerSubtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (timeRegex.IsMatch(TimerAmount.Text))
            {
                string[] s = timeRegex.Match(TimerAmount.Text).Value.Split(splitChArr, 3);
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }
                timerClock.Subtract(values);
            }
        }

        readonly List<AlarmClock> alarmList = new List<AlarmClock>();

        private void AlarmSetButton_Click(object sender, RoutedEventArgs e)
        {
            if (timeRegex.IsMatch(AlarmTimeTextBox.Text))
            {

                string[] s = timeRegex.Match(AlarmTimeTextBox.Text).Value.Split(splitChArr, 3);
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }
                alarmClock = new AlarmClock(new TimeSpan(values[0], values[1], values[2]));
                if (AlarmMessageTextBox.Text != null)
                {
                    alarmClock.AddMessage(AlarmMessageTextBox.Text);
                }

                alarmList.Add(alarmClock);
                UpdateAlarms();
            }
        }

        private void SnoozeButton_Click(object sender, RoutedEventArgs e)
        {
            alarmClock.Snooze();
        }

        private void On_Off_Click(object sender, RoutedEventArgs e)
        {
            foreach (AlarmClock item in alarmList)
            {
                if (alarmList.IndexOf(item) == AlarmDataGrid.SelectedIndex)
                {
                    item.OnOrOff();
                }

            }
                UpdateAlarms();
        }

        public void UpdateAlarms()
        {
            AlarmDataGrid.Items.Clear();
            foreach (var alarm in alarmList)
            {
                AlarmDataGrid.Items.Add(new
                {
                    Time = string.Format("{0:00}:{1:00}:{2:00}",
                    alarm.alarmTime.Hour, alarm.alarmTime.Minute, alarm.alarmTime.Second),

                    Enabled = alarm.IsRunning.ToString()
                });
            }
        }

        private void TimerPauseButton_Click(object sender, RoutedEventArgs e)
        {
            timerClock.PauseOrResume();
        }
    }
}
