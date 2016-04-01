using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericos
{
    public class Cliente : EntityBase<Cliente>
    {
        [Required(ErrorMessage="El campo es requerido.")]
        [MaxLength(10, ErrorMessage="El número de carácteres es incorrecto")]
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
