using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        public bool Status { get; set; }
    }
}
