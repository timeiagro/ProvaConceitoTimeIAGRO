using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProvaConceitoTimeIAGRO
{
    public class Program
    {

        // NOTE: Codigo comentado devido que iria colocar json InMemory
        // mas devido que nem todo conteudo do json é tipo primitivo não 
        // houve tempo habil para procurar outra solução
        // Uma que poderia seria o automapper, mas não tive como realizar o teste
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //var context = services.GetRequiredService<Context>();
                //AddToDatabaseInMemory(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //public static void AddToDatabaseInMemory(Context dbContext)
        //{
        //    Encoding encoding = Encoding.GetEncoding(28591);
        //    string json = System.IO.File.ReadAllText(@"books.json", encoding);
        //    List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(json);
        //    dbContext.Books.AddRange(bookList);
        //    dbContext.SaveChanges();
        //}
    }
}