using System;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace __UI_____Panda_A_.Loader
{
    /// <summary>
    /// Interaction logic for Wush.xaml
    /// </summary>
    public partial class Wush : Window
    {
        Core.User_Level.Animations lol = new Core.User_Level.Animations();

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsDebuggerPresent();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        public Wush()
        {
            //Anti debugger security
            bool IsDebuggingPresent = false;
            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref IsDebuggingPresent);

            IntPtr kernel32 = LoadLibrary("kernel32.dll");
            IntPtr GetProcessId = GetProcAddress(kernel32, "IsDebuggerPresent");

            byte[] data = new byte[1];
            System.Runtime.InteropServices.Marshal.Copy(GetProcessId, data, 0, 1);

            //if (data[0] == 0xE9)
            //{
            //    Environment.Exit(0);
            //}

            //if (IsDebuggerPresent())
            //{
            //    Environment.Exit(0);
            //}

            //if (Debugger.IsAttached)
            //{
            //    Environment.Exit(0);
            //}
            InitializeComponent();
            designMethods = new Loader();
            rand = new Random();
        }

        private readonly Loader designMethods;
        private readonly Random rand;
        private bool loading = true;
        //private Discord.EventHandlers handlers;
        //private Discord.RichPresence presence;
        private string Version = "3.1.3A";
        private TimeSpan duration { get; set; } = TimeSpan.FromSeconds(1);
        private IEasingFunction ease { get; set; } = new QuarticEase { EasingMode = EasingMode.EaseInOut };
        public void Shift(DependencyObject element, Thickness from, Thickness to)
        {
            ThicknessAnimation shiftAnimation = new ThicknessAnimation()
            {
                From = from,
                To = to,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(shiftAnimation, element);
            Storyboard.SetTargetProperty(shiftAnimation, new PropertyPath(MarginProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(shiftAnimation);
            //storyboard.FillBehavior = FillBehavior.Stop;
            storyboard.Begin();
        }

        public void Resize(DependencyObject element, double height, double width)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation()
            {
                From = (double)element.GetValue(ActualHeightProperty),
                To = height,
                Duration = duration,
                EasingFunction = ease
            };

            DoubleAnimation widthAnimation = new DoubleAnimation()
            {
                From = (double)element.GetValue(ActualWidthProperty),
                To = width,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(heightAnimation, element);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(HeightProperty));

            Storyboard.SetTarget(widthAnimation, element);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(heightAnimation);
            storyboard.Children.Add(widthAnimation);
            //storyboard.FillBehavior = FillBehavior.Stop;
            storyboard.Begin();
        }
        private async void SplashScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            //DiscordRpc
            //presence.details = "Darked (Beta)";
            //presence.state = "Version: " + Version;
            //presence.largeImageKey = "1";
            //presence.largeImageText = "Created by Void, Trollicus and Versage.";
            //presence.smallImageKey = "2";
            //presence.smallImageText = "";
            //string clientId = "734377438439800833";
            //bool isNumeric = ulong.TryParse(clientId, out ulong n);
            //if (!isNumeric)
            //{
            //    return;
            //}

            //this.Initialize(clientId);

            // do all loading here //
            new Thread(async () =>
            {
                Thread.CurrentThread.IsBackground = true;
                string hexFrom = "#FFFFFF";
                string hexTo = $"#{rand.Next(0x1000000):X6}";
                while (loading)
                {
                    var @from = hexFrom;
                    var to = hexTo;
                    hexFrom = hexTo;
                    hexTo = $"#{rand.Next(0x1000000):X6}";
                    await Task.Delay(900);
                }
            }).Start();
            foreach (FrameworkElement element in logos.Children)
            {

                lol.Fade(element);
            }
            Shift(loadLogo, loadLogo.Margin, new Thickness(262, 62, 262, 98));
            Shift(loadText, loadText.Margin, new Thickness(270, 248, 255, 60));
            Shift(statusText, statusText.Margin, new Thickness(0, 255, 0, 20));
            await Task.Delay(500);
            Resize(loadEllipse, 300, 300);

            //Discord.UpdatePresence(ref presence);
            //handlers = new Discord.EventHandlers();
            //Discord.Initialize(clientId, ref handlers, true, null);
            //Application name
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[10];
            var random2 = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random2.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            this.Title = (finalString);

            statusText.Content = "Version: " + Properties.Settings.Default.PandaVersion;

            await Task.Delay(1000);
            Shift(loadLogo, loadLogo.Margin, new Thickness(262, 42, 262, 118));
            Shift(loadText, loadText.Margin, new Thickness(270, 228, 255, 80));
            Shift(statusText, statusText.Margin, new Thickness(0, 235, 0, 40));
            foreach (FrameworkElement element in logos.Children)
            {
                lol.FadeOut(element);
            }
            Resize(loadEllipse, 1000, 1000);
            await Task.Delay(900);
            loading = false;
            //Clean up and close
            GC.Collect();
            //
            Loader exploit = new Loader();
            exploit.Show();
            Close();
        }

        private void Initialize(string clientId)
        {
            //handlers = new Discord.EventHandlers();
            //Discord.Initialize(clientId, ref handlers, true, null);
        }
    }
}
