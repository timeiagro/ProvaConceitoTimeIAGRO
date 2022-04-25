using System.Collections.Generic;

namespace IAGRO.Application.Services.Books
{
    public class SpecificationResponse
    {
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public IList<string> Illustrator { get; set; }
        public IList<string> Genres { get; set; }
    }
}
