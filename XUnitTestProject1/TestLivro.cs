using ApiCaalogoLivros.Models;
using ApiCaalogoLivros.Repository;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class TestLivro
    {
        private readonly ILivroService _livroService;
        private readonly Mock<ILivroRepository> _livroRepositoryMock = new Mock<ILivroRepository>();

        public TestLivro()
        {
            //Injeção de dependência
            _livroService = new LivroService(_livroRepositoryMock.Object);
        }

        private List<Livros> MockListaLivro()
        {
            var json = File.ReadAllText(@"../../../Mock/Livro.json", Encoding.GetEncoding("iso-8859-1"));

            var livros = JsonConvert.DeserializeObject<List<Livros>>(json);

            return livros;
        }

        [Theory]
        [InlineData("Jules Verne", 2)]
        [InlineData("J. K. Rowling", 2)]
        [InlineData("J. R. R. Tolkien", 1)]
        [InlineData("J", 5)]
        [InlineData("Jose", 0)]
        public void BuscaLivroPorAutor(string nome, int quantidadeRetorno)
        {
            //arrange
            var filtro = new Filtros
            {
                Autor = nome
            };
            _livroRepositoryMock.Setup(x => x.Query()).Returns(MockListaLivro());

            //act
            var resultado = _livroService.BuscarLivros(filtro);

            //assert
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }


        [Theory]
        [InlineData("Cliff Wright", 2)]
        [InlineData("Édouard Riou", 2)]
        [InlineData("Mary GrandPré", 1)]
        [InlineData("Tolkien", 1)]
        public void BuscarLivroPorIlustrador(string nome, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new Filtros
            {
                Ilustrador = nome
            };
            _livroRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _livroService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }

        [Theory]
        [InlineData("Journey to the Center of the Earth", 1)]
        [InlineData("20,000 Leagues Under the Sea", 1)]
        [InlineData("Harry Potter and the Goblet of Fire", 1)]
        [InlineData("Fantastic Beasts and Where to Find Them: The Original Screenplay", 1)]
        [InlineData("The Lord of the Rings", 1)]
        public void BuscarLivroPorNome(string nome, int quantidadeRetorno)
        {
            //arrange
            var filtro = new Filtros
            {
                NomeLivro = nome
            };
            _livroRepositoryMock.Setup(x => x.Query()).Returns(MockListaLivro());

            //act
            var resultado = _livroService.BuscarLivros(filtro);

            //assert
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }

        [Theory]
        [InlineData("Adventure fiction", 2)]
        [InlineData("Adventure Fiction", 1)]
        [InlineData("Fantasy Fiction", 3)]
        [InlineData("Science Fiction", 1)]
        [InlineData("Drama", 1)]
        [InlineData("Young adult fiction", 1)]
        [InlineData("Mystery", 1)]
        [InlineData("Thriller", 1)]
        [InlineData("Bildungsroman", 1)]
        [InlineData("Contemporary fantasy", 1)]
        [InlineData("Screenplay", 1)]
        public void BuscarLivroPorGenero(string nome, int quantidadeRetorno)
        {
            //arrange
            var filtro = new Filtros
            {
                Genero = nome
            };
            _livroRepositoryMock.Setup(x => x.Query()).Returns(MockListaLivro());

            //act
            var resultado = _livroService.BuscarLivros(filtro);

            //assert
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }
         

        [Theory]
        [InlineData("autor", true, 3)]
        [InlineData("autor", false, 1)]
        [InlineData("nome", true, 2)]
        [InlineData("nome", false, 5)]
        [InlineData("preco", true, 5)]
        [InlineData("preco", false, 4)]
        [InlineData("pagina", true, 1)]
        [InlineData("pagina", false, 5)]
        public void BuscarLivroComOrdenacao(string campo, bool crescente, int idDoRegistro)
        {
            //arrange
            var filtro = new Filtros
            {
                CampoOrdenacao = campo,
                Crescente = crescente
            };
            _livroRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //act
            var resultado = _livroService.BuscarLivros(filtro);

            //assert
            Assert.Equal(idDoRegistro, resultado.First().Id);
        }


        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2.02)]
        [InlineData(3, 1.462)]
        [InlineData(4, 2.23)]
        [InlineData(5, 1.2300000000000002)]
        public void CalcularPrecoDoFrete(int id, double valorDoFrete)
        {
            //arrange
            _livroRepositoryMock.Setup(x => x.Query()).Returns(MockListaLivro());

            //act
            var resultado = _livroService.CalcularFrete(id);

            //assert
            Assert.Equal(valorDoFrete, resultado);
        }
    }
}
