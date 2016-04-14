using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Configurations
{
    public class CommentConfiguration :EntityTypeConfiguration<Blog.Comment>
    {
        public CommentConfiguration()
        {
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Text).HasMaxLength(150).IsUnicode(false).IsRequired();
        }
    }
}
