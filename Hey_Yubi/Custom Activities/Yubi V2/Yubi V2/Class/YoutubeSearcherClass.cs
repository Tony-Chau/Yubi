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
using System.Web.Script.Serialization;

namespace Youtube
{
    internal class YoutubeSearcherClass
    {
        public List<SearchResult> response;
        private string key;
        private string search;

        public YoutubeSearcherClass()
        {
            //Will never be called. Pretty useless
        }

        public YoutubeSearcherClass(string search, string key)
        {
            search = this.search;
            key = this.key;
        }

        public string GetSearchResult()
        {
            new YoutubeSearcherClass().Run(search, key).Wait();
            var jsonSerialiser = new JavaScriptSerializer();
            return jsonSerialiser.Serialize(response);
        }

        private async Task Run(string search, string key)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = key,
                ApplicationName = this.GetType().ToString()
            });
            var searchlistRequest = youtubeService.Search.List("Snippet");
            searchlistRequest.Q = search;
            searchlistRequest.MaxResults = 20;

            var searchListResponse = await searchlistRequest.ExecuteAsync();

            List<SearchResult> vid = new List<SearchResult>();

            foreach (var SearchResult in searchListResponse.Items)
            {
                if (SearchResult.Id.Kind == "youtube#video")
                {
                    vid.Add(SearchResult);
                }
            }
            response = vid;
        }
    }
}