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
using MySql.Data.MySqlClient;

/// <summary>
/// The Test file is there to help me what program is needed 
/// </summary>

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //sql code
            string key = "";
            string connSTR = "server=team52truii.heliohost.org;user=truii52_project;database=truii52_Keys;port=3306;password=Release";

            try
            {
                MySqlConnection conn = new MySqlConnection(connSTR);
                conn.Open();
                //Name ApiKey ApiSecret
                string sql = "SELECT * FROM truii52_Keys.Project WHERE Name=\"Youtube\"";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    key = rdr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine(key);

            Console.ReadKey();
        }

    }
}


