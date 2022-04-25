using IAGRO.Application.Services.Books;
using System.Collections.Generic;

namespace IAGRO.Application.Interfaces
{
    public interface IBooksService
    {
        IList<BooksResponse> GetAll();  
        IList<BooksResponse> GetByAuthor(string author);
        IList<BooksResponse> GetByBooksName(string book);
        IList<BooksResponse> FindAnySpecification(string term);
        decimal GetShippingPrice(int? bookId);
        IList<BooksResponse> OrderByPrice(string orderBy);
    }
}
