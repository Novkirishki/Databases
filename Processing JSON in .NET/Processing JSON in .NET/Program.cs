namespace Processing_JSON_in.NET
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            //Using JSON.NET and the Telerik Academy Youtube RSS feed, implement the following:

            //1.The RSS feed is located at https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw
            //Download the content of the feed programatically
            //    You can use WebClient.DownloadFile()

            var webClient = new WebClient();
            webClient.DownloadFile("https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw", "../../../academy_feed.xml");

            //2.Parse the XML from the feed to JSON
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../academy_feed.xml");

            var json = JsonConvert.SerializeXmlNode(doc);

            //3.Using LINQ-to - JSON select all video titles and print them on the console
            var jsonObj = JObject.Parse(json);

            Console.OutputEncoding = new UTF8Encoding();
            Console.WriteLine("Videos in rss:");

            var videoTitles = jsonObj["feed"]["entry"].
                Select(e => e["title"]); ;

            foreach (var title in videoTitles)
            {
                Console.WriteLine(title);
            }

            //4.Parse the videos' JSON to POCO
            var videos = new List<Video>();

            var videosInJson = jsonObj["feed"]["entry"];

            foreach (var video in videosInJson)
            {
                var poco = JsonConvert.DeserializeObject<Video>(video.ToString());
                videos.Add(poco);
            }

            //5.Using the POCOs create a HTML page that shows all videos from the RSS
            StringBuilder html = new StringBuilder();

            html.Append("<!DOCTYPE html><html><body>");

            foreach (var video in videos)
            {
                html.AppendFormat("<div style=\"text-align:center; \"> " +
                                  "<h1><a href=\"{0}\">{2}</a></h1>" +
                                  "<iframe width=\"720\" height=\"480\" " +
                                  "src=\"http://www.youtube.com/embed/{1}?autoplay=0\" " +
                                  "frameborder=\"0\" allowfullscreen></iframe></div>",
                                  video.Link.Href, video.Id, video.Title);
            }

            html.Append("</body></html>");

            using (StreamWriter writer = new StreamWriter("../../../videos.html", false, Encoding.UTF8))
            {
                writer.Write(html);
            }
        }
    }
}
