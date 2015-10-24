namespace SocialNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
