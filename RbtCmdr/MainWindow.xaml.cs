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

            //InitializeComponent();
            //bool Admin = IsAdministrator();
            //if (Admin == true)
            //{

            //}
            //if (Admin ==false)
            //{
            //    Rbt_Adv.Visibility = Visibility.Hidden;
            //    RBT_FW.Visibility = Visibility.Hidden;
            //System.Windows.MessageBox.Show("Not ADMIN"); 
            //}
            

            }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var drives = DriveInfo.GetDrives();

            //for each drive look and see if it removable
            foreach (var drive in drives)
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    //found a usb drive so show USB Boot option
                    //Rbt_USB.Visibility = Visibility.Visible;
                }
            }

           
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
                //Process.Start("shutdown", "/s /t 0");
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
                //Process.Start("shutdown", "/r /t 0");
            }
            if(Log_off.IsChecked ==true)
            {
                ExitWindowsEx(0, 0);
            }
            if (RBT_FW.IsChecked ==true)
            {
                //Process.Start("shutdown", "/r /fw /t 0");
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
                //Process.Start("shutdown", "/r /o /t 0");
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
        }

        private void Log_off_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Logoff";
        }

        private void sleep_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Sleep";
        }

        private void Hib1_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Hibernate";
        }

        private void sdown_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Shutdown";
        }

        private void Rbt_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Restart";
        }

        private void RBT_FW_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Boot Firmware";
        }

        private void Rbt_Adv_Checked(object sender, RoutedEventArgs e)
        {
            RBT_BTN.Content = "Advanced Options";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }



}
