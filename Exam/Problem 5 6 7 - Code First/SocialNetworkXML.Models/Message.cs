namespace SocialNetworkXML.Models
{
    using System;
    using System.Xml.Serialization;

    public class Message
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }
        
        public DateTime? SeenOn { get; set; }
    }
}
