namespace Processing_JSON_in.NET
{
    using Newtonsoft.Json;

    public class Video
    {
        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("Link")]
        public Link Link { get; set; }
    }
}
