using IAGRO.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace IAGRO.Application.Data
{
    public class BooksData : IBooksData
    {
        public IList<Books> GetData()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\JSON\books.json";
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<IList<Books>>(json);
        }
    }
}
