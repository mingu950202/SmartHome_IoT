using Caliburn.Micro;
using FINAL_PROJECT.Function;
using FINAL_PROJECT.Helpers;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace FINAL_PROJECT.Views
{
    /// <summary>
    /// FunctionView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FunctionView : MetroWindow
    {
        SerialPort serialport = new SerialPort();

        public FunctionView()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan();
            timer.Tick += Timer_Tick;
            timer.Start();

            serialport.PortName = "COM7";
            serialport.BaudRate = 9600;
            serialport.Open();
        }

        // 현재 시간
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerBlock.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분");
        }

        // 뒤로 가기
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (serialport.IsOpen == true)
            {
                serialport.Close();
            }
            MainView mainView = new MainView();
            mainView.Show();
            GetWindow(this).Close();
        }

        // 간편 기능1 버튼
        private void Function1_Click(object sender, RoutedEventArgs e)
        {
            Function1 function1 = new Function1();
            function1.Show();
        }

        // 간편 기능2 버튼
        private void Function2_Click(object sender, RoutedEventArgs e)
        {
            Function2 function2 = new Function2();
            function2.Show();
        }

        // 간편 기능3 버튼
        private void Function3_Click(object sender, RoutedEventArgs e)
        {
            Function3 function3 = new Function3();
            function3.Show();
        }

        // 간편 기능4 버튼
        private void Function4_Click(object sender, RoutedEventArgs e)
        {
            Function4 function4 = new Function4();
            function4.Show();
        }

        // 적용 버튼1
        private void ApplyBtn1_Clicked(object sender, RoutedEventArgs e)
        {
            // 윈도우
            if (Function_1.WindowToggle == true)
            {
                SmartRoom.WindowToggle = true;
                serialport.Write("1");
            }
            else if (Function_1.WindowToggle == false)
            {
                SmartRoom.WindowToggle= false;
                serialport.Write("0");
            }

            // 블라인드
            if (Function_1.BlindToggle == true)
            {
                SmartRoom.BlindToggle = true;
                serialport.Write("3");
            }
            else if (Function_1.BlindToggle== false)
            {
                SmartRoom.BlindToggle = false;
                serialport.Write("2");
            }

            // 에어컨
            if (Function_1.AirconToggle == true)
            {
                SmartRoom.AirconToggle = true;
                serialport.Write("5");
            }
            else if (Function_1.AirconToggle == false)

            {
                SmartRoom.AirconToggle = false;
                serialport.Write("4");
            }

            // 보일러
            if (Function_1.BoilerToggle == true)
            {
                SmartRoom.BoilerToggle = true;
                serialport.Write("7");
            }
            else if (Function_1.BoilerToggle == false)

            {
                SmartRoom.BoilerToggle = false;
                serialport.Write("6");
            }

            // 환풍기1
            if (Function_1.Fan1Toggle == true)
            {
                SmartRoom.Fan1Toggle = true;
                serialport.Write("9");
            }
            else if (Function_1.Fan1Toggle == false)
            {
                SmartRoom.Fan1Toggle = false;
                serialport.Write("8");
            }

            // 환풍기2
            if (Function_1.Fan2Toggle == true)
            {
                SmartRoom.Fan2Toggle = true;
                serialport.Write("a");
            }
            else if (Function_1.Fan2Toggle == false)
            {
                SmartRoom.Fan2Toggle = false;
                serialport.Write("b");
            }
            MessageBox.Show("적용");
        }

        // 적용 2
        private void ApplyBtn2_Clicked(object sender, RoutedEventArgs e)
        {
            // 윈도우
            if (Function_2.WindowToggle == true)
            {
                SmartRoom.WindowToggle = true;
                serialport.Write("1");
            }
            else if (Function_2.WindowToggle == false)
            {
                SmartRoom.WindowToggle = false;
                serialport.Write("0");
            }

            // 블라인드
            if (Function_2.BlindToggle == true)
            {
                SmartRoom.BlindToggle = true;
                serialport.Write("3");
            }
            else if (Function_2.BlindToggle == false)
            {
                SmartRoom.BlindToggle = false;
                serialport.Write("2");
            }

            // 에어컨
            if (Function_2.AirconToggle == true)
            {
                SmartRoom.AirconToggle = true;
                serialport.Write("5");
            }
            else if (Function_2.AirconToggle == false)

            {
                SmartRoom.AirconToggle = false;
                serialport.Write("4");
            }

            // 보일러
            if (Function_2.BoilerToggle == true)
            {
                SmartRoom.BoilerToggle = true;
                serialport.Write("7");
            }
            else if (Function_2.BoilerToggle == false)

            {
                SmartRoom.BoilerToggle = false;
                serialport.Write("6");
            }

            // 환풍기1
            if (Function_2.Fan1Toggle == true)
            {
                SmartRoom.Fan1Toggle = true;
                serialport.Write("9");
            }
            else if (Function_2.Fan1Toggle == false)
            {
                SmartRoom.Fan1Toggle = false;
                serialport.Write("8");
            }

            // 환풍기2
            if (Function_2.Fan2Toggle == true)
            {
                SmartRoom.Fan2Toggle = true;
                serialport.Write("a");
            }
            else if (Function_2.Fan2Toggle == false)
            {
                SmartRoom.Fan2Toggle = false;
                serialport.Write("b");
            }
            MessageBox.Show("적용");
        }

        // 적용3 
        private void ApplyBtn3_Clicked(object sender, RoutedEventArgs e)
        {
            // 윈도우
            if (Function_3.WindowToggle == true)
            {
                SmartRoom.WindowToggle = true;
                serialport.Write("1");
            }
            else if (Function_3.WindowToggle == false)
            {
                SmartRoom.WindowToggle = false;
                serialport.Write("0");
            }

            // 블라인드
            if (Function_3.BlindToggle == true)
            {
                SmartRoom.BlindToggle = true;
                serialport.Write("3");
            }
            else if (Function_3.BlindToggle == false)
            {
                SmartRoom.BlindToggle = false;
                serialport.Write("2");
            }

            // 에어컨
            if (Function_3.AirconToggle == true)
            {
                SmartRoom.AirconToggle = true;
                serialport.Write("5");
            }
            else if (Function_3.AirconToggle == false)

            {
                SmartRoom.AirconToggle = false;
                serialport.Write("4");
            }

            // 보일러
            if (Function_3.BoilerToggle == true)
            {
                SmartRoom.BoilerToggle = true;
                serialport.Write("7");
            }
            else if (Function_3.BoilerToggle == false)

            {
                SmartRoom.BoilerToggle = false;
                serialport.Write("6");
            }

            // 환풍기1
            if (Function_3.Fan1Toggle == true)
            {
                SmartRoom.Fan1Toggle = true;
                serialport.Write("9");
            }
            else if (Function_3.Fan1Toggle == false)
            {
                SmartRoom.Fan1Toggle = false;
                serialport.Write("8");
            }

            // 환풍기2
            if (Function_3.Fan2Toggle == true)
            {
                SmartRoom.Fan2Toggle = true;
                serialport.Write("a");
            }
            else if (Function_3.Fan2Toggle == false)
            {
                SmartRoom.Fan2Toggle = false;
                serialport.Write("b");
            }
            MessageBox.Show("적용");
        }

        // 적용4
        private void ApplyBtn4_Clicked(object sender, RoutedEventArgs e)
        {
            // 윈도우
            if (Function_4.WindowToggle == true)
            {
                SmartRoom.WindowToggle = true;
                serialport.Write("1");
            }
            else if (Function_4.WindowToggle == false)
            {
                SmartRoom.WindowToggle = false;
                serialport.Write("0");
            }

            // 블라인드
            if (Function_4.BlindToggle == true)
            {
                SmartRoom.BlindToggle = true;
                serialport.Write("3");
            }
            else if (Function_4.BlindToggle == false)
            {
                SmartRoom.BlindToggle = false;
                serialport.Write("2");
            }

            // 에어컨
            if (Function_4.AirconToggle == true)
            {
                SmartRoom.AirconToggle = true;
                serialport.Write("5");
            }
            else if (Function_4.AirconToggle == false)

            {
                SmartRoom.AirconToggle = false;
                serialport.Write("4");
            }

            // 보일러
            if (Function_4.BoilerToggle == true)
            {
                SmartRoom.BoilerToggle = true;
                serialport.Write("7");
            }
            else if (Function_4.BoilerToggle == false)

            {
                SmartRoom.BoilerToggle = false;
                serialport.Write("6");
            }

            // 환풍기1
            if (Function_4.Fan1Toggle == true)
            {
                SmartRoom.Fan1Toggle = true;
                serialport.Write("9");
            }
            else if (Function_4.Fan1Toggle == false)
            {
                SmartRoom.Fan1Toggle = false;
                serialport.Write("8");
            }

            // 환풍기2
            if (Function_4.Fan2Toggle == true)
            {
                SmartRoom.Fan2Toggle = true;
                serialport.Write("a");
            }
            else if (Function_4.Fan2Toggle == false)
            {
                SmartRoom.Fan2Toggle = false;
                serialport.Write("b");
            }
            MessageBox.Show("적용");
        }
        // View 종료 시
        private void FunctionView_Closed(object sender, EventArgs e)
        {
            if (serialport.IsOpen == true)
            {
                serialport.Close();
            }
        }


    }


}
