namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ChatMessage
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime DateTimeOfSending { get; set; }

        public DateTime? DateTimeOfSeeing { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friednship { get; set; }

        public int AuthorId { get; set; }

        public virtual UserProfile Author { get; set; }
    }
}
