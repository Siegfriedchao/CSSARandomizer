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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Randomizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<int> listExclude = new List<int>();

        Rectangle[] recArray = new Rectangle[120];

        List<Rectangle> listRec = new List<Rectangle>();

        Boolean global_startFlag = false;
        Boolean global_sweepFlag = false;

        int global_RandomNumber = 0;

        public MainPage()
        {
            this.InitializeComponent();
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

            int x = 100, y = 100;
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
                    y = 100;

                    columnCounter++;

                    if (columnCounter % 2 == 0)
                    {
                        x += 60;
                        chairBrush = chairLeftBrush;
                    }
                    else
                    {
                        x += 30;
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
                        y += 30;
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
                    Width = 20,
                    Height = 20,
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

        private void Button_Click_2(object sender, RoutedEventArgs e) // paint
        {
            global_sweepFlag = false;

            if (global_startFlag)
            {
                SolidColorBrush yellowBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
                //rec1.Fill = whiteBrush;

                int number = Generate_Random(120, listExclude);
                listRec[number].Fill = yellowBrush;

                texblk.Text = number.ToString();
            }

            global_startFlag = false;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
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

            Random random = new Random();

            int randomNumber;

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


                //playing a random trick here
            while (global_sweepFlag)
            {
                randomNumber = random.Next(0, 120);
                listRec[randomNumber].Fill = grayBrush;

                await Task.Run(()=> Random_Trick());

                await Task.Delay(TimeSpan.FromMilliseconds(100));
                listRec[randomNumber].Fill = chairRightBrush;
            }

        }

        private async Task Random_Trick()
        {
            //SolidColorBrush grayBrush = new SolidColorBrush(Windows.UI.Colors.Gray);

            //string chairLeft = "ms-appx:///Assets/chairLeft.png";
            //Uri uriLeft = new Uri(chairLeft, UriKind.RelativeOrAbsolute);
            //ImageBrush chairLeftBrush = new ImageBrush { ImageSource = new BitmapImage(uriLeft) };

            //string chairRight = "ms-appx:///Assets/chairRight.png";
            //Uri uriRight = new Uri(chairRight, UriKind.RelativeOrAbsolute);
            //ImageBrush chairRightBrush = new ImageBrush { ImageSource = new BitmapImage(uriRight) };

            //ImageBrush chairBrush;

            //chairBrush = chairRightBrush;

            Random random = new Random();

            //while (global_sweepFlag)
            //{
                global_RandomNumber = random.Next(0, 120);

                //Thread.Sleep(1000);
                //await delay(TimeSpan.FromSeconds(1));

                //listRec[randomNumber].Fill = chairRightBrush;
            //}
        }
    }
}
