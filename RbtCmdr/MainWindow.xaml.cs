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
using System.Security.Principal;
using System.IO;
using System.ComponentModel;

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

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
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
                Process sdown = new Process();
                sdown.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                sdown.StartInfo.FileName = "Shutdown.exe";
                sdown.StartInfo.Arguments = "/s /f /t 0";
                sdown.StartInfo.UseShellExecute = true;
                sdown.StartInfo.RedirectStandardOutput = false;
                sdown.StartInfo.RedirectStandardError = false;
                //RBT.StartInfo.Verb = "runas";
                sdown.Start();
            }
            if (Rbt.IsChecked ==true)
            {
                Process RBT = new Process();
                RBT.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                RBT.StartInfo.FileName = "Shutdown.exe";
                RBT.StartInfo.Arguments = "/r /f /t 0";
                RBT.StartInfo.UseShellExecute = true;
                RBT.StartInfo.RedirectStandardOutput = false;
                RBT.StartInfo.RedirectStandardError = false;
                //RBT.StartInfo.Verb = "runas";
                RBT.Start();
            }
            if(Log_off.IsChecked ==true)
            {
                ExitWindowsEx(0, 0);
            }
            if (RBT_FW.IsChecked ==true)
            {
                Process FW = new Process();
                FW.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                FW.StartInfo.FileName = "Shutdown.exe";
                FW.StartInfo.Arguments = "/r /fw /t 0";
                FW.StartInfo.UseShellExecute = true;
                FW.StartInfo.RedirectStandardOutput = false;
                FW.StartInfo.RedirectStandardError = false;
                FW.StartInfo.Verb = "runas";
                FW.Start();
            }
            if(Rbt_Adv.IsChecked==true)
            {
                Process ADV = new Process();
                ADV.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ADV.StartInfo.FileName = "Shutdown.exe";
                ADV.StartInfo.Arguments = "/r /o /t 0";
                ADV.StartInfo.UseShellExecute = true;
                ADV.StartInfo.RedirectStandardOutput = false;
                ADV.StartInfo.RedirectStandardError = false;
                ADV.StartInfo.Verb = "runas";
                ADV.Start();
            }

        }

        //Check if user is running as admin
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void LockWS_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Lock Workstation";
            RBT_BTN.IsEnabled = true;
        }

        private void Log_off_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Logoff";
            RBT_BTN.IsEnabled = true;
        }

        private void sleep_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Sleep";
            RBT_BTN.IsEnabled = true;
        }

        private void Hib1_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Hibernate";
            RBT_BTN.IsEnabled = true;
        }

        private void sdown_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Shutdown";
            RBT_BTN.IsEnabled = true;
        }

        private void Rbt_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Restart";
            RBT_BTN.IsEnabled = true;
        }

        private void RBT_FW_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Boot Firmware";
            RBT_BTN.IsEnabled = true;
        }

        private void Rbt_Adv_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Advanced Options";
            RBT_BTN.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }



}
