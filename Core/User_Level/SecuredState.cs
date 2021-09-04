using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Management;

namespace __UI_____Panda_A_.Core.User_Level
{
	class PandaSecureState
	{
		public static string DeviceUsername = System.Environment.UserName;
		private DispatcherTimer debugTimer = new DispatcherTimer
		{
			Interval = new TimeSpan(0, 0, 5)
		};


		public bool PandaIsRedistInstalled()
		{
			string text = "SOFTWARE\\Classes\\Installer\\Dependencies";
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(text))
			{
				if (registryKey == null)
				{
					return false;
				}
				foreach (string item in from n in registryKey.GetSubKeyNames()
										where !n.ToLower().Contains("dotnet") && !n.ToLower().Contains("microsoft")
										select n)
				{
					using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey(text + "\\" + item))
					{
						string text2 = registryKey2.GetValue("DisplayName")?.ToString() ?? null;
						if (string.IsNullOrEmpty(text2) || !Regex.IsMatch(text2, "C\\+\\+ (2015|2017|2019).*\\(x86\\)"))
						{
							continue;
						}
						return true;
					}
				}
			}
			return false;
		}
	}
}
