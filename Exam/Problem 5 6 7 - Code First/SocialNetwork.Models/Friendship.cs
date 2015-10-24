namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        public int Id { get; set; }

        public DateTime? DateApproved { get; set; }

        [Index]
        public bool IsApproved { get; set; }

        [Required]
        public int FirstUserId { get; set; }

        public virtual UserProfile FirstUser { get; set; }

        [Required]
        public int SecondUserId { get; set; }

        public virtual UserProfile SecondUser { get; set; }
    }
}
