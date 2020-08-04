using ApiCaalogoLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCaalogoLivros.Repository
{
     public interface ILivroRepository
    {
        List<Livros> Query();
    }
}
