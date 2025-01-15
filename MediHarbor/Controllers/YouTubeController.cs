using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;

namespace MediHarbor.Controllers
{
   
    public class YouTubeController : Controller
    {
        private static readonly string ApiKey = "AIzaSyBXevoeDQxHY0SbEjAYvyXBFS9W8pIU8m8"; 

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(string keyword)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = ApiKey,
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword;
            searchListRequest.MaxResults = 10; 

            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<VideoResult> videos = new List<VideoResult>();
            List<ChannelResult> channels = new List<ChannelResult>();
            List<PlaylistResult> playlists = new List<PlaylistResult>();

            
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(new VideoResult
                        {
                            Title = searchResult.Snippet.Title,
                            Id = searchResult.Id.VideoId
                        });
                        break;

                    case "youtube#channel":
                        channels.Add(new ChannelResult
                        {
                            Title = searchResult.Snippet.Title,
                            Id = searchResult.Id.ChannelId
                        });
                        break;

                    case "youtube#playlist":
                        playlists.Add(new PlaylistResult
                        {
                            Title = searchResult.Snippet.Title,
                            Id = searchResult.Id.PlaylistId
                        });
                        break;
                }
            }

            
            ViewBag.Videos = videos;
            ViewBag.Channels = channels;
            ViewBag.Playlists = playlists;

            return View("Index"); 
        }
    }

    
    public class VideoResult
    {
        public string Title { get; set; }
        public string Id { get; set; }
    }

    public class ChannelResult
    {
        public string Title { get; set; }
        public string Id { get; set; }
    }

    public class PlaylistResult
    {
        public string Title { get; set; }
        public string Id { get; set; }
    }
}

