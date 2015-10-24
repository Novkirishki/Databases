namespace SocialNetworkXML.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    public class Friendship
    {
        [XmlAttribute]
        public bool Approved { get; set; }
        
        public DateTime? FriendsSince { get; set; }

        public User FirstUser { get; set; }

        public User SecondUser { get; set; }
        
        public List<Message> Messages { get; set; }
    }
}
