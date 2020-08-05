
using Newtonsoft.Json;

namespace ApiCaalogoLivros.Models
{
    public class Livros
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("specifications")]
        public Especificacoes Specifications { get; set; }
    }
}
