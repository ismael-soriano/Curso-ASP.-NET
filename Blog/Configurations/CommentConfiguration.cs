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
    public class CommentConfiguration : EntityTypeConfiguration<Blog.Models.Comment>
    {
        public CommentConfiguration()
        {
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Description).IsRequired();
            this.HasRequired(c => c.User);
        }
    }
}
