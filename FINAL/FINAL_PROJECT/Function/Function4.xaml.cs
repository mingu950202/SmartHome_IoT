using FINAL_PROJECT.Helpers;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace FINAL_PROJECT.Function
{
    /// <summary>
    /// Function4.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Function4 : MetroWindow
    {
        public Function4()
        {
            InitializeComponent();
        }

        // 간편기능4 로드 시 
        private void Function4_Loaded(object sender, RoutedEventArgs e)
        {
            // 윈도우 토글 ON , OFF
            if (Function_4.WindowToggle == true)
            {
                WindowToggle.IsOn = true;
            }
            else
            {
                WindowToggle.IsOn = false;
            }

            // 블라인드 토글 ON , OFF
            if (Function_4.BlindToggle == true)
            {
                BlindToggle.IsOn = true;
            }
            else
            {
                BlindToggle.IsOn = false;
            }

            // 에어컨 토글 ON , OFF
            if (Function_4.AirconToggle == true)
            {
                AirconToggle.IsOn = true;
            }
            else
            {
                AirconToggle.IsOn = false;
            }

            // 보일러 토글 ON, OFF
            if (Function_4.BoilerToggle == true)
            {
                BoilerToggle.IsOn = true;
            }
            else
            {
                BoilerToggle.IsOn = false;
            }

            // 환풍기1 토글 ON , OFF
            if (Function_4.Fan2Toggle == true)
            {
                Fan1Toggle.IsOn = true;
            }
            else
            {
                Fan1Toggle.IsOn = false;
            }

            // 환풍기2 토글 ON , OFF
            if (Function_4.Fan2Toggle == true)
            {
                Fan2Toggle.IsOn = true;
            }
            else
            {
                Fan2Toggle.IsOn = false;
            }
        }

        // 적용
        private void Apply_Click(object sender, RoutedEventArgs e)
        {

            // 윈도우
            if (WindowToggle.IsOn == false)
            {
                Function_4.WindowToggle = false;
            }
            else if (WindowToggle.IsOn == true)
            {
                Function_4.WindowToggle = true;
            }

            // 블라인드
            if (BlindToggle.IsOn == false)
            {
                Function_4.BlindToggle = false;
            }
            else if (BlindToggle.IsOn == true)
            {
                Function_4.BlindToggle = true;
            }

            // 에어컨
            if (AirconToggle.IsOn == false)
            {
                Function_4.AirconToggle = false;
            }
            else if (AirconToggle.IsOn == true)
            {
                Function_4.AirconToggle = true;
            }

            // 보일러
            if (BoilerToggle.IsOn == false)
            {
                Function_4.BoilerToggle = false;
            }
            else if (BoilerToggle.IsOn == true)
            {
                Function_4.BoilerToggle = true;
            }

            // 환풍기1
            if (Fan1Toggle.IsOn == false)
            {
                Function_4.Fan1Toggle = false;
            }
            else if (Fan1Toggle.IsOn == true)
            {
                Function_4.Fan1Toggle = true;
            }

            // 환풍기2
            if (Fan2Toggle.IsOn == false)
            {
                Function_4.Fan2Toggle = false;
            }
            else if (Fan2Toggle.IsOn == true)
            {
                Function_4.Fan2Toggle = true;
            }

           
            this.Close();
        }
    }
}
