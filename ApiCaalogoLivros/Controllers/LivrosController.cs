using System.Collections.Generic;
using System.Linq;
using ApiCaalogoLivros.Models;
using ApiCaalogoLivros.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCaalogoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _service;
        
        public LivrosController(ILivroService service)
        {
            _service = service;
        }

        public ActionResult<Livros> Get([FromQuery] string autor, [FromQuery] string nomelivro,
          [FromQuery] double? preco,[FromQuery] string genero, [FromQuery] string ilustrador,
          [FromQuery] int? quantidadepaginas, [FromQuery] string campoOrdenacao, 
          [FromQuery] bool cresente)
        {

            var filtros = new Filtros
            {
                Autor = autor,
                NomeLivro = nomelivro,
                Preco = preco,
                Genero = genero,
                Ilustrador = ilustrador,
                QuantidadePaginas = quantidadepaginas,
                CampoOrdenacao = campoOrdenacao,
                Crescente = cresente,
            };

            var result = _service.BuscarLivros(filtros).Select(x => new
            {
                x.Id,
                x.Name,
                x.Price,
                x.Specifications,

                valorDoFrete = _service.CalcularFrete(x.Id)

            });

            return Ok(result);
        }
    }
}
