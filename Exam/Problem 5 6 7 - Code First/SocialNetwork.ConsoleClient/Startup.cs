namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using Data;
    using Searcher;
    using SocialNetwork.Importer;

    public class Startup
    {
        const string FrienshipsFileName = "XmlFiles/Friendships.xml";
        const string PostsFileName = "XmlFiles/Posts.xml";

        public static void Main()
        {
            Console.WriteLine(@"Keep in mind that it is awfully slow, so please be patient. Or if you want just dont wait it till the end, stop it and see there are results in the database. On my laptop it takes around a minute. Sorry for wasting your time");
            //AddFrienships();
            //AddPosts();

            Console.WriteLine("Creating JSONs");
            DataSearcher.Search(new SocialNetworkSearcher());
        }

        private static void AddFrienships()
        {
            var friendships = XmlParser.ParseFrindships(FrienshipsFileName);

            using (var db = new SocialNetworkEntities())
            {
                FrienshipsImporter.Import(db, friendships);
            }

            Console.WriteLine("Frienships added. Now posts are on the way");
        }

        private static void AddPosts()
        {
            var posts = XmlParser.ParsePosts(PostsFileName);

            using (var db = new SocialNetworkEntities())
            {
                PostsImporter.Import(db, posts);
            }

            Console.WriteLine("Posts added. Yey :)");
        }
    }
}
