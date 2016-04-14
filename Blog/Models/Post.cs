using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post : EntityBaseWithDescription
    {
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
            Comments = new List<Comment>();
        }
    }
}
