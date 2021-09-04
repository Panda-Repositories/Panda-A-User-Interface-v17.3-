using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using PandaGameGUI;
using Microsoft.Win32;
using Garbage.Collector;

namespace __UI_____Panda_A_.Main_Interface
{
	/// <summary>
	/// Interaction logic for Panda_Executor.xaml
	/// </summary>
	/// 
	public partial class Panda_Executor : Window
	{
		DispatcherTimer dispatcherTimer = new DispatcherTimer();
		WebClient oc = new WebClient();
		WebClient web = new WebClient();
		public GarbageCollector garbageCollector = new GarbageCollector();
		public Panda_Executor()
		{
			try
			{
				InitializeComponent();
				//garbageCollector.StartCollecting();
				GC.Collect();
				var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
				var stringChars = new char[10];
				var random2 = new Random();
				for (int i = 0; i < stringChars.Length; i++)
				{
					stringChars[i] = chars[random2.Next(chars.Length)];
				}
				var finalString = new String(stringChars);
				this.Title = (finalString);
				if (!Environment.Is64BitOperatingSystem)
				{
					MessageBox.Show("Panda A+ won't Support 32-bit Operating System");
					senderror("Error", "Detected using 32-bit Operating System");
					Environment.Exit(0);
				}
				dispatcherTimer.Tick += new EventHandler(ExploitStatus);
				dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
				dispatcherTimer.Start();

				TabItem tabItem = new TabItem();
				TextEditor textEditor = new TextEditor();
				tabItem.Header = "Script";
				tabItem.Content = textEditor;
				Tabs.Items.Add(tabItem);
				textEditor.FontFamily = new FontFamily("Consolas");
				textEditor.FontSize = 13.333;
				textEditor.Background = Brushes.Transparent; /*new SolidColorBrush(Color.FromRgb(20, 20, 20))*/;
				textEditor.LineNumbersForeground = new SolidColorBrush(Color.FromRgb(33, 33, 33));
				textEditor.Foreground = new SolidColorBrush(Color.FromRgb(235, 235, 235));
				textEditor.ShowLineNumbers = true;

				byte[] byteArray = Encoding.UTF8.GetBytes(web.DownloadString("https://raw.githubusercontent.com/SkieAdmin/Panda-Technology-Github/master/Panda-Core/lua.xshd"));
				MemoryStream stream = new MemoryStream(byteArray);
				Stream input = stream;
				textEditor.Text = "--Panda-Exploit A+ --\nprint('hellow')";
				XmlTextReader xmlTextReader = new XmlTextReader(input);
				textEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlTextReader, HighlightingManager.Instance);
				textEditor.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
				textEditor.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
				textEditor.Options.EnableHyperlinks = false;
				textEditor.Options.ShowSpaces = false;
				textEditor.Options.ShowTabs = false;
				textEditor.Name = tabItem.Header.ToString();
				tabItem.IsSelected = true;
				Load(this.Viewer, "./scripts", "*.txt");
				Load(this.Viewer, "./scripts", "*.lua");
				//Load(this.VideoFiles, "./Bin/media", "*.mp4");


				senderror("Info", "Successfully Loaded at Main Level ( Lua Executor )");
				myMediaElement.Volume = (double)Properties.Settings.Default.Volume;

			}
			catch (Exception whatiserror)
			{
				MessageBox.Show("Fatal Error on Panda-Exploit A+ has been detected and it forced to close.\nError Details: " + whatiserror.Message + "\n\nPress OK to copy the Error Details and Close Panda-Exploit A+.");
				senderror("Error", whatiserror.Message);
				Environment.Exit(-1);
			}
		}

		public static void Load(ListBox listb, string folder, string fileType)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folder);
			FileInfo[] files = directoryInfo.GetFiles(fileType);
			foreach (FileInfo fileInfo in files)
			{
				listb.Items.Add(fileInfo.Name);
			}
		}


		private void senderror(string msgtype, string msghere)
		{

		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			if (Tabs.Items.Count == 1)
			{
				return;
			}
			else
			{
				Tabs.Items.Remove(Tabs.SelectedItem);
			}
		}

		private void AddTabButton_Click(object sender, RoutedEventArgs e)
		{
			bool flag = Tabs.Items.Count == 9;
			if (!flag)
			{
				TabItem tabItem = new TabItem();
				TextEditor textEditor = new TextEditor();
				tabItem.Header = "Script";
				tabItem.Content = textEditor;
				Tabs.Items.Add(tabItem);
				textEditor.FontFamily = new FontFamily("Consolas");
				textEditor.FontSize = 13.333;
				textEditor.Background = Brushes.Transparent; /*new SolidColorBrush(Color.FromRgb(20, 20, 20))*/;
				textEditor.LineNumbersForeground = new SolidColorBrush(Color.FromRgb(33, 33, 33));
				textEditor.Foreground = new SolidColorBrush(Color.FromRgb(235, 235, 235));
				textEditor.ShowLineNumbers = true;
				textEditor.Text = "--Panda-Exploit A+ --\nprint('hellow')";
				byte[] byteArray = Encoding.UTF8.GetBytes(web.DownloadString("https://raw.githubusercontent.com/SkieAdmin/Panda-Technology-Github/master/Panda-Core/lua.xshd"));
				MemoryStream stream = new MemoryStream(byteArray);
				Stream input = stream;
				XmlTextReader xmlTextReader = new XmlTextReader(input);
				textEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlTextReader, HighlightingManager.Instance);
				textEditor.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
				textEditor.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
				textEditor.Options.EnableHyperlinks = false;
				textEditor.Options.ShowSpaces = false;
				textEditor.Options.ShowTabs = false;
				textEditor.Name = tabItem.Header.ToString();
				tabItem.IsSelected = true;
			}
		}

		//private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
		//{
		//	myMediaElement.Volume = (double)volumeSlider.Value;
		//}

		public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
		{
			int i = 0;
			while (i < VisualTreeHelper.GetChildrenCount(parent))
			{
				DependencyObject child = VisualTreeHelper.GetChild(parent, i);
				bool flag = child != null && child is T;
				T result;
				if (flag)
				{
					result = (T)((object)child);
				}
				else
				{
					T t = FindVisualChild<T>(child);
					bool flag2 = t != null;
					if (!flag2)
					{
						i++;
						continue;
					}
					result = t;
				}
				return result;
			}
			return default(T);
		}


		private void PandaExecuteScript(string script)
		{
			if (Properties.Settings.Default.LastDLL == "PandaTechnology")
			{

				Core.Injection_Level.NamedPipes.LuaPipe(script);

			}
			else if (Properties.Settings.Default.LastDLL == "DLL-Test")
			{
				Core.Injection_Level.DLLTester.LuaPipe(script);
			}
		}

		private DispatcherTimer dispatcher = new DispatcherTimer();

		private void Clearbtn_Click(object sender, RoutedEventArgs e)
		{
			TextEditor textEditor = FindVisualChild<TextEditor>(this.Tabs);
			textEditor.Clear();
		}

		private void Openbtn_Click(object sender, RoutedEventArgs e)
		{
			TextEditor textEditor = FindVisualChild<TextEditor>(this.Tabs);
			System.Windows.Forms.OpenFileDialog openfile = new System.Windows.Forms.OpenFileDialog()
			{
				CheckFileExists = true,
				Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt|All files (*.*)|*.*"
			};

			if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				textEditor.Text = File.ReadAllText(openfile.FileName);
			}
		}

		private void Savebtn_Click(object sender, RoutedEventArgs e)
		{
			TextEditor TextEditor = FindVisualChild<TextEditor>(Tabs);
			System.Windows.Forms.SaveFileDialog savefile = new System.Windows.Forms.SaveFileDialog()
			{
				Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt|All files (*.*)|*.*"
			};

			if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				File.WriteAllText(savefile.FileName, TextEditor.Text);
			}
		}

		private void Redobtn_Click(object sender, RoutedEventArgs e)
		{
			TextEditor textEditor = FindVisualChild<TextEditor>(this.Tabs);
			bool canRedo = textEditor.CanRedo;
			if (canRedo)
			{
				textEditor.Redo();
			}
		}

		private void Undobtn_Click(object sender, RoutedEventArgs e)
		{
			TextEditor textEditor = FindVisualChild<TextEditor>(this.Tabs);
			bool canUndo = textEditor.CanUndo;
			if (canUndo)
			{
				textEditor.Undo();
			}
		}

		private void Executebtn_Click(object sender, RoutedEventArgs e)
		{
			TextEditor textEditor = FindVisualChild<TextEditor>(this.Tabs);
			PandaExecuteScript(textEditor.Text);
		}

		private void Attachbtn_Click(object sender, RoutedEventArgs e)
		{
            if (Properties.Settings.Default.LastDLL == "PandaTechnology")
            {

				Core.Injection_Level.PandaManagement.Inject();

            }
            else if (Properties.Settings.Default.LastDLL == "DLL-Test")
            {
				Core.Injection_Level.DLLTester.AttachToRoblox();
                MessageBox.Show("Successfully Injected");
            }
        }

		private void Discordbtn_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("https://discord.me/nazicommunity");
		}

		private void Viewer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
            Window1 viewerMenu = new Window1();
            viewerMenu.Left = e.GetPosition(null).X - 12.0 + this.Left;
            viewerMenu.Top = e.GetPosition(null).Y - 12.0 + this.Top;
            viewerMenu.Show();
        }

		private void Exitbtn_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Environment.Exit(0);
		}

		private void Minimizebtn_MouseDown(object sender, MouseButtonEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void AutoClean(object sender, EventArgs e)
		{
			GC.Collect();
		}
		private void ExploitStatus(object sender, EventArgs e)
		{
            if (Properties.Settings.Default.LastDLL == "PandaTechnology")
            {
                Pandaa.Content = "Panda A+ [ Official ] " + Properties.Settings.Default.PandaVersion;
				if (Core.Injection_Level.NamedPipes.NamedPipeExist(Core.Injection_Level.BasicFunction.luapipename))
                {
                    PandaIsInjected.Content = "Inject Status: Injected";
                    PandaIsInjected.Foreground = Brushes.LimeGreen;
                }
                else
                {
                    PandaIsInjected.Content = "Inject Status: Not Injected";
                    PandaIsInjected.Foreground = Brushes.Red;
                }
            }
            else if (Properties.Settings.Default.LastDLL == "DLL-Test")
            {
                Pandaa.Content = "Panda A+ [ Test Mode ] " + Properties.Settings.Default.PandaVersion;
                if (Core.Injection_Level.DLLTester.NamedPipeExist(Properties.Settings.Default.DLLPipe))
                {
                    PandaIsInjected.Content = "Inject Status: Injected";
                    PandaIsInjected.Foreground = Brushes.LimeGreen;
                }
                else
                {
                    PandaIsInjected.Content = "Inject Status: Not Injected";
                    PandaIsInjected.Foreground = Brushes.Red;
                }
            }
        }

		private void GameGUIOpener(object sender, RoutedEventArgs e)
		{
			PandaGameGUI.Form1 lol = new PandaGameGUI.Form1();
			lol.Show();
		}

		private void SettingsOpen(object sender, RoutedEventArgs e)
		{
			Settings.Panda_Settings yawa = new Settings.Panda_Settings();
			yawa.Show();
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Sorry, Light Mode is not available yet");
		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{

		}


		List safePlayList = new List();
		private void VideoFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			myMediaElement.Source = new Uri(VideoFiles.SelectedItem.ToString());
			btn_play_Click(null, null);
		}


		/* -------------------------------------------------------------------------------------------------------------- */

		private void btn_pause_Click(object sender, RoutedEventArgs e)
		{
			myMediaElement.Pause();
		}

		private void btn_play_Click(object sender, RoutedEventArgs e)
		{
			myMediaElement.Play();

		}

		private void btn_stop_Click(object sender, RoutedEventArgs e)
		{
			myMediaElement.Stop();
		}

		//void timer_trick(object sender, EventArgs e)
		//{
		//	if ((myMediaElement.Source != null) && (myMediaElement.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
		//	{
		//		sli_movie.Minimum = 0;
		//		sli_movie.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
		//		sli_movie.Value = myMediaElement.Position.TotalSeconds;
		//	}
		//}

		//private void sli_movie_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		//{
		//	TimeSpan ts = TimeSpan.FromSeconds(e.NewValue);
		//	myMediaElement.Position = ts;
		//	lblProgressStatus.Text = TimeSpan.FromSeconds(sli_movie.Value).ToString(@"hh\:mm\:ss");

		//}

		//private void sli_sound_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		//{
		//	if (myMediaElement.Source != null)
		//	{
		//		myMediaElement.Volume = sli_sound.Value;
		//		lblVolume.Text = myMediaElement.Volume.ToString();
		//	}
		//}

		//private void myMediaElement_MediaOpened(object sender, RoutedEventArgs e)
		//{
		//	if (myMediaElement.NaturalDuration.HasTimeSpan)
		//	{
		//		TimeSpan ts = TimeSpan.FromMilliseconds(myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds);
		//		sli_movie.Maximum = ts.TotalSeconds;
		//		lblTotal.Text = ts.ToString(@"hh\:mm\:ss");
		//		media.Title = myMediaElement.Source.OriginalString;




		//	}

		//	sli_sound.Minimum = 0;
		//	sli_sound.Maximum = 100;
		//	sli_movie.Value = 50;
		//	myMediaElement.Volume = 50;
		//	lblVolume.Text = int.Parse(myMediaElement.Volume.ToString()).ToString();


		//}

		//private void sli_movie_DragStarted(object sender, DragStartedEventArgs e)
		//{
		//	myMediaElement.Pause();
		//	userIsDraggingSlider = true;

		//}

		//private void sli_movie_DragCompleted(object sender, DragCompletedEventArgs e)
		//{
		//	userIsDraggingSlider = false;
		//	myMediaElement.Position = TimeSpan.FromSeconds(sli_movie.Value);
		//	myMediaElement.Play();
		//}


		private void btn_addtolist_Click(object sender, RoutedEventArgs e)
		{
			//VideoLoad();
		}

		private void VideoLoad()
        {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.AddExtension = true;
			ofd.DefaultExt = "*.*";
			ofd.Filter = "Media Files (*.mp3;*.mpg;*.mpeg;*.MKV;*.mp4;*.MP4)|*.mp3;*.mpg;*.mpeg*.MKV;*.mp4;*.MP4|All files (*.*)|*.*";
			ofd.Multiselect = true;
			ofd.ShowDialog();
			try
			{
				foreach (var x in ofd.FileNames)
				{
					if (!VideoFiles.Items.Contains(x))
						VideoFiles.Items.Add(x);

				}
				if (myMediaElement.Source == null)
				{
					myMediaElement.Source = new Uri(ofd.FileName);
					VideoFiles.SelectedIndex = 0;
					btn_play_Click(null, null);
				}
			}
			catch (Exception ex)
			{
				new NullReferenceException("Error" + ex);
			}
		}

		private void listplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			myMediaElement.Source = new Uri(VideoFiles.SelectedItem.ToString());
			btn_play_Click(null, null);
		}

        private void OpenGameGUI_Copy3_Click(object sender, RoutedEventArgs e)
        {
			VideoLoad();
        }

        private void Viewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
