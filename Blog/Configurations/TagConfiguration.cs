using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Configurations
{
    public class TagConfiguration : EntityTypeConfiguration<Blog.Tag>
    {
        public TagConfiguration()
        {
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).IsUnicode(false).IsRequired();
        }
    }
}
