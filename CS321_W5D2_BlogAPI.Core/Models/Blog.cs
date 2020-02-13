using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CS321_W5D2_BlogAPI.Core.Models
{
    public class Blog : IEntity<int>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
