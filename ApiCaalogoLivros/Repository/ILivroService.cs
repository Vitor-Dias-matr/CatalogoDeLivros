using ApiCaalogoLivros.Models;
using System.Collections.Generic;

namespace ApiCaalogoLivros.Repository
{
    public interface ILivroService
    {
        List<Livros> BuscarLivros(Filtros filtros);
        double CalcularFrete(int id);
    }
}
