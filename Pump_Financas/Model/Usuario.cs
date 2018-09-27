using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario
    {
        [Key]
        public string Email { get; set; }

        public string Nome { get; set; }

        public int Perfil { get; set; }

        public string Senha { get; set; }

        public bool Status { get; set; }

    }
}
