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
using __UI_____Panda_A_.Core.User_Level;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using SharpCompress.Archives;
using SharpCompress.Common;

namespace __UI_____Panda_A_.Loader
{
    /// <summary>
    /// Interaction logic for Loader.xaml
    /// </summary>
    public partial class Loader : Window
    {

        /* -----------------------------------------------------------------------------  */
        private void PandaGHubProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLoader.Value = e.ProgressPercentage;
            double value = ProgressLoader.Value;
            string str = Convert.ToInt32(value).ToString();
            StatusText.Text = "Updating Panda Game-Hub Service ( " + str + "% Complete )";
        }

        private void PandaConfigProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLoader.Value = e.ProgressPercentage;
            double value = ProgressLoader.Value;
            string str = Convert.ToInt32(value).ToString();
            StatusText.Text = "Updating Panda Configuration Service ( " + str + "% Complete )";
        }

        private void PandaShadAPIProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLoader.Value = e.ProgressPercentage;
            double value = ProgressLoader.Value;
            string str = Convert.ToInt32(value).ToString();
            StatusText.Text = "Updating Panda 3rd-Party API ( " + str + "% Complete )";
        }

        private void PandaModuleDownload(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLoader.Value = e.ProgressPercentage;
            double value = ProgressLoader.Value;
            string str = Convert.ToInt32(value).ToString();
            StatusText.Text = "Updating Panda-Exploit A+ Client ( " + str + "% Complete )";
        }

        private void PandaWebAPIProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressLoader.Value = e.ProgressPercentage;
            double value = ProgressLoader.Value;
            string str = Convert.ToInt32(value).ToString();
            StatusText.Text = "Updating Updating Panda Web API ( " + str + "% Complete )";
        }
        /* -----------------------------------------------------------------------------  */

        public static readonly string DefaultCefSharpPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Panda.TechnologyCefSharp\\";
        public static readonly string DefaultLogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\PLogs\\";
        string gamegg = "https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Data/Membrane/PandaGameGUI.dll";
        string shadapi = "https://raw.githubusercontent.com/Shadow-Developer/ShadowApplicationProgrammingInterface/master/ShadowCheats.dll";
        string cefsharpapi = "https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Panda-Utilities/CefsharpUtilities/libcef.dll%20link";

        WebClient centrino = new WebClient();
        Animations anim = new Animations();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public Loader()
        {

            //if (!File.Exists("./bin/loader.wav"))
            //{

            //}
            try
            {
                InitializeComponent();
                ProgressLoader.Value = 0;
                StatusText.Text = "";
                Initialgoesbrr();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error: " + ex.Message);
            }

        }

        private async void Initialgoesbrr()
        {
            //player.SoundLocation = "Sound.wav";
            //player.Play();
            StatusText.Text = "Welcome to Panda A+ " + Properties.Settings.Default.PandaVersion;
            await Task.Delay(1509);
            //StatusText.Text = "Getting Latest Patches";
            //await Task.Delay(1509);
            //string versionlink = centrino.DownloadString("https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Data/PandaVersion"); //New Respiratory of Panda-Exploit
            //string update = Properties.Settings.Default.PandaVersion;
            //try
            //{
            //    if (versionlink.Contains(update))
            //    {
            //        StatusText.Text = "Currently using Latest-Patch";
            //        await Task.Delay(1509);
            //    }
            //    else
            //    {
            //        System.Windows.MessageBox.Show("Please Run Panda-Exploit Bootstrapper. A New Version of Panda-Exploit has been Detected");
            //        Environment.Exit(1);
            //    }
            //}
            //catch (Exception lol)
            //{
            //    System.Windows.MessageBox.Show("Unable to Access Panda Technology Database, Please Check your Connectivity and Try Again");
            //    Environment.Exit(0);
            //}
            if(Properties.Settings.Default.Upgrade_CefSharp == false)
            {
                try
                {
                    if (Directory.Exists(DefaultCefSharpPath))
                    {
                        StatusText.Text = "Detected Old Temporary Files";
                        await Task.Delay(1509);
                        StatusText.Text = "Deleting Old Temporary Files";
                        await Task.Delay(509);
                        Directory.Delete(DefaultCefSharpPath, true);
                    }
                }
                catch (Exception)
                {

                }
            }
            anim.Fade(ProgressLoader);
            try
            {
                /* -----------------------------------------------------------------------------  */
                StatusText.Text = "Updating Panda Game-Hub Service";
                await Task.Delay(1509);
                WebClient webClient = new WebClient();
                webClient.Proxy = null;
                string destFile = "PandaGameGUI.dll";
                webClient.DownloadFileCompleted += PandaModuleInitialDownload;
                webClient.DownloadProgressChanged += PandaGHubProgress;
                webClient.DownloadFileAsync(new Uri(gamegg), destFile);
                /* -----------------------------------------------------------------------------  */
            }
            catch (Exception lol)
            {
                System.Windows.MessageBox.Show("An Error has been Occurred [0x0001].\n + Error Code: " + lol.Message);
            }
        }

        private async void PandaModuleInitialDownload(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                await Task.Delay(2509);
                ProgressLoader.Value = 0;
                StatusText.Text = "Updating Panda-Exploit A+ Client";
                await Task.Delay(1509);
                WebClient webClient = new WebClient();
                webClient.Proxy = null;
                string sourceFile = "https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Modules/Panda_BytecodeConv.dll";
                string destFile = "Panda_BytecodeConv.dll";
                webClient.DownloadFileCompleted += Panda3rdInitial;
                webClient.DownloadProgressChanged += PandaModuleDownload;
                webClient.DownloadFileAsync(new Uri(sourceFile), destFile);
            }
            catch (Exception lol)
            {
                System.Windows.MessageBox.Show("Unable to Download the File, Please See the Log");
                Environment.Exit(0);
            }
        }


        /* -------------------------------------------------------------------------------------------------------------------------------------- */

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        string pandainstance = "https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Panda-Utilities/RobloxMultiInstanceApp.exe";
        string robloxplayerurl = "https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Panda-Utilities/RobloxPlayerLauncher.exe";
        string msvs2015url = "";


        private async void Panda3rdInitial(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (!File.Exists("discord-rpc-w32.dll"))
                {
                    new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/679526951068893187/688753204111867985/discord-rpc-w32.dll", "discord-rpc-w32.dll");
                }
                if (!Directory.Exists("Scripts"))
                {
                    Directory.CreateDirectory("Scripts");
                    string scriptzen = "https://raw.githubusercontent.com/SkieAdmin/Panda-Technology-Github/master/Panda-Core/scripts.zip";
                    string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                    centrino.DownloadFile(scriptzen, path + "Script.core");
                    ZipFile.ExtractToDirectory(path + "Script.core", path + "/Scripts");
                }
                if (!Directory.Exists("Bin"))
                {
                    Directory.CreateDirectory("Bin");
                }
                if (!Directory.Exists("workspace"))
                {
                    Directory.CreateDirectory("workspace");
                }
                WebClient webClient = new WebClient();
                if (!Directory.Exists("Tools"))
                {
                    Directory.CreateDirectory("Tools");
                }

                // Panda Multi-Instance
                if (!File.Exists("./Tools/PandaInstance.exe"))
                {
                    webClient.DownloadFile(pandainstance, "./Tools/PandaInstance.exe");
                }
                // Roblox Player
                if (!File.Exists("./Tools/RobloxPlayerLauncher.exe"))
                {
                    webClient.DownloadFile(robloxplayerurl, "./Tools/RobloxPlayerLauncher.exe");
                }
                //// Microsoft C++ Redistribution 2015
                //if (!File.Exists("./Tools/MS_VS2015.exe"))
                //{
                //	webClient.DownloadFile(msvs2015url, "MS_VS2015.exe");
                //}
                if (Properties.Settings.Default.Upgrade_CefSharp == false)
                {
                    Properties.Settings.Default.Upgrade_CefSharp = true;
                    Properties.Settings.Default.Save();
                }
                StatusText.Text = "Thank you for your Patience, We're loading up Panda-Exploit";
                await Task.Delay(2500);
                Main_Interface.Panda_Executor val = new Main_Interface.Panda_Executor();
                val.Show();
                base.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detail, Please Send this to SkieHacker / Panda Community:" + ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
