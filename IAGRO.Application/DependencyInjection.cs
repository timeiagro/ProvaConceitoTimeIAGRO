using IAGRO.Application.Interfaces;
using IAGRO.Application.Services.Books;
using Microsoft.Extensions.DependencyInjection;

namespace IAGRO.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBooksService, BooksService>();
        }
    }
}
