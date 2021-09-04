using __UI_____Panda_A_.Core.User_Level;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml;

namespace __UI_____Panda_A_.Main_Interface.Development
{
    /// <summary>
    /// Interaction logic for Beta_MainUI.xaml
    /// </summary>
    public partial class Beta_MainUI : Window
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsDebuggerPresent();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        private string Version = "Panda A+ v17.1";
        public static string exploitdllname = "Impact.dll";
        private bool injected = false;
        //public DiscordRpcClient client;

        public Beta_MainUI()
        {
            InitializeComponent();
            //Cleanup
            GC.Collect();
            //
            InitializeComponent();
            //Application name

            //Version//
            //LabelVersion.Content = Version;
            //
            try
            {
                FileSystemWatcher watcher = new FileSystemWatcher(AppDomain.CurrentDomain.BaseDirectory + "Scripts");

                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;

                watcher.Changed += Watcher_Changed;
                watcher.Created += Watcher_Created;
                watcher.Deleted += Watcher_Deleted;
                watcher.Renamed += Watcher_Renamed;
            }
            catch (Exception)
            {
                //output.Document.Blocks.Clear();
                //output.Document.Blocks.Add(new Paragraph(new Run("Watcher failed.")));
            }
            //Avalon Editor//
            //{
            //    var assembly = Assembly.GetExecutingAssembly();
            //    using (Stream s = assembly.GetManifestResourceStream("Darked.data.xshd"))
            //    {
            //        using (XmlTextReader reader = new XmlTextReader(s))
            //        {
            //            textEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    output.Document.Blocks.Clear();
            //    output.Document.Blocks.Add(new Paragraph(new Run("Syntax data failed to load.")));
            //}

            //Garbage collection
            GC.Collect();
            ////Discord joiner
            //try
            //{
            //    if ((bool)Properties.Settings.Default["FirstStart"] == true)
            //    {
            //        Process.Start("discord:///DcpTBB5");
            //        Properties.Settings.Default["FirstStart"] = false;
            //        Properties.Settings.Default.Save();
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Darked ran into a error inviting you to our discord server.");
            //    Environment.Exit(0);
            //}
            //Load scriptlist for launch
            Reload();
            //
        }

        public void Reload()
        {
            //try
            //{
            //    this.Dispatcher.Invoke(() =>
            //    {
            //        Listbox1.Items.Clear();
            //        PopulateListBox(Listbox1, (AppDomain.CurrentDomain.BaseDirectory + "Scripts"), "*.txt");
            //        PopulateListBox(Listbox1, (AppDomain.CurrentDomain.BaseDirectory + "Scripts"), "*.lua");
            //    });
            //}
            //catch (Exception)
            //{
            //    output.Document.Blocks.Clear();
            //    output.Document.Blocks.Add(new Paragraph(new Run("Scriptlist failed to load.")));
            //}
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Reload();
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Reload();
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Reload();
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Reload();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public static void PopulateListBox(ListBox LuaScripts, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                LuaScripts.Items.Add(file.Name);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Discord.Shutdown();
            Environment.Exit(0);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //UI.Credits credits = new UI.Credits();
            //credits.Show();
        }

        private void Attach_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ExecuteItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void ReloadItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //output.Document.Blocks.Clear();
            //output.Document.Blocks.Add(new Paragraph(new Run("Not accessible for public yet.")));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Settings.Panda_Settings settings = new Settings.Panda_Settings();
            settings.Show();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetPrivateProfileStringA", ExactSpelling = true, SetLastError = true)]
        private static extern int GetPrivateProfileString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpKeyName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDefault, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpReturnedString, int nSize, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WaitNamedPipe(string name, int timeout);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WritePrivateProfileStringA", ExactSpelling = true, SetLastError = true)]
        private static extern int WritePrivateProfileString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpKeyName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);

        private int Inject(string dllName)
        {
            //{
            //    Process process = Process.GetProcessesByName("RobloxPlayerBeta")[0];
            //    if (process != null)
            //    {
            //        if (process.MainWindowHandle.ToInt32() != 0)
            //        {
            //            output.Document.Blocks.Clear();
            //            output.Document.Blocks.Add(new Paragraph(new Run("Injecting...")));
            //            IntPtr hProcess = MainWindow.OpenProcess(1082, false, process.Id);
            //            IntPtr procAddress = MainWindow.GetProcAddress(MainWindow.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            //            IntPtr intPtr = MainWindow.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), 12288u, 4u);
            //            MainWindow.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out UIntPtr uintPtr);
            //            MainWindow.CreateRemoteThread(hProcess, IntPtr.Zero, 0u, procAddress, intPtr, 0u, IntPtr.Zero);
            //            output.Document.Blocks.Clear();
            //            output.Document.Blocks.Add(new Paragraph(new Run("Injecting...\nConnected to client.")));
            //        }
            //    }
            //}
            return 0;
        }

        private void Attach_Click(object sender, RoutedEventArgs e)
        {
            //Injector//
            //try
            //{
            //    if (injected == true)
            //    {
            //        output.Document.Blocks.Clear();
            //        output.Document.Blocks.Add(new Paragraph(new Run("Already injected into client.")));
            //    }
            //    else
            //    {
            //        Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            //        if (pname.Length == 0)
            //        {
            //            output.Document.Blocks.Clear();
            //            output.Document.Blocks.Add(new Paragraph(new Run("Could not find client.")));
            //        }
            //        else
            //        {
            //            Process process = Process.GetProcessesByName("RobloxPlayerBeta")[0];
            //            if (process != null)
            //            {
            //                Inject(AppDomain.CurrentDomain.BaseDirectory + "/Darked.dll");
            //                injected = true;
            //                output.Document.Blocks.Clear();
            //                output.Document.Blocks.Add(new Paragraph(new Run("Injected into client.")));
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    output.Document.Blocks.Clear();
            //    output.Document.Blocks.Add(new Paragraph(new Run("An error occurred on injecting.")));
            //}
            //
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                //Pipes.OutputPipe(textEditor.Text);
            }
            catch (Exception)
            {
                //output.Document.Blocks.Clear();
                //output.Document.Blocks.Add(new Paragraph(new Run("An error occurred on executing.")));
            }
        }

        private void LabelVersion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
