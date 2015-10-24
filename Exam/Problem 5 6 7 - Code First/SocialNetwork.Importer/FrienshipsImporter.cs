namespace SocialNetwork.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SocialNetwork.Data;
    using SocialNetwork.Models;

    public static class FrienshipsImporter
    {
        public static void Import(SocialNetworkEntities db, IEnumerable<SocialNetworkXML.Models.Friendship> friendships)
        {
            var userNamesAdded = new HashSet<string>();
            var counter = 0;

            foreach (var friendship in friendships)
            {
                // FirstUser
                var firstUser = new UserProfile();

                if (userNamesAdded.Contains(friendship.FirstUser.Username))
                {
                    firstUser = db.UserProfiles.Where(u => u.Username == friendship.FirstUser.Username).First();
                }
                else
                {
                    firstUser = new UserProfile()
                    {
                        Username = friendship.FirstUser.Username,
                        FirstName = friendship.FirstUser.FirstName,
                        LastName = friendship.FirstUser.LastName,
                        RegistrationDate = friendship.FirstUser.RegisteredOn,
                    };

                    userNamesAdded.Add(firstUser.Username);

                    var images = new HashSet<Image>();

                    foreach (var image in friendship.FirstUser.Images)
                    {
                        images.Add(new Image()
                        {
                            URL = image.ImageUrl,
                            FileExtension = image.FileExtension,
                        });
                    }

                    firstUser.Images = images;
                }                

                // Second user
                var secondUser = new UserProfile();

                if (userNamesAdded.Contains(friendship.SecondUser.Username))
                {
                    secondUser = db.UserProfiles.Where(u => u.Username == friendship.SecondUser.Username).First();
                }
                else
                {
                    secondUser = new UserProfile()
                    {
                        Username = friendship.SecondUser.Username,
                        FirstName = friendship.SecondUser.FirstName,
                        LastName = friendship.SecondUser.LastName,
                        RegistrationDate = friendship.SecondUser.RegisteredOn,
                    };

                    userNamesAdded.Add(secondUser.Username);

                    var imagesOfSecondUser = new HashSet<Image>();

                    foreach (var image in friendship.SecondUser.Images)
                    {
                        imagesOfSecondUser.Add(new Image()
                        {
                            URL = image.ImageUrl,
                            FileExtension = image.FileExtension,
                        });
                    }

                    secondUser.Images = imagesOfSecondUser;
                }
              
                // Friendship
                var friendshipToAdd = new Friendship()
                {
                    IsApproved = friendship.Approved,
                    DateApproved = friendship.FriendsSince,
                    FirstUser = firstUser,
                    SecondUser = secondUser,
                };

                db.Friendships.Add(friendshipToAdd);

                // Messages
                foreach (var message in friendship.Messages)
                {
                    var author = new UserProfile();

                    if (firstUser.Username == message.Author)
                    {
                        author = firstUser;
                    }
                    else
                    {
                        author = secondUser;
                    }

                    var messageToAdd = new ChatMessage()
                    {
                        Content = message.Content,
                        DateTimeOfSending = message.SentOn,
                        DateTimeOfSeeing = message.SeenOn,
                        Author = author,
                        Friednship = friendshipToAdd,
                    };

                    db.ChatMessages.Add(messageToAdd);

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
}
