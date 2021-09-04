using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Panda_Local_Configuration;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Management;

namespace __UI_____Panda_A_.Settings
{
	/// <summary>
	/// Interaction logic for Panda_Settings.xaml
	/// </summary>
	public partial class Panda_Settings : Window
	{
		public Panda_Settings()
		{
			InitializeComponent();
            LoadInformation();
            if (Properties.Settings.Default.LastDLL == "PandaTechnology")
            {
                PandaBytecode.IsChecked = true;
            }
            else if (Properties.Settings.Default.LastDLL == "DLL-Test")
            {
                DLLTester.IsChecked = true;
                dll_filename.Text = Properties.Settings.Default.DLLFileName;
                dll_pipe.Text = Properties.Settings.Default.DLLPipe;
            }
            else
            {
                Properties.Settings.Default.LastDLL = "PandaTechnology";
                Properties.Settings.Default.Save();
                PandaBytecode.IsChecked = true;
            }

            if (Properties.Settings.Default.Panda_EnableDeveloperPanel == true)
            {
                AccessDeveloper.IsChecked = true;
                if (Properties.Settings.Default.Panda_UseDevUI == true)
                {
                    UseDevUI.IsChecked = true;
                }
            }

            bool DACMethod = Properties.Settings.Default.Panda_CustomInject;
            DACBypass.IsChecked = DACMethod;


        }


        private void LoadInformation()
        {
            string r = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                ManagementObjectCollection information = searcher.Get();
                if (information != null)
                {
                    foreach (ManagementObject obj in information)
                    {
                        r = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                    }
                }
                r = r.Replace("NT 5.1.2600", "XP");
                r = r.Replace("NT 5.2.3790", "Server 2003");
            }
            int buildos = Environment.OSVersion.Version.Build;
            string os = buildos.ToString();
            PandaVersion.Content = "Current Version: " + Properties.Settings.Default.PandaVersion;
            DeviceOS.Content = "Device OS: " + r + " [ " + buildos + " ] ";
            RobloxVersion.Content = "Roblox Client Version: Unknown";
        }
        /* Panda Button DLL */
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Panda Button
            Properties.Settings.Default.LastDLL = "PandaTechnology";
            Properties.Settings.Default.Save();
        }

        private void dll_testradio_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LastDLL = "DLL-Test";
            Properties.Settings.Default.Save();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LastDLL = "WinHookAPI";
            Properties.Settings.Default.Save();
        }


        private void KillRoblox(object sender, RoutedEventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
            {
                process.Kill();
            }
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void VisitSite(object sender, RoutedEventArgs e)
        {
            Process.Start("https://pandacheat.weebly.com/");
        }

        private void CloseBorder(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Some Settings on Panda-Exploit A+ such as ( Diagnosttic Logs and Voice Control ) are Required to Restart in order to apply this changes.");
            this.Close();
        }

        private void JoinDiscord(object sender, RoutedEventArgs e)
        {
            Process.Start("https://pandacoretechnology.000webhostapp.com/PandaJoinDiscord.html");
        }

        private void DisableDAC(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Panda_CustomInject = false;
            Properties.Settings.Default.Save();
        }

        private void EnableDAC(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Panda_CustomInject = true;
            Properties.Settings.Default.Save();
        }

        /*Panda's Auto Exec*/
        private void EnableAutoexec(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Panda_Autoexec = true;
            Properties.Settings.Default.Save();
        }

        private void DisableAutoExec(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Panda_Autoexec = false;
            Properties.Settings.Default.Save();
        }

        public static readonly string DefaultCefSharpPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Panda.TempFolder\\";

        /*Panda's Debug Mode*/
        private void SwitchDebugMode(object sender, RoutedEventArgs e)
        {


        }

        private void SwitchNormalMode(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dllfilepath = dll_filename.Text + ".dll";
            string dllpipez = dll_pipe.Text;
            Properties.Settings.Default.DLLPipe = dllpipez;
            Properties.Settings.Default.DLLFileName = dllfilepath;
            Properties.Settings.Default.Save();
            MessageBox.Show("Successfully Changed DLL Filename and Pipe");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*Multi-Instance*/
            if (!Directory.Exists("Tools"))
            {
                Directory.CreateDirectory("Tools");
            }
            if (!File.Exists("./Tools/PandaInstance.exe"))
            {

            }
            Process.Start("./Tools/PandaInstance.exe");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /*Reinstall Roblox*/
            if (!Directory.Exists("Tools"))
            {
                Directory.CreateDirectory("Tools");
            }
            if (!File.Exists("./Tools/RobloxPlayerLauncher.exe"))
            {

            }
            Process.Start("./Tools/RobloxPlayerLauncher.exe");
        }

        private void MissingLibraries(object sender, RoutedEventArgs e)
        {
            /*Missing Libraries Install*/
            if (!Directory.Exists("Tools"))
            {
                Directory.CreateDirectory("Tools");
            }
            if (!File.Exists("MS_VS2015.exe"))
            {

            }
            Process.Start("./Tools/MS_VS2015.exe");
        }

        private void Redownload_DLL(object sender, RoutedEventArgs e)
        {
            /*Redownload the Official Panda DLL*/
        }

        private void OurzObufscation(object sender, RoutedEventArgs e)
        {
            /*Panda Obfuscator*/
            MessageBox.Show("Coming Soon");
        }

        // ** Advance Control Configuration ** //

        private void DiscordRPC_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DiscordPC = true;
            Properties.Settings.Default.Save();

        }

        private void DiscordRPC_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DiscordPC = false;
            Properties.Settings.Default.Save();
        }

        private void InternalUserInterface_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void InternalUserInterface_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void FPSUnlock_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void FPSUnlock_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void SaveLastScript_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SaveLastScript_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void PAExControl_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PAExControl_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Volume = (double)volumes.Value;
            Properties.Settings.Default.Save();
        }

        private void AccessDeveloper_Checked(object sender, RoutedEventArgs e)
        {
            DevTAB.Visibility = Visibility.Visible;
            Properties.Settings.Default.Panda_EnableDeveloperPanel = true;
            Properties.Settings.Default.Save();
        }

        private void AccessDeveloper_Unchecked(object sender, RoutedEventArgs e)
        {
            DevTAB.Visibility = Visibility.Collapsed;
            Properties.Settings.Default.Panda_EnableDeveloperPanel = false;
            Properties.Settings.Default.Save();
        }

        private void UseDevUI_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Panda_UseDevUI = false;
            Properties.Settings.Default.Save();
        }

        private void UseDevUI_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Panda_UseDevUI = false;
            Properties.Settings.Default.Save();
        }
    }
}
