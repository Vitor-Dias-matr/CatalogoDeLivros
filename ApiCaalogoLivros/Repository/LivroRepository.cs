using ApiCaalogoLivros.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ApiCaalogoLivros.Repository
{
    public class LivroRepository : ILivroRepository
    {
        public List<Livros> Query()
        {
            var json = File.ReadAllText(@"../ApiCaalogoLivros/Livros.json", Encoding.GetEncoding("iso-8859-1"));

            // var json = new WebClient().DownloadString("https://raw.githubusercontent.com/Vitor-Dias-matr/BackendTest/master/books.json");

            //var cliente = new WebClient();
            //var json = cliente.DownloadString("https://raw.githubusercontent.com/Vitor-Dias-matr/BackendTest/master/books.json");
                            
            var livros = JsonConvert.DeserializeObject<List<Livros>>(json);
                                       
            return livros;

        }
    }
}
