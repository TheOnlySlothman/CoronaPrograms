using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClockProgram
{
    class DigitalClock : BaseClock
    {
        //element collection of children in a grid, with images that symbolise parts of a digitalwatch
        readonly UIElementCollection[] elementCollection = new UIElementCollection[6];
        public DigitalClock(UIElementCollection[] uI)
        {
            elementCollection = uI;
            Reset();
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
            Reset();
            UpdateVisuals(elementCollection[0], DateTime.Now.Hour / 10);
            UpdateVisuals(elementCollection[1], DateTime.Now.Hour % 10);
            UpdateVisuals(elementCollection[2], DateTime.Now.Minute / 10);
            UpdateVisuals(elementCollection[3], DateTime.Now.Minute % 10);
            UpdateVisuals(elementCollection[4], DateTime.Now.Second / 10);
            UpdateVisuals(elementCollection[5], DateTime.Now.Second % 10);
        }

        private void UpdateVisuals(UIElementCollection uI, int num)
        {
            #region numbers
            switch (num)
            {
                case 0:
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == 6)
                            continue;
                        uI[i].Visibility = Visibility.Visible;
                    }
                    break;
                case 1:
                    uI[1].Visibility = Visibility.Visible;
                    uI[2].Visibility = Visibility.Visible;
                    break;
                case 2:
                    uI[0].Visibility = Visibility.Visible;
                    uI[1].Visibility = Visibility.Visible;
                    uI[6].Visibility = Visibility.Visible;
                    uI[4].Visibility = Visibility.Visible;
                    uI[3].Visibility = Visibility.Visible;
                    break;
                case 3:
                    uI[0].Visibility = Visibility.Visible;
                    uI[1].Visibility = Visibility.Visible;
                    uI[6].Visibility = Visibility.Visible;
                    uI[2].Visibility = Visibility.Visible;
                    uI[3].Visibility = Visibility.Visible;
                    break;
                case 4:
                    uI[1].Visibility = Visibility.Visible;
                    uI[2].Visibility = Visibility.Visible;
                    uI[5].Visibility = Visibility.Visible;
                    uI[6].Visibility = Visibility.Visible;
                    break;
                case 5:
                    uI[0].Visibility = Visibility.Visible;
                    uI[5].Visibility = Visibility.Visible;
                    uI[6].Visibility = Visibility.Visible;
                    uI[2].Visibility = Visibility.Visible;
                    uI[3].Visibility = Visibility.Visible;
                    break;
                case 6:
                    for (int i = 0; i < uI.Count; i++)
                    {
                        if (i == 1)
                            continue;
                        uI[i].Visibility = Visibility.Visible;
                    }
                    break;
                case 7:
                    uI[0].Visibility = Visibility.Visible;
                    uI[1].Visibility = Visibility.Visible;
                    uI[2].Visibility = Visibility.Visible;
                    break;
                case 8:
                    for (int i = 0; i < uI.Count; i++)
                    {
                        uI[i].Visibility = Visibility.Visible;
                    }
                    break;
                case 9:
                    for (int i = 0; i < uI.Count; i++)
                    {
                        if (i == 4)
                            continue;
                        uI[i].Visibility = Visibility.Visible;
                    }
                    break;
                default:
                    break;
            }
            #endregion
        }

        //Hides the images
        public void Reset()
        {
            for (int i = 0; i < elementCollection.Count(); i++)
            {
                foreach (Image element in elementCollection[i])
                {
                    element.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
