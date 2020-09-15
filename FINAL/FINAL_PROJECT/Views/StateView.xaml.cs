using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
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
    /// StateView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StateView : MetroWindow
    {
        SerialPort serialport = new SerialPort();
        
        public StateView()
        {
            InitializeComponent();

            if (serialport.IsOpen == true)
            {
                serialport.Close();
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan();
            timer.Tick += Timer_Tick;
            timer.Start();

            serialport.PortName = "COM7";
            serialport.BaudRate =  9600;
            serialport.Open();
            serialport.DataReceived += SensorReceived;
            

        }

        // 아두이노 센서값을 ","로 문자열 나눔
        private void SensorReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string Sensor = serialport.ReadLine();
            string[] s = Sensor.Split(',');
            this.BeginInvoke((new Action(delegate { Sensor_Value(s); })));
        }

        private void Sensor_Value(string[] Sensor)
        {
            TempValue.Text = Sensor[0].ToString();
            HumidValue.Text = Sensor[1].ToString();
            UVValue.Text = Sensor[2].ToString();
            //DustValue.Text = Sensor[3].ToString();
        }

        // 현재시간
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
    }
}
