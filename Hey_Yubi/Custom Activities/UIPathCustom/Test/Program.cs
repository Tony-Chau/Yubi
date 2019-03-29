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
using System.Web;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net.Http;

/// <summary>
/// The Test file is there to help me what program is needed 
/// </summary>

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://example.com/");
            Process.Start(sInfo);

            Console.ReadKey();
        }

    }
}


