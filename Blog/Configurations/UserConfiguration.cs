using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<Blog.Models.User>
    {
        public UserConfiguration()
        {
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Description).IsRequired();
        }
    }
}
