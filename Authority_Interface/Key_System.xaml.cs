using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Panda_Local_Configuration;
using SharpCompress.Archives;
using SharpCompress.Common;

namespace __UI_____Panda_A_.Authority_Interface
{
	/// <summary>
	/// Interaction logic for Key_System.xaml
	/// </summary>
	public partial class Key_System : Window
	{

        Core.User_Level.Animations anim = new Core.User_Level.Animations();
		public Key_System()
		{
        
            InitializeComponent();
            AuthPass();
            Topmost = true;
            anim.Fade(MainBorder);
			ObjectShift(MainBorder, MainBorder.Margin, new Thickness(59, 40, 0, 0));
			MainBorder.BringIntoView();
            anim.Fade(kek);
            try
            {
                WebClient webClient = new WebClient();
                string bulltype = webClient.DownloadString("https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Changelog");

                TextRange textRange = new TextRange(kek.Document.ContentStart, kek.Document.ContentEnd);
                textRange.Text = bulltype;

                //kek.Document.ContentEnd.Paragraph.Blocks.Add(para);
                //RichTextBox mcRTB = new RichTextBox();
                //mcRTB.Width = 560;
                //mcRTB.Height = 280;
                //// Set contents  
                //mcRTB.Document = mcFlowDoc;
                //// Add RichTextbox to the container  
                //ContainerPanel.Children.Add(mcRTB);

            }
            catch (Exception ex)
            {

            }
            if (Properties.Settings.Default.Panda_BypassKey == true)
            {
                InputBox.Text = "Click Continue already";
            }
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        public void ObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
        {
            ThicknessAnimation Animation = new ThicknessAnimation()
            {
                From = Get,
                To = Set,
                Duration = duration2,
                EasingFunction = Smooth,
            };
            Storyboard.SetTarget(Animation, Object);
            Storyboard.SetTargetProperty(Animation, new PropertyPath(MarginProperty));
            StoryBoard.Children.Add(Animation);
            StoryBoard.Begin();
        }
        Storyboard StoryBoard = new Storyboard();
        TimeSpan duration = TimeSpan.FromMilliseconds(500);
        TimeSpan duration2 = TimeSpan.FromMilliseconds(1000);
        DispatcherTimer dt = new DispatcherTimer();

        private IEasingFunction Smooth
        {
            get;
            set;
        }
= new QuarticEase
{
    EasingMode = EasingMode.EaseInOut
};

        private async void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ObjectShift(MainBorder, MainBorder.Margin, new Thickness(59, 150, 0, 0));
                anim.FadeOut(MainBorder);
                await Task.Delay(1100);
                Application.Current.Shutdown();
            }
        }

        private void Minimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                WindowState = WindowState.Minimized;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string key = InputBox.Text;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
            if (new WebClient().DownloadString("https://pandatechnology.xyz/KeySystemV1/check.php?key=" + key) != "Whitelisted")
            {
                System.Windows.MessageBox.Show("Invalid Key or Already Used Key");
                return;
            }
            AuthPass();
            //if (Properties.Settings.Default.Panda_BypassKey == true)
            //{
            //    AuthPass();
            //    return;
            //}
            //else if (RegisterPandaKey(key))
            //{
            //    System.Windows.MessageBox.Show("Welcome to Panda A+!");
            //    AuthPass();
            //    return;
            //}
            //else
            //{
            //    System.Windows.MessageBox.Show("Your not Authenticated / Wrong-Invalid Key.");
            //}
            //if (PandaDeveloper())
            //{
            //    AuthPass();
            //    return;
            //}


        }

        private void AuthPass()
        {
            Main_Interface.Panda_Executor val = new Main_Interface.Panda_Executor();
            val.Show();
            base.Close();
        }

        private void RetrieveKey_Click(object sender, RoutedEventArgs e)
        {
            WebClient web = new WebClient();
            Process.Start(web.DownloadString("https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Data/Key-Sys_URL"));
        }

        /*Because how stupid i can be, i just make settings on web */
        public static readonly string DefaultCefSharpPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Panda.TechnologyCefSharp\\";


        public static bool RegisterPandaKey(string key)
        {
            using (var client = new WebClient())
            {

                var values = new NameValueCollection();
                values["Request"] = "Checkfortoken";
                values["token"] = key;
                var response = client.UploadValues("https://pandatechnology.xyz/KeySystemV1/csharphandler.php", values);

                var responseString = Encoding.Default.GetString(response);
                //label1.Text = responseString;
                if (responseString == "Exists")
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }


        public static bool PandaDeveloper()
        {
            WebClient core = new WebClient();
            ManagementObjectSearcher mo = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject mob in mo.Get())
            {
                try
                {
                    string webkey = core.DownloadString("https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Data/BetaAccessID");
                    string penkey = mob["ProcessorId"].ToString();
                    if (webkey.Contains(penkey))
                    {
                        MessageBox.Show("Developer Key has been Detected on Server and to this PC. Welcome to Panda-Exploit A+");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)

                {

                    // handle exception

                }
            }
            return false;
        }
    }
}
