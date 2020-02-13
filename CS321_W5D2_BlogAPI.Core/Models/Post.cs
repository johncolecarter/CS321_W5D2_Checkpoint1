using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CS321_W5D2_BlogAPI.Core.Models
{
    public class Post : IEntity<int>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        public bool CommentsAllowed { get; set; }


        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
