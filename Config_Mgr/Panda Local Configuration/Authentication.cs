using System;
using System.Collections.Specialized;
using System.Net;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Windows;
using System.Management;

namespace Panda_Local_Configuration
{
    public class Authentication
    {

        public static readonly string DefaultCefSharpPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Panda.TechnologyCefSharp\\";

        public void OpenCore()
        {
            if (Properties.Settings.Default.PandaExternalSite == true)
            {
                Process.Start("https://pandacheat.weebly.com/pandacheckpoint1.html");
            }
            else
            {

                if (!File.Exists(DefaultCefSharpPath + "PandaWebAPI.exe"))
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("The Following File is currently Missing ( PandaWebAPI ), We Recommended you to Reset Panda Bin-Folder on the following path.\n" + "Panda Cefsharp Directory:" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\n\n Do you want to Reset this Folder?", "Panda-Exploit A+", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            try
                            {
                                Directory.Delete(DefaultCefSharpPath);
                                MessageBox.Show("Folder Reset, Panda-Exploit A+ will Restart", "Panda-Exploit A+");
                                Process.Start("Panda-Exploit A+.exe");
                                Environment.Exit(0);
                            }
                            catch (Exception MSG)
                            {
                                MessageBox.Show("Unable to Reset the Folder, Here is the Error Details:\n - " + MSG.Message, "Panda-Exploit A+");
                            }
                            break;
                    }
                    return;
                }
                try
                {
                    System.Diagnostics.Process.Start(DefaultCefSharpPath + "PandaWebAPI.exe", "-SecuredLauchExploit");
                    //Process.Start("./Bin/PandaWebAPI.exe", "-SecuredLauchExploit");
                }
                catch (Exception EX)
                {
                    System.Windows.MessageBox.Show("Error Occurred:" + EX.Message);
                }
            }
        }

    }
}
