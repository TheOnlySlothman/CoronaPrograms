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
        readonly Regex timerRegex = new Regex("([0-9]?[0-9])(:[0-5]?[0-9]|:60){2}");
        public MainWindow()
        {
            InitializeComponent();

            Clock clock = new Clock(ClockTimeLabel);
            
            stopwatchClock = new StopwatchClock(StopwatchTimeLabel);

            timerClock = new TimerClock(TimerTimeLabel);

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
                StopWatchTimes.Items.Clear();
            }
            else
            {
                TimeSpan ts = stopwatchClock.GetTime();

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
            if (timerRegex.IsMatch(TimerAmount.Text))
            {
                string[] s = timerRegex.Match(TimerAmount.Text).Value.Split(':');
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
            if (timerRegex.IsMatch(TimerAmount.Text))
            {
                string[] s = timerRegex.Match(TimerAmount.Text).Value.Split(':');
                int[] values = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    values[i] = Convert.ToInt32(s[i]);
                }
                timerClock.Subtract(values);
            }
        }
    }
}
