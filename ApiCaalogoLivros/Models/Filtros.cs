using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCaalogoLivros.Models
{
    public class Filtros
    {
        public string Autor { get; set; }
        public string NomeLivro { get; set; }
        public double? PrecoInicial { get; set; }
        public double? PrecoFinal { get; set; }
        public string Genero { get; set; }
        public string Ilustrador { get; set; }
        public int? QuantidadePaginasInicial { get; set; }
        public int? QuantidadePaginasFinal { get; set; }
        public string CampoOrdenacao { get; set; }
        public bool Crescente { get; set; }
    }
}
