using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace __UI_____Panda_A_.Core.Injection_Level
{
    class BasicFunction
    {
        public static string exploitdllname = "Panda_BytecodeConv.dll";
        public static string luapipename = "pandawinning";
        public static string puppy = "RBLXInjector.exe"; //Named of the Custom Injector you want
    }
    class PandaManagement
    {

        public async static void Inject()
        {
            if (Properties.Settings.Default.Panda_CustomInject == true)
            {
                /*It would use Puppy Injector in this case*/
                if (!File.Exists(BasicFunction.puppy))
                {
                    WebClient oc = new WebClient();
                    oc.DownloadFile("https://cdn.discordapp.com/attachments/784597168887300106/785011977973268510/PuppyMilkV3.exe", BasicFunction.puppy);
                }
                string filearg = AppDomain.CurrentDomain.BaseDirectory + BasicFunction.exploitdllname;
                Process.Start(BasicFunction.puppy, filearg);
                return;
            }
            if (NamedPipes.NamedPipeExist(BasicFunction.luapipename))//check if the pipe exist
            {
                MessageBox.Show("Already injected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//if the pipe exist that's mean that we don't need to inject
                return;
            }
            else if (!NamedPipes.NamedPipeExist(BasicFunction.luapipename))//check if the pipe don't exist
            {
                switch (Injector.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + BasicFunction.exploitdllname))//Process name and dll directory
                {
                    case Injector.DllInjectionResult.DllNotFound://if can't find the dll
                        MessageBox.Show($"Couldn't find {BasicFunction.exploitdllname}", "Dll was not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);//display messagebox to tell that dll was not found
                        return;
                    case Injector.DllInjectionResult.GameProcessNotFound://if can't find the process
                        MessageBox.Show("Couldn't find RobloxPlayerBeta.exe!", "Target process was not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);//display messagebox to tell that proccess was not found
                        return;
                    case Injector.DllInjectionResult.InjectionFailed://if injection fails(this don't work or only on special cases)
                        MessageBox.Show("Injection Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);//display messagebox to tell that injection failed
                        return;
                }
                await Task.Delay(3000);//pause the ui for 3 seconds
                if (NamedPipes.NamedPipeExist(BasicFunction.luapipename))//check if the pipe exist
                {
                    while (!NamedPipes.NamedPipeExist(BasicFunction.luapipename))
                    {

                    }
                    try
                    {
                        WebClient LEL = new WebClient();
                        Injection_Level.NamedPipes.LuaPipe(LEL.DownloadString("https://raw.githubusercontent.com/SkieAdmin/Panda-Respiratory/main/Welcome-Panda"));
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Injection Failed!\nMaybe you are Missing something\nor took more time to check if was ready\nor other stuff", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);//display that the pipe was not found so the injection was unsuccessful
                }

            }
        }
    }

    class NamedPipes
    {


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WaitNamedPipe(string name, int timeout);
        //function to check if the pipe exist
        public static bool NamedPipeExist(string pipeName)
        {
            try
            {
                if (!WaitNamedPipe($"\\\\.\\pipe\\{pipeName}", 0))
                {
                    int lastWin32Error = Marshal.GetLastWin32Error();
                    if (lastWin32Error == 0)
                    {
                        return false;
                    }
                    if (lastWin32Error == 2)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //lua pipe function
        public static void LuaPipe(string script)
        {
            if (NamedPipeExist(BasicFunction.luapipename))
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze or something
                {
                    try
                    {
                        using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", BasicFunction.luapipename, PipeDirection.Out))
                        {
                            namedPipeClientStream.Connect();
                            using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream, System.Text.Encoding.Default, 999999))//changed buffer to max 1mb since default buffer is 1kb
                            {
                                streamWriter.Write(script);
                                streamWriter.Dispose();
                            }
                            namedPipeClientStream.Dispose();
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error occured connecting to the pipe.", "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }).Start();
            }
            else
            {
                MessageBox.Show("Please Inject the Exploit First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
