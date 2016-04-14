using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Models;

namespace Blog.Configurations
{
    public class PostConfiguration : EntityTypeConfiguration<Blog.Models.Post>
    {
        public PostConfiguration()
        {
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.Comments);
        }
    }
}
