namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserProfile
    {
        private ICollection<ChatMessage> chatMessages;
        private ICollection<Post> posts;
        private ICollection<Image> images;

        public UserProfile()
        {
            this.ChatMessages = new HashSet<ChatMessage>();
            this.Posts = new HashSet<Post>();
            this.Images = new HashSet<Image>();            
        }

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<ChatMessage> ChatMessages
        {
            get
            {
                return this.chatMessages;
            }

            set
            {
                this.chatMessages = value;
            }
        }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }
    }
}
