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
        //private readonly TimerClock timerClock;
        private AlarmClock alarmClock;
        readonly Regex timeRegex = new Regex(@"([0-9]?[0-9])([\W\D][0-5]?[0-9]|[\W\D]60){2}$");
        private readonly char[] splitChArr = { ',', ' ', '.', ';', ':', '-' };
        readonly List<CheckBox> checkBoxes = new List<CheckBox>();
        public MainWindow()
        {
            InitializeComponent();
            _ = new Clock(ClockTimeLabel);

            stopwatchClock = new StopwatchClock(StopwatchTimeLabel, LapLabel);
            //AlarmTimeTextBox.Text = string.Format("{0:00}:{1:00}:{2:00}",
            //        DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            _ = new DigitalClock(new UIElementCollection[] { DigitalHoursTens.Children, DigitalHoursOnes.Children, DigitalMinutesTens.Children, DigitalMinutesOnes.Children, DigitalSecondsTens.Children, DigitalSecondsOnes.Children });

            foreach (CheckBox checkBox in WeekDayGrid.Children)
            {
                checkBoxes.Add(checkBox);
            }

            InitializeDispatcherTimer();
        }



        #region Stopwatch
        /// <summary>
        /// starts or stops the StopwatchClock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// creates a lap time or resets the StopwatchClock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Split_ResetButton_Click(object sender, RoutedEventArgs e)
        {
            //reset
            if (!stopwatchClock.Running)
            {
                stopwatchClock.Reset();
                StopwatchTimeLabel.Content = "";
                LapLabel.Content = "";
                StopWatchLapListBox.Items.Clear();
            }
            //add the lap time
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
        #endregion

        #region Timer
        readonly List<TimerClock> timerList = new List<TimerClock>();
        /// <summary>
        /// add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerAddButton_Click(object sender, RoutedEventArgs e)
        {
            //if text matches an amount of time
            if (timeRegex.IsMatch(TimerAmount.Text))
            {
                //take input
                string[] s = timeRegex.Match(TimerAmount.Text).Value.Split(splitChArr, 3);
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }

                //create timespan with input
                TimeSpan ts = new TimeSpan(values[0], values[1], values[2]);

                //if a timer is selected add the TimeSpan to it
                if (TimerListBox.SelectedIndex >= 0)
                {
                    timerList[TimerListBox.SelectedIndex].Add(ts);
                    TimerListBox.Items[TimerListBox.SelectedIndex] = timerList[TimerListBox.SelectedIndex].TimerFormat();
                }
                //else create a new timer with the TimeSpan
                else if (TimerListBox.SelectedIndex == -1)
                {
                    TimerClock temp = new TimerClock(ts);
                    timerList.Add(temp);

                    TimerListBox.Items.Add(temp.TimerFormat());
                }
            }
        }

        private void TimerSubtractButton_Click(object sender, RoutedEventArgs e)
        {
            //if text matches an amount of time
            if (timeRegex.IsMatch(TimerAmount.Text))
            {
                //take input
                string[] s = timeRegex.Match(TimerAmount.Text).Value.Split(splitChArr, 3);
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }

                //create timespan with input
                TimeSpan ts = new TimeSpan(values[0], values[1], values[2]);

                //if a timer is selected subtract the TimeSpan from it
                if (TimerListBox.SelectedIndex >= 0)
                {
                    timerList[TimerListBox.SelectedIndex].Subtract(ts);
                    TimerListBox.Items[TimerListBox.SelectedIndex] = timerList[TimerListBox.SelectedIndex].TimerFormat();
                }
                //UpdateTimers();
            }
        }

        private void TimerPauseButton_Click(object sender, RoutedEventArgs e)
        {
            //pause or resume the selected TimerClock
            if (TimerListBox.SelectedIndex >= 0)
            {
                timerList[TimerListBox.SelectedIndex].PauseOrResume();
                TimerListBox.Items[TimerListBox.SelectedIndex] = timerList[TimerListBox.SelectedIndex].TimerFormat();
                //UpdateTimers();
            }
        }

        private void TimerAddTimerButton_Click(object sender, RoutedEventArgs e)
        {
            //if text matches an amount of time
            if (timeRegex.IsMatch(TimerAmount.Text))
            {
                string[] s = timeRegex.Match(TimerAmount.Text).Value.Split(splitChArr, 3);
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }

                //create timespan with input
                TimeSpan ts = new TimeSpan(values[0], values[1], values[2]);

                //create a new timer with the TimeSpan and add it to the ListBox
                TimerClock temp = new TimerClock(ts);
                timerList.Add(temp);

                TimerListBox.Items.Add(temp.TimerFormat());

            }
        }

        private void TimerRemoveTimerButton_Click(object sender, RoutedEventArgs e)
        {
            //if a TimerClock is selected stop it and remove it
            if (TimerListBox.SelectedIndex > -1)
            {
                timerList[TimerListBox.SelectedIndex].stopwatch.Stop();
                timerList.RemoveAt(TimerListBox.SelectedIndex);
                TimerListBox.Items.RemoveAt(TimerListBox.SelectedIndex);
            }
        }

        //takes all running and nonselected timers and updates the visuals
        public void UpdateTimers()
        {
            for (int i = 0; i < timerList.Count; i++)
            {
                if (timerList[i].stopwatch.IsRunning && TimerListBox.SelectedIndex != i)
                {
                    TimerListBox.Items[i] = timerList[i].TimerFormat();
                }
            }
        }
        #endregion

        #region Alarm
        readonly List<AlarmClock> alarmList = new List<AlarmClock>();
        readonly List<DayOfWeek> days = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };

        private void AlarmSetButton_Click(object sender, RoutedEventArgs e)
        {
            //if text matches a point in time
            if (timeRegex.IsMatch(AlarmTimeTextBox.Text))
            {
                string[] s = timeRegex.Match(AlarmTimeTextBox.Text).Value.Split(splitChArr, 3);
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }

                List<DayOfWeek> repeatDays = new List<DayOfWeek>();

                //take the selected days and add them to a new array
                for (int i = 0; i < checkBoxes.Count; i++)
                {
                    if (checkBoxes[i].IsChecked == true)
                    {
                        repeatDays.Add(days[i]);
                    }
                }
                //create new AlarmClock with the selected time and days
                alarmClock = new AlarmClock(new TimeSpan(values[0], values[1], values[2]), repeatDays);
                if (AlarmMessageTextBox.Text != null)
                {
                    alarmClock.AddMessage(AlarmMessageTextBox.Text);
                }

                //add the new AlarmClock to the alarmList and AlarmDataGrid
                alarmList.Add(alarmClock);
                AlarmDataGrid.Items.Add(alarmClock.ToObject());
            }
        }

        private void On_Off_Click(object sender, RoutedEventArgs e)
        {
            foreach (AlarmClock item in alarmList)
            {
                if (alarmList.IndexOf(item) == AlarmDataGrid.SelectedIndex)
                {
                    item.OnOrOff();
                    AlarmDataGrid.Items[AlarmDataGrid.SelectedIndex] = item.ToObject();
                }

            }
        }


        private void AlarmEditButton_Click(object sender, RoutedEventArgs e)
        {
            //if text matches a point in time
            if (timeRegex.IsMatch(AlarmTimeTextBox.Text))
            {
                string[] s = timeRegex.Match(AlarmTimeTextBox.Text).Value.Split(splitChArr, 3);
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }
                List<DayOfWeek> repeatDays = new List<DayOfWeek>();
                //take the selected days and add them to a new array
                for (int i = 0; i < checkBoxes.Count; i++)
                {
                    if (checkBoxes[i].IsChecked == true)
                    {
                        repeatDays.Add(days[i]);
                    }
                }
                //create new AlarmClock with the selected time and days
                alarmClock = new AlarmClock(new TimeSpan(values[0], values[1], values[2]), repeatDays);
                if (AlarmMessageTextBox.Text != null)
                {
                    alarmClock.AddMessage(AlarmMessageTextBox.Text);
                }

                //if an item is selected, stop the previous alarm and put the new alarm in it's place
                if (AlarmDataGrid.SelectedIndex >= 0)
                {
                    alarmList[AlarmDataGrid.SelectedIndex].IsRunning = false;
                    alarmList[AlarmDataGrid.SelectedIndex] = alarmClock;
                    AlarmDataGrid.Items[AlarmDataGrid.SelectedIndex] = alarmClock.ToObject();
                }

            }
        }

        private void AlarmRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AlarmDataGrid.SelectedItem != null)
            {
                alarmList[AlarmDataGrid.SelectedIndex].IsRunning = false;
                alarmList.RemoveAt(AlarmDataGrid.SelectedIndex);
                AlarmDataGrid.Items.RemoveAt(AlarmDataGrid.SelectedIndex);
            }
        }
        #endregion


        protected DispatcherTimer dispatcherTimer;


        public void InitializeDispatcherTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer);
            dispatcherTimer.Start();
        }
        public void DispatcherTimer(object sender, EventArgs e)
        {
            UpdateTimers();
        }
    }
}
