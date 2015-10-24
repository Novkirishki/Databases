namespace SocialNetworkXML.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class User
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }
        
        public List<Image> Images { get; set; }
    }
}
