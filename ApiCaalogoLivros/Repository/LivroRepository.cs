using ApiCaalogoLivros.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiCaalogoLivros.Repository
{
    public class LivroRepository : ILivroRepository
    {
        public List<Livros> Query()
        {
            var json = File.ReadAllText(@"../ApiCaalogoLivros/Livros.json", Encoding.GetEncoding("iso-8859-1"));

            var livros = JsonConvert.DeserializeObject<List<Livros>>(json); 

            return livros;

        }
    }
}
