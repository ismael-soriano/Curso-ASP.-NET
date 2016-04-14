using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Clientes")]
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Nombre")]
        public string Name { get; set; }
        public string Nif { get; set; }
        public string Phone { get; set; }
        public string Sexo { get; set; }
    }
}
