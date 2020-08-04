using ApiCaalogoLivros.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCaalogoLivros
{
    public class LivroInjector
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<ILivroRepository, LivroRepository>();

            //Services
            services.AddScoped<ILivroService, LivroService>();
        }
    }
}
