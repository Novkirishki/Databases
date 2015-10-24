namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public static class XmlParser
    {
        public static IEnumerable<SocialNetworkXML.Models.Friendship> ParseFrindships(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("{0} file not found!", fileName);
                return null;
            }

            var serializer = new XmlSerializer(typeof(List<SocialNetworkXML.Models.Friendship>), new XmlRootAttribute("Friendships"));
            IEnumerable<SocialNetworkXML.Models.Friendship> friendships;

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                friendships = (IEnumerable<SocialNetworkXML.Models.Friendship>)serializer.Deserialize(fs);
            }

            return friendships;
        }

        public static IEnumerable<SocialNetworkXML.Models.Post> ParsePosts(string fileName)
        {            
            if (!File.Exists(fileName))
            {
                Console.WriteLine("{0} file not found!", fileName);
                return null;
            }

            var serializer = new XmlSerializer(typeof(List<SocialNetworkXML.Models.Post>), new XmlRootAttribute("Posts"));
            IEnumerable<SocialNetworkXML.Models.Post> posts;

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                posts = (IEnumerable<SocialNetworkXML.Models.Post>)serializer.Deserialize(fs);
            }

            return posts;
        }
    }
}
