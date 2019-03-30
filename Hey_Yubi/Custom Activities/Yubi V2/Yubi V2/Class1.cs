using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;

namespace Yubi_V2
{
    public class FamiliarWordFixMethod : CodeActivity
    {
        [Category("Input")]
        public InArgument<string> Word { get; set; }

        [Category("Output")]
        public OutArgument<string> Fixedupword {get; set;}

        protected override void Execute(CodeActivityContext context)
        {
            string word = Word.Get(context);
            if (word == "right" || word == "wright" || word == "bright"
                || word == "byte" || word == "fright" || word == "plight"
                || word == "sleight" || word == "white" || word == "wight")
            {
                Fixedupword.Set(context, "write");
                return;
            }
            if (word == "bell" || word == "bel" || word == "quell"
                || word == "pell" || word == "stell" || word == "sell"
                || word == "swell" || word == "stele" || word == "tell")
            {
                Fixedupword.Set(context, "spell");
                return;
            }
            if (word == "beak" || word == "bleak" || word == "cheek"
                || word == "geek" || word == "peek" || word == "freak"
                || word == "seek" || word == "sleek" || word == "streak"
                || word == "week" || word == "squeak" || word == "shiek"
                || word == "sneak" || word == "tweak" || word == "week")
            {
                Fixedupword.Set(context, "speak");
                return;
            }
            Fixedupword.Set(context, word);
        }
    }
    public class FamiliarWordFixMethod_pt2 : CodeActivity
    {
        [Category("Input")]
        public InArgument<string> Word { get; set; }

        [Category("Output")]
        public OutArgument<string> Fixedupword { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string word = Word.Get(context);
            //Next
            if (word == "checks" || word == "nex" || word == "dex"
                || word == "ex" || word == "fecks" || word == "decks"
                || word == "necks" || word == "vex" || word == "mex" || word == "next"){
                Fixedupword.Set(context, "next");
                return;
            }
            //back
            if (word == "ack" || word == "bak" || word == "braque"
                || word == "jack" || word == "hack" || word == "bakke"
                || word == "backe" || word == "brack" || word == "akc" || word == "back"){
                Fixedupword.Set(context, "back");
                return;
            }
            //play
            if (word == "bay" || word == "clay" || word == "fay" 
                || word == "day" || word == "hay"|| word == "lay"
                || word == "neigh" || word == "pray" || word == "prey" || word == "play"){
                Fixedupword.Set(context, "play");
                return;
            }
            if (word == "exit")
            {
                Fixedupword.Set(context, "play");
                return;
            }
            //exit does not need one
            Fixedupword.Set(context, "word"); //prevents crash
        }
    }
    public class RetrieveAPIKey : CodeActivity
    {
        [Category("Output")]
        public OutArgument<string> ApiKey { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //sql code
            string key = "";
            string connSTR = "server=team52truii.heliohost.org;user=truii52_manager;database=truii52_DB;port=3306;password=Midori";

            try
            {
                MySqlConnection conn = new MySqlConnection(connSTR);
                conn.Open();
                string sql = "SELECT * FROM truii52_DB.ProjectKeys WHERE Name=\"YoutubeAPI\"";
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
            ApiKey.Set(context, key);
        }
    }
    public class ImageUrlToImage : CodeActivity
    {
        [Category("Input")]
        public InArgument<string> ImageUrl { get; set; }

        [Category("Output")]
        public OutArgument<Image> ImageResult { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string imageurl = ImageUrl.Get(context);
            WebClient client = new WebClient();
            byte[] imagebyte = client.DownloadData(imageurl);
            MemoryStream stream = new MemoryStream(imagebyte);
            Image img = Image.FromStream(stream);
            ImageResult.Set(context, img);

        }
    }

    public class StartBrowser : CodeActivity
    {
        [Category("Input")]
        public InArgument<string> Url { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string url = Url.Get(context);
            ProcessStartInfo web = new ProcessStartInfo(url);
            Process.Start(web);
        }
    }
}
