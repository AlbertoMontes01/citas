using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citas.Shared.Model
{
    public class Pacient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "invalid name")] //data_anotation
        public string? Nombre { get; set; }

        [Required]
        public DateTime? Born { get; set; }

        [Required]
        public string? Domicilio { get; set; }


        [RegularExpression(@"^^\+\d{2,3}\s\d{3}-\d{3}-\d{4}$", ErrorMessage = "The phone number is not in the correct format, example: +52 312-123-2344")]
        public string? Phone { get; set; }

        [Required]
        public string? Correo { get; set; }
        /*[Range(0,int.MaxValue, ErrorMessage ="Must be a positive number")]
        public int? Salario { get; set; }
        [Range(1,2, ErrorMessage ="Debes seleccionar un genero")]
        public int? Genero { get; set; }*/

        public virtual ICollection<Appoitment>? Appoitments { get; set; }

    }
}
