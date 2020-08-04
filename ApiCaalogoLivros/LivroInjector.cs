using ApiCaalogoLivros.Repository;
using Microsoft.Extensions.DependencyInjection;

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
