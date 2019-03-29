using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.IO;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

/// <summary>
/// The Test file is there to help me what program is needed 
/// </summary>

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetStandardBrowserPath());
            string url = "http://google.de";
            string browserPath = GetStandardBrowserPath();
            if (string.IsNullOrEmpty(browserPath))
            {
                MessageBox.Show("No default browser found!");
            }
            else
            {
                Process.Start(browserPath, url);
            }
            Console.ReadKey();
        }
        //Testing code from https://en.code-bude.net/2013/04/28/how-to-retrieve-default-browsers-path-in-c/
        private static string GetStandardBrowserPath()
        {
            string browserPath = string.Empty;
            RegistryKey browserKey = null;

            try
            {
                //Read default browser path from Win XP registry key
                browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                //If browser path wasn't found, try Win Vista (and newer) registry key
                if (browserKey == null)
                {
                    browserKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
                }

                //If browser path was found, clean it
                if (browserKey != null)
                {
                    //Remove quotation marks
                    browserPath = (browserKey.GetValue(null) as string).ToLower().Replace("\"", "");

                    //Cut off optional parameters
                    if (!browserPath.EndsWith("exe"))
                    {
                        browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                    }

                    //Close registry key
                    browserKey.Close();
                }
            }
            catch
            {
                //Return empty string, if no path was found
                return string.Empty;
            }
            //Return default browsers path
            return browserPath;
        }

    }


}


