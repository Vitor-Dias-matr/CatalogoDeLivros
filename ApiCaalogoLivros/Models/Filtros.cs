namespace ApiCaalogoLivros.Models
{
    public class Filtros
    {
        public string Autor { get; set; }
        public string NomeLivro { get; set; }
        public double? Preco{ get; set; }        
        public string Genero { get; set; }
        public string Ilustrador { get; set; }
        public int? QuantidadePaginas { get; set; }
        public string CampoOrdenacao { get; set; }
        public bool Crescente { get; set; }
    }
}
