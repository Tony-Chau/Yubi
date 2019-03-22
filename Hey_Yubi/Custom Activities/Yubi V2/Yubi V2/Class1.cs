using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Youtube; //My file

namespace Yubi_V2
{
    public class RetrieveAPIKey : CodeActivity
    {
        [Category("Output")]
        public OutArgument<string> ApiKey { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //sql code
            string key = "";
            string connSTR = "server=team52truii.heliohost.org;user=truii52_manager;database=truii52_DB;port=3306;password=Midori";
            MySqlConnection conn = new MySqlConnection(connSTR);
            try
            {
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

    public class YoutubeSearch : CodeActivity
    {
        [Category("Input")]
        public InArgument<string> Search { get; set; }

        [Category("Input")]
        public InArgument<string> ApiKey { get; set; }

        [Category("Output")]
        public OutArgument<string> Json { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string search = Search.Get(context);
            string apikey = ApiKey.Get(context);
            YoutubeSearcherClass searchclass = new YoutubeSearcherClass(search, apikey);
            string json = searchclass.GetSearchResult();
            Json.Set(context, json);
        }

    }
}
