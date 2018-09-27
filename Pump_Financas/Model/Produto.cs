﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }

        [Required]
        public string Nome { get; set; }

        public string CodInterno { get; set; }        

        public int Categoria { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }       

        public bool Status { get; set; }
    }
}
