using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace RbtCmdr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool LockWorkStation();

        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);


        public MainWindow()
        {

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(LockWS.IsChecked==true)
            {
                LockWorkStation();
            }

            if (sleep.IsChecked ==true)
            {
                System.Windows.Forms.Application.SetSuspendState(PowerState.Suspend, true, true);
            }

            if (Hib1.IsChecked==true)
            {
                System.Windows.Forms.Application.SetSuspendState(PowerState.Hibernate, true, true);
            }

            if(sdown.IsChecked ==true)
            {
                Process.Start("shutdown", "/s /t 0");
            }
            if (Rbt.IsChecked ==true)
            {
                Process.Start("shutdown", "/r /t 0");
            }
            if(Log_off.IsChecked ==true)
            {
                ExitWindowsEx(0, 0);
            }
            if (RBT_FW.IsChecked ==true)
            {
                Process.Start("shutdown", "/r /fw /t 0");
            }
            if(Rbt_Adv.IsChecked==true)
            {
                Process.Start("shutdown", "/r /o /t 0");
            }
        }
    }


}
