using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Perfil
    {
        [Key]
        public int PerfilID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        public bool Status { get; set; }

    }
}
