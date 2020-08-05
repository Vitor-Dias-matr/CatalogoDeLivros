using System.Collections.Generic;
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

        public List<Livros> Get([FromQuery] string autor, [FromQuery] string nomelivro,
          [FromQuery] double? precoinicial, [FromQuery] double? precofinal,
          [FromQuery] string genero, [FromQuery] string ilustrador,
          [FromQuery] int? quantidadepaginasinicial, [FromQuery] int? quantidadepaginasfinal,
          [FromQuery] string campoOrdenacao, [FromQuery] bool cresente,
          [FromQuery] double calculaFrete)
        {

            var filtros = new Filtros
            {
                Autor = autor,
                NomeLivro = nomelivro,
                PrecoInicial = precoinicial,
                PrecoFinal = precofinal,
                Genero = genero,
                Ilustrador = ilustrador,
                QuantidadePaginasInicial = quantidadepaginasinicial,
                QuantidadePaginasFinal = quantidadepaginasfinal,
                CampoOrdenacao = campoOrdenacao,
                Crescente = cresente,
                CalcularFrete = calculaFrete

            };

            return _service.BuscarLivros(filtros);
        }
    }
}
