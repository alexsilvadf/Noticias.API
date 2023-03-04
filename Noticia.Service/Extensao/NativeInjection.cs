using Microsoft.AspNetCore.Mvc;
using Noticia.Application;
using Noticia.Application.Interface;
using Noticia.Core.Interface;
using Noticia.Infra.Repositorio;

namespace Noticia.Service.Extensao
{
    public static class NativeInjection
    {
        public static IServiceCollection RegistrarServicos(this IServiceCollection services)
        {
            services.AddScoped<INoticiaService, NoticiaService>();
            services.AddScoped<INoticiarioRepository, NoticiarioRepository>();

            services.AddHttpClient();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<ApiBehaviorOptions>(options =>
             options.InvalidModelStateResponseFactory = ActionContext =>
             {
                 var error = ActionContext.ModelState
                             .Where(e => e.Value?.Errors.Count > 0)
                             .SelectMany(e => e.Value.Errors)
                             .Select(e => e.ErrorMessage).ToArray();
                 return new BadRequestObjectResult(error);
             }
           );


            return services;
        }
    }
}
