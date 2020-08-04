using ApiCaalogoLivros.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCaalogoLivros.Repository
{
    public class LivroRepository : ILivroRepository
    {
        public List<Livros> Query()
        {
            var json = File.ReadAllText(@"C:\Users\vitor\OneDrive\Documentos\Api\ApiCaalogoLivros\ApiCaalogoLivros\Livros.json", Encoding.GetEncoding("iso-8859-1"));

            var livros = JsonConvert.DeserializeObject<List<Livros>>(json);

            return livros;
        }
    }
}
