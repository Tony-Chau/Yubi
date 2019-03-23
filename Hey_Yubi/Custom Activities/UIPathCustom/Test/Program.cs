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

/// <summary>
/// The Test file is there to help me what program is needed 
/// </summary>

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Form frm = new Form();
            PictureBox pb = new PictureBox();
            Label l = new Label();
            l.Text = "Green";
            Application.Run(frm);
            
            Application.Exit();
            Console.ReadKey();
        }

    }
}
