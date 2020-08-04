using ApiCaalogoLivros.Models;
using System.Collections.Generic;

namespace ApiCaalogoLivros.Repository
{
    public interface ILivroRepository
    {
        List<Livros> Query();
    }
}
