using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCaalogoLivros.Models
{
    public class Livros
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Especificacoes Especificacoes { get; set; }
    }
}
