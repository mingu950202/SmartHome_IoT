using FINAL_PROJECT.Helpers;
using MahApps.Metro.Controls;
using Org.BouncyCastle.Crypto.Tls;
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
    /// ControlView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ControlView : MetroWindow
    {
        public SerialPort serialport = new SerialPort();

        public ControlView()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan();
            timer.Tick += Timer_Tick;
            timer.Start();


            if (serialport.IsOpen == true)
            {
                serialport.Close();
            }

            serialport.PortName = "COM7";
            serialport.BaudRate = 9600;
            serialport.Open();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerBlock.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분");
        }

        // 뒤로가기
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

        private void ControlView_Loaded(object sender, RoutedEventArgs e)
        {

            // 창문 토글 상태 변화
            if (SmartRoom.WindowToggle== true)
            {
                WindowToggle.IsOn = true;

            }
            else
            {
                WindowToggle.IsOn = false;
            }

            // 블라인드 토글 상태 변화
            if (SmartRoom.BlindToggle == true)
            {
                BlindToggle.IsOn = true;

            }
            else
            {
                BlindToggle.IsOn = false;
            }

            // 에어컨 토글 상태 변화
            if (SmartRoom.AirconToggle == true)
            {
                AirconToggle.IsOn = true;
                
            }
            else
            {
                AirconToggle.IsOn = false;
            }

            // 보일러 토글 상태 변화
            if (SmartRoom.BoilerToggle == true)
            {
                BoilerToggle.IsOn = true;

            }
            else
            {
                BoilerToggle.IsOn = false;
            }

            // 환풍기1 토글 상태 변화
            if (SmartRoom.Fan1Toggle == true)
            {
                Fan1Toggle.IsOn = true;

            }
            else
            {
                Fan1Toggle.IsOn = false;
            }

            // 환풍기2 토글 상태 변화
            if (SmartRoom.Fan2Toggle== true)
            {
                Fan2Toggle.IsOn = true;

            }
            else
            {
                Fan2Toggle.IsOn = false;
            }

        }

        // 윈도우 토글
        private void Window_Toggled(object sender, RoutedEventArgs e)
        {
            if (WindowToggle.IsOn == false)
            {
                SmartRoom.WindowToggle = false;
                serialport.Write("0");
            }
            else if (WindowToggle.IsOn == true)
            {
                SmartRoom.WindowToggle = true;
                serialport.Write("1");
            }
        }

        // 블라인드 토글
        private void Blind_Toggled(object sender, RoutedEventArgs e)
        {
            if (BlindToggle.IsOn == false)
            {
                SmartRoom.BlindToggle = false;
                serialport.Write("2");
            }
            else if (BlindToggle.IsOn == true)
            {
                SmartRoom.BlindToggle = true;
                serialport.Write("3");
            }
        }

        // 에어컨 토글
        private void AirconToggle_Toggled(object sender, RoutedEventArgs e)
        {
            if (AirconToggle.IsOn == false)
            {
                SmartRoom.AirconToggle = false;
                serialport.Write("4");
            }
            else if (AirconToggle.IsOn == true)
            {
                SmartRoom.AirconToggle = true;
                serialport.Write("5");
            }
        }

        // 보일러 토글 
        private void Boiler_Toggled(object sender, RoutedEventArgs e)
        {
            if (BoilerToggle.IsOn == false)
            {
                SmartRoom.BoilerToggle = false;
                serialport.Write("6");
            }
            else if (BoilerToggle.IsOn == true)
            {
                SmartRoom.BoilerToggle = true;
                serialport.Write("7");
            }
        }

        // 환풍기1 토글
        private void Fan1_Toggled(object sender, RoutedEventArgs e)
        {
            if (Fan1Toggle.IsOn == false)
            {
                SmartRoom.Fan1Toggle = false;
                serialport.Write("8");
            }
            else if (Fan1Toggle.IsOn == true)
            {
                SmartRoom.Fan1Toggle = true;
                serialport.Write("9");
            }
        }

        // 환풍기2 토글
        private void Fan2_Toggled(object sender, RoutedEventArgs e)
        {
            if (Fan2Toggle.IsOn == false)
            {
                SmartRoom.Fan2Toggle = false;
                serialport.Write("a");
            }
            else if(Fan2Toggle.IsOn == true)
            {
                SmartRoom.Fan2Toggle = true;
                serialport.Write("b");
            }
        }

        // 외출 모드 클릭
        private void OutBox_Clicked(object sender, RoutedEventArgs e)
        {
            WindowToggle.IsOn = false;
            BlindToggle.IsOn = false;
            AirconToggle.IsOn = false;
            BoilerToggle.IsOn = false;
            Fan1Toggle.IsOn = false;
            Fan2Toggle.IsOn = false;

            serialport.Write("x");
        }

        // 컨트롤 뷰 닫기 
        private void ControlView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            serialport.Close();
        }


    }
}
