using FINAL_PROJECT.Helpers;
using FINAL_PROJECT.ViewModels;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf.Converters;
using MySql.Data.MySqlClient;
using Renci.SshNet.Security.Cryptography;
using System;
using System.Deployment.Internal;
using System.Diagnostics;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Threading;

namespace FINAL_PROJECT.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : MetroWindow
    {
        SerialPort serialport = new SerialPort();

        // 데이터베이스 연결
        string ConnString = "Server=127.0.0.1;port=3306;Database=smarthome_db;Uid=root;Password=0000;";

        public MainView()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan();
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void MainView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            serialport.PortName = "COM7";
            serialport.BaudRate = 9600;
            serialport.Open();
            serialport.DataReceived += SensorDataReceived;
            
            /* 예제
            string testSensing =  " CREATE TABLE `smarthome_db`.`testsensing`   (" +
                      "              `Temp`   VARCHAR(20),           " +
                      "              `Humid`  VARCHAR(20))           " ;
            */

            /*    
            string test = " INSERT INTO testdb         " +
                              "             (name,         " +
                              "             age)          " +
                              "       VALUES               " +
                              "            ('김민수',         " +
                              "             '27')         ";
            MySqlCommand cmd1 = new MySqlCommand(test, conn);
            cmd1.ExecuteNonQuery();
            */

        }

        // 아두이노 센서값 저장
        private void SensorDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string SensorData = serialport.ReadLine();
            string[] s = SensorData.Split(',');
            if (s.Length < 3)
            {
                return;
            }
            Var.T = s[0].ToString();    // 온도
            Var.H = s[1].ToString();
            Var.U = s[2].ToString().Replace("\r", "");
            //Var.D = s[3].ToString();    // 미세먼지
            //this.BeginInvoke((new Action(delegate { SensorData_Value(s); })));

            Proc_Data();
        }

        /*
        private void SensorData_Value(string[] SensorData)
        {
            if (SensorData.Length < 4)
            {
                return;
            }
            
            Var.T = SensorData[0].ToString();
            Var.H = SensorData[1].ToString();
            Var.U = SensorData[2].ToString();
            Var.D = SensorData[3].ToString();
        }
        */

        // 현재 시간
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerBlock.Text = DateTime.Now.ToString("yyyy년 MMM월 dd일 HH시 mm분");
        }

        // 상태
        private void StateBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(serialport.IsOpen == true)
            {
                serialport.Close();
            }
            StateView stateView = new StateView();
            stateView.Show();
            GetWindow(this).Close();
        }

        // 조작
        private void ControlBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (serialport.IsOpen == true)
            {
                serialport.Close();
            }
            ControlView controlView = new ControlView();
            controlView.Show();
            GetWindow(this).Close();
        }

        // 간편기능
        private void FunctionBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (serialport.IsOpen == true)
            {
                serialport.Close();
            }
            FunctionView functionView = new FunctionView();
            functionView.Show();
            GetWindow(this).Close();
        }

        private void MainView_Closed(object sender, EventArgs e)
        {
        }

        // DB 저장
        private void Proc_Data()
        {
            string Sensing = " INSERT INTO states         " +
                 "             (Datetime,         " +
                 "              Temp,         " +
                 "              Humid,        " +
                 "              UV)           " +
                 //"             Dust)          " +
                 "       VALUES               " +
                 "            (@Datetime,         " +
                 "             @Temp,         " +
                 "             @Humid,         " +
                 "             @UV)            ";
                 //"             @Dust)         ";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Sensing, conn);

                    MySqlParameter paramDatetime = new MySqlParameter("@Datetime", MySqlDbType.DateTime);
                    paramDatetime.Value = DateTime.Now;
                    cmd.Parameters.Add(paramDatetime);

                    MySqlParameter paramTemp = new MySqlParameter("@Temp", MySqlDbType.Float);
                    paramTemp.Value = Var.T;
                    cmd.Parameters.Add(paramTemp);

                    MySqlParameter paramHumid = new MySqlParameter("@Humid", MySqlDbType.Float);
                    paramHumid.Value = Var.H;
                    cmd.Parameters.Add(paramHumid);

                    MySqlParameter paramUV = new MySqlParameter("@UV", MySqlDbType.Float);
                    paramUV.Value = Var.U;
                    cmd.Parameters.Add(paramUV);

                    //MySqlParameter paramDust = new MySqlParameter("@Dust", MySqlDbType.Float);
                    //paramDust.Value = Var.D;
                    //cmd.Parameters.Add(paramDust);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        

    }
}
