using ApiCaalogoLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiCaalogoLivros.Repository
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repo;

        public LivroService(ILivroRepository repo)
        {
            _repo = repo;
        }
        public List<Livros> BuscarLivros(Filtros filtros)
        {
            var livros = _repo.Query();

            if (!string.IsNullOrEmpty(filtros.Autor))
                livros = livros.Where(p => p.Especificacoes.Author.Contains(filtros.Autor)).ToList();

            if (!string.IsNullOrEmpty(filtros.NomeLivro))
                livros = livros.Where(p => p.Name.Contains(filtros.NomeLivro)).ToList();

            if (filtros.PrecoInicial != null)
                livros = livros.Where(p => p.Price >= filtros.PrecoInicial).ToList();

            if (filtros.PrecoFinal != null)
                livros = livros.Where(p => p.Price <= filtros.PrecoFinal).ToList();

            if (!string.IsNullOrEmpty(filtros.Genero))
                livros = livros.Where(p => p.Especificacoes.Genres.Contains(filtros.Genero)).ToList();

            if (!string.IsNullOrEmpty(filtros.Ilustrador))
                livros = livros.Where(p => p.Especificacoes.Illustrator.Any(s => s.Contains(filtros.Ilustrador))).ToList();

            if (filtros.QuantidadePaginasInicial != null)
                livros = livros.Where(p => p.Especificacoes.PageCount >= filtros.QuantidadePaginasInicial).ToList();

            if (filtros.QuantidadePaginasFinal != null)
                livros = livros.Where(p => p.Especificacoes.PageCount <= filtros.QuantidadePaginasFinal).ToList();


            switch (filtros.CampoOrdenacao)
            {
                case "autor":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Especificacoes.Author).ToList() : livros.OrderByDescending(p => p.Especificacoes.Author).ToList();
                    break;

                case "nome":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Name).ToList() : livros.OrderByDescending(p => p.Name).ToList();
                    break;

                case "preco":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Price).ToList() : livros.OrderByDescending(p => p.Price).ToList();
                    break;

                case "pagina":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Especificacoes.PageCount).ToList() : livros.OrderByDescending(p => p.Especificacoes.PageCount).ToList();
                    break;

                default:
                    break;
            }


            return livros;
        }

        public double CalcularFrete(int id)
        {
            var livro = _repo.Query().Where(p => p.Id == id).FirstOrDefault();

            if (livro == null)
                return 0;

            return livro.Price * 0.2;
        }

    }
}
