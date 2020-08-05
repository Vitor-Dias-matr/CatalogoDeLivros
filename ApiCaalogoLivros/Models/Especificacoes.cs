using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiCaalogoLivros.Models
{
    public class Especificacoes
    {
        [JsonProperty("Originallypublished")]
        public string OriginallyPublished { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }

        [JsonProperty("Pagecount")]
        public int PageCount { get; set; }

        [JsonProperty("Illustrator")]
        public List<string> Illustrator { get; set; }

        [JsonProperty("Genres")]
        public List<string> Genres { get; set; }
    }
}
