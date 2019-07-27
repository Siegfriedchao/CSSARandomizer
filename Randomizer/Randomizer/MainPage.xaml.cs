using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Randomizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // some globals
        List<int> listExclude = new List<int>();

        Rectangle[] recArray = new Rectangle[120];

        List<Rectangle> listRec = new List<Rectangle>();

        Boolean global_startFlag = false;
        Boolean global_sweepFlag = false;

        int global_RandomNumber = 0;

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(1440, 960);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(1440, 960));

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            // Set active window colors
            titleBar.ForegroundColor = Windows.UI.Colors.White;
            titleBar.BackgroundColor = Windows.UI.Colors.MediumPurple;
            titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.MediumPurple;
            titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.MediumPurple;
            titleBar.ButtonPressedForegroundColor = Windows.UI.Colors.Gray;
            titleBar.ButtonPressedBackgroundColor = Windows.UI.Colors.PeachPuff;

            Plot_Chairs();
        }

        private void Plot_Chairs()
        {
            //SolidColorBrush purpleBrush = new SolidColorBrush(Windows.UI.Colors.Purple);

            string chairLeft = "ms-appx:///Assets/chairLeft.png";
            Uri uriLeft = new Uri(chairLeft, UriKind.RelativeOrAbsolute);
            ImageBrush chairLeftBrush = new ImageBrush { ImageSource = new BitmapImage(uriLeft) };

            string chairRight = "ms-appx:///Assets/chairRight.png";
            Uri uriRight = new Uri(chairRight, UriKind.RelativeOrAbsolute);
            ImageBrush chairRightBrush = new ImageBrush { ImageSource = new BitmapImage(uriRight) };

            ImageBrush chairBrush;

            int x = 80, y = 0;
            int columnCounter = 0;
            int rowCounter = 0;
            Boolean flag = false;

            /*
             * Plotting a list of rectangles representing tables
             */
            for (var i = 0; i < 120; i++)
            {
                // five big columns with 12x2 per each column
                if (rowCounter == 11)
                {
                    y = 0;

                    columnCounter++;

                    if (columnCounter % 2 == 0)
                    {
                        x += 100;
                        chairBrush = chairLeftBrush;
                    }
                    else
                    {
                        x += 80;
                        chairBrush = chairRightBrush;
                    }

                    rowCounter = 0;
                }
                else
                {
                    if (!flag)
                    {
                        flag = true;
                    }
                    else
                    {
                        y += 50;
                        rowCounter++;
                    }

                }

                if (columnCounter % 2 == 0)
                {
                    chairBrush = chairLeftBrush;
                }
                else
                {
                    chairBrush = chairRightBrush;
                }

                Rectangle rectangleNew = new Rectangle
                {
                    Width = 30,
                    Height = 30,
                    Fill = chairBrush,
                    RadiusX = 5,
                    RadiusY = 5,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(x, y, 0, 0)
                };
                listRec.Add(rectangleNew);
                layout.Children.Add(rectangleNew);
            }
        }

        private int Generate_Random(int length, List<int> listExclude)
        {
            Random random = new Random();

            int randomNumber;

            do
            {
                randomNumber = random.Next(0, length);
            } while (listExclude.Contains(randomNumber));

            listExclude.Add(randomNumber);

            return randomNumber;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // reset
        {
            global_sweepFlag = false;

            texblk.Text = "N/A";
            texCol.Text = "N/A";
            texRow.Text = "N/A";

            SolidColorBrush purpleBrush = new SolidColorBrush(Windows.UI.Colors.Purple);
            string chairLeft = "ms-appx:///Assets/chairLeft.png";
            Uri uriLeft = new Uri(chairLeft, UriKind.RelativeOrAbsolute);
            ImageBrush chairLeftBrush = new ImageBrush { ImageSource = new BitmapImage(uriLeft) };

            string chairRight = "ms-appx:///Assets/chairRight.png";
            Uri uriRight = new Uri(chairRight, UriKind.RelativeOrAbsolute);
            ImageBrush chairRightBrush = new ImageBrush { ImageSource = new BitmapImage(uriRight) };

            ImageBrush chairBrush;

            int columnCounter = 0;
            int rowCounter = 0;
            Boolean flag = false;

            /*
             * Plotting a list of rectangles representing tables
             */
            for (var i = 0; i < 120; i++)
            {
                // five big columns with 12x2 per each column
                if (rowCounter == 11)
                {
                    columnCounter++;

                    rowCounter = 0;
                }
                else
                {
                    if (!flag)
                    {
                        flag = true;
                    }
                    else
                    {
                        rowCounter++;
                    }
                }

                if (columnCounter % 2 == 0)
                {
                    chairBrush = chairLeftBrush;
                }
                else
                {
                    chairBrush = chairRightBrush;
                }

                listRec[i].Fill = chairBrush;
            }
                //layout.Background = chairBrush;
                listExclude.Clear();

            global_startFlag = false;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e) // stop and pick
        {
            global_sweepFlag = false;


            SolidColorBrush grayBrush = new SolidColorBrush(Windows.UI.Colors.Gray);

            string chairLeft = "ms-appx:///Assets/chairLeft.png";
            Uri uriLeft = new Uri(chairLeft, UriKind.RelativeOrAbsolute);
            ImageBrush chairLeftBrush = new ImageBrush { ImageSource = new BitmapImage(uriLeft) };

            string chairRight = "ms-appx:///Assets/chairRight.png";
            Uri uriRight = new Uri(chairRight, UriKind.RelativeOrAbsolute);
            ImageBrush chairRightBrush = new ImageBrush { ImageSource = new BitmapImage(uriRight) };

            ImageBrush chairBrush;

            chairBrush = chairRightBrush;

            int column = 0;

            int columnShow, row;
            int time;

            column = global_RandomNumber / 12;
            if (column % 2 == 0)
            {
                listRec[global_RandomNumber].Fill = chairLeftBrush;
            }
            else
            {
                listRec[global_RandomNumber].Fill = chairRightBrush;
            }

            //playing a random trick here
            for (var j = 0; j < 8; j++)
            {
                await Task.Run(() => Random_Trick());

                texblk.Text = global_RandomNumber.ToString();
                columnShow = (global_RandomNumber / 12) + 1;
                row = (global_RandomNumber % 12) + 1;
                texCol.Text = columnShow.ToString();
                texRow.Text = row.ToString();

                listRec[global_RandomNumber].Fill = grayBrush;

                time = 150 * j;

                await Task.Delay(TimeSpan.FromMilliseconds(time));

                column = global_RandomNumber / 12;
                if (column % 2 == 0)
                {
                    listRec[global_RandomNumber].Fill = chairLeftBrush;
                }
                else
                {
                    listRec[global_RandomNumber].Fill = chairRightBrush;
                }
            }


            int columnCount, rowCount;

            if (global_startFlag)
            {
                SolidColorBrush yellowBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);

                int number;

                do
                {
                    number = Generate_Random(120, listExclude);
                } while (number == global_RandomNumber);
                
                listRec[number].Fill = yellowBrush;

                columnCount = (number / 12) + 1;
                rowCount = (number % 12) + 1;
                texblk.Text = number.ToString();
                texCol.Text = columnCount.ToString();
                texRow.Text = rowCount.ToString();
            }

            global_startFlag = false;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e) // start sweeping
        {
            global_startFlag = true;
            global_sweepFlag = true;


            SolidColorBrush grayBrush = new SolidColorBrush(Windows.UI.Colors.Gray);

            string chairLeft = "ms-appx:///Assets/chairLeft.png";
            Uri uriLeft = new Uri(chairLeft, UriKind.RelativeOrAbsolute);
            ImageBrush chairLeftBrush = new ImageBrush { ImageSource = new BitmapImage(uriLeft) };

            string chairRight = "ms-appx:///Assets/chairRight.png";
            Uri uriRight = new Uri(chairRight, UriKind.RelativeOrAbsolute);
            ImageBrush chairRightBrush = new ImageBrush { ImageSource = new BitmapImage(uriRight) };

            ImageBrush chairBrush;

            chairBrush = chairRightBrush;

            int columnCounter = 0;
            int rowCounter = 0;
            int column = 0;
            Boolean flag = false;

            int columnShow, row;

            /*
             * Plotting a list of rectangles representing tables
             */
            for (var i = 0; i < 120; i++)
            {
                // five big columns with 12x2 per each column
                if (rowCounter == 11)
                {
                    columnCounter++;

                    rowCounter = 0;
                }
                else
                {
                    if (!flag)
                    {
                        flag = true;
                    }
                    else
                    {
                        rowCounter++;
                    }
                }

                if (columnCounter % 2 == 0)
                {
                    chairBrush = chairLeftBrush;
                }
                else
                {
                    chairBrush = chairRightBrush;
                }

                listRec[i].Fill = chairBrush;
            }


                //playing a random trick here
            while (global_sweepFlag)
            {
                await Task.Run(() => Random_Trick());

                texblk.Text = global_RandomNumber.ToString();
                columnShow = (global_RandomNumber / 12) + 1;
                row = (global_RandomNumber % 12) + 1;
                texCol.Text = columnShow.ToString();
                texRow.Text = row.ToString();

                listRec[global_RandomNumber].Fill = grayBrush;

                await Task.Delay(TimeSpan.FromMilliseconds(100));

                column = global_RandomNumber / 12;
                if (column % 2 == 0)
                {
                    listRec[global_RandomNumber].Fill = chairLeftBrush;
                }
                else
                {
                    listRec[global_RandomNumber].Fill = chairRightBrush;
                }
            }

        }

        private async Task Random_Trick()
        {
            Random random = new Random();

            global_RandomNumber = random.Next(0, 120);

            
        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
