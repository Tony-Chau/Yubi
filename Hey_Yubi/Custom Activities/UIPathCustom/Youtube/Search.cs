using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;


namespace Youtube
{
    //code demo from https://developers.google.com/youtube/v3/code_samples/dotnet
    internal class Search
    {
        static void Main(string[] args)
        {
            Console.WriteLine("YouTube Data API: Search");
            Console.WriteLine("========================");
            try
            {
                new Search().Run().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            Console.ReadKey();
        }

        private async Task Run()
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
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = key,
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = "Pewdiepie"; // Your query. Literally your search
            searchListRequest.MaxResults = 50;

            //Call the search.list method to retrieve results matching the specific query term
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> vid = new List<string>();

            foreach (var SearchResult in searchListResponse.Items)
            {
                if (SearchResult.Id.Kind == "youtube#video")
                {
                    vid.Add(string.Format("{0} {1} ", SearchResult.Snippet.Title, SearchResult.Id.VideoId));

                }
            }

            Console.WriteLine(string.Format("Videos:\n{0}\n", string.Join("\n", vid)));
        }
    }
}
