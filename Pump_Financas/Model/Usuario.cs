using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        public string Email { get; set; }

        public int Perfil { get; set; }

        public string Senha { get; set; }

        public bool Status { get; set; }

    }
}
