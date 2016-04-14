using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace ORM.Configuration
{
    class CustomerConfiguration : EntityTypeConfiguration<ORM.Customer>
    {
        public CustomerConfiguration()
        {
            this.Property(c => c.Nif).HasMaxLength(15).IsUnicode(false).IsRequired();
            this.Ignore(c => c.Sexo);
        }
    }
}
