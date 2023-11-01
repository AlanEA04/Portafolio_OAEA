using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using Portafolio_OAEA.Models;


namespace Portafolios.Controllers
{
    public class VideoController : Controller
    {
        private string key = "AIzaSyDNexATyzkbRRkF3CCoAxf8EJuyy5eum2Q";

        public ActionResult VistaYoutube()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(string searchTerm)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = key,
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchTerm;
            searchListRequest.MaxResults = 50;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<YoutubeModel> listaVideos = new List<YoutubeModel>();
            foreach (var searchResult in searchListResponse.Items)
            {
                listaVideos.Add(new YoutubeModel()
                {
                    VideoId = searchResult.Id.VideoId,
                    Titulo = searchResult.Snippet.Title,
                    ImageUrl = searchResult.Snippet.Thumbnails.Medium.Url
                });
            }

            return View("VistaYoutube", listaVideos);
        }
    }
}