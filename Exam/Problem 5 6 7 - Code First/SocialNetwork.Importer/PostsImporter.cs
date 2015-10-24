namespace SocialNetwork.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SocialNetwork.Data;
    using SocialNetwork.Models;

    public static class PostsImporter
    {
        public static void Import(SocialNetworkEntities db, IEnumerable<SocialNetworkXML.Models.Post> posts)
        {
            var counter = 0;

            foreach (var post in posts)
            {
                var usernamesInPost = post.Users.Split(new char[] { ',' });
                var usersInPost = new HashSet<UserProfile>();

                foreach (var userName in usernamesInPost)
                {
                    var user = db.UserProfiles.Where(u => u.Username == userName).First();
                    usersInPost.Add(user);
                }

                db.Posts.Add(new Post()
                {
                    Content = post.Content,
                    PostingDate = post.PostedOn,
                    UserProfiles = usersInPost
                });

                if (counter == 100)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new SocialNetworkEntities();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    counter = 0;
                    Console.Write(".");
                }

                counter++;
            }

            db.SaveChanges();
        }
    }
}
