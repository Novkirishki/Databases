namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using System.Collections;
    using System.Linq;
    using SocialNetwork.Data;

    public class SocialNetworkSearcher : ISocialNetworkService
    {
        public IEnumerable GetChatUsers(string username)
        {
            using (var db = new SocialNetworkEntities())
            {
                var users = db.UserProfiles
                    .Where(u => u.ChatMessages.Select(m => m.Friednship).Select(f => f.FirstUser.Username).ToList().Contains(username)
                    || u.ChatMessages.Select(m => m.Friednship).Select(f => f.SecondUser.Username).ToList().Contains(username))
                    .Distinct()
                    .OrderBy(u => u.Username)
                    .Select(u => new { Username = u.Username })
                    .ToList();

                return users;
            }
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            using (var db = new SocialNetworkEntities())
            {
                var friendships = db.Friendships
                    .OrderBy(f => f.DateApproved)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .Select(f => new
                    {
                        FirstUserUsername = f.FirstUser.Username,
                        FirstUserImage = f.FirstUser.Images.FirstOrDefault().URL,
                        SecondUserUsername = f.SecondUser.Username,
                        SecondUserImage = f.SecondUser.Images.FirstOrDefault().URL,
                    })
                    .ToList();

                return friendships;
            }
        }

        public IEnumerable GetPostsByUser(string username)
        {
            using (var db = new SocialNetworkEntities())
            {
                var posts = db.Posts
                    .Where(p => p.UserProfiles.Select(u => u.Username).ToList().Contains(username))
                    .Select(p => new
                    {
                        PostedOn = p.PostingDate,
                        Content = p.Content,
                        Usernames = p.UserProfiles.Select(u => u.Username).ToList()
                    })
                    .ToList();

                return posts;
            }
        }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            using (var db = new SocialNetworkEntities())
            {
                var users = db.UserProfiles
                    .Where(u => u.RegistrationDate.Year >= year)
                    .Select(u => new
                    {
                        u.Username,
                        u.FirstName,
                        u.LastName,
                        NumberOfImages = u.Images.Count                       
                    })
                    .ToList();

                return users;
            }
        }
    }
}
