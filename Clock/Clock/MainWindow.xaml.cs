using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string timeType = "HH:mm:ss";
        private readonly Stopwatch stopWatch = new Stopwatch();

        private readonly DispatcherTimer dispatcherTimerSeconds;
        private readonly DispatcherTimer dispatcherTimerTicks;
        public MainWindow()
        {
            InitializeComponent();

            ClockTimeLabel.Content = DateTime.Now.ToString(timeType);


            dispatcherTimerSeconds = new DispatcherTimer();
            dispatcherTimerSeconds.Tick += new EventHandler(DispatcherTimer_Seconds);
            dispatcherTimerSeconds.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimerSeconds.Start();

            dispatcherTimerTicks = new DispatcherTimer();
            dispatcherTimerTicks.Tick += new EventHandler(DispatcherTimer_Ticks);



        }


        private void DispatcherTimer_Seconds(object sender, EventArgs e)
        {
            // Updating the Label which displays the current second
            ClockTimeLabel.Content = DateTime.Now.ToString(timeType);

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        private void DispatcherTimer_Ticks(object sender, EventArgs e)
        {
            TimeSpan ts = stopWatch.Elapsed;
            StopwatchTimeLabel.Content = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }


        private void Start_StopButton_Click(object sender, RoutedEventArgs e)
        {

            if (!stopWatch.IsRunning)
            {
                stopWatch.Start();
                dispatcherTimerTicks.Start();
            }
            else
            {
                stopWatch.Stop();
                dispatcherTimerTicks.Stop();
            }
        }

        private void Split_ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (!stopWatch.IsRunning)
            {
                stopWatch.Reset();
                StopwatchTimeLabel.Content = "";
                StopWatchTimes.Items.Clear();
            }
            else
            {
                TimeSpan ts = stopWatch.Elapsed;

                StopWatchTimes.Items.Add(new
                {
                    Time = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10)
                });
            }
        }

        private void TimerAddButton_Click(object sender, RoutedEventArgs e)
        {
            Regex rx = new Regex("\b([0-9][0-9])(:[0-5][0-9]|:60){2}\b");
            if (rx.IsMatch(TimerAmount.Text))
            {

            }
            
        }

        ///start/stop
        ///split/reset
    }
}
