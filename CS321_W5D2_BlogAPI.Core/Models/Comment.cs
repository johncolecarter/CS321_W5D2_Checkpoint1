using System;
using System.ComponentModel.DataAnnotations;

namespace CS321_W5D2_BlogAPI.Core.Models
{
    public class Comment : IEntity<int>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }



        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }



        [Required]
        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
