namespace ApiCaalogoLivros.Models
{
    public class Livros
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Especificacoes Specifications { get; set; }
    }
}
