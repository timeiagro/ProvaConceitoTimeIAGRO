using IAGRO.Application.Data;
using IAGRO.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace IAGRO.Application.Services.Books
{
    public class BooksService : IBooksService
    {
        public BooksService()
        {
            _booksData = new BooksData();
        }

        private readonly IBooksData _booksData;

        private IQueryable<BooksResponse> GetAllData()
        {
            return _booksData.GetData()
                .Select(data => new BooksResponse()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Price = data.Price,
                    Specifications = new SpecificationResponse()
                    {
                        Author = data.Specifications.Author,
                        Genres = data.Specifications.Genres,
                        Illustrator = data.Specifications.Illustrator,
                        OriginallyPublished = data.Specifications.OriginallyPublished,
                        PageCount = data.Specifications.PageCount
                    }
                })
                .AsQueryable();
        }

        IList<BooksResponse> IBooksService.GetAll()
        {
            return GetAllData()
                .ToList();
        }

        IList<BooksResponse> IBooksService.GetByAuthor(string author)
        {
            return string.IsNullOrEmpty(author) ? null : GetAllData()
                .Where(where => where.Specifications.Author.ToLower().Contains(author.ToLower()))
                .ToList();
        }

        IList<BooksResponse> IBooksService.GetByBooksName(string book)
        {
            return string.IsNullOrEmpty(book) ? null : GetAllData()
                .Where(where => where.Name.ToLower().Contains(book.ToLower()))
                .ToList();
        }

        IList<BooksResponse> IBooksService.FindAnySpecification(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return null;
            }

            string termLower = term.ToLower();
            return GetAllData()
                .Where(where => where.Specifications.Illustrator.Any(any => any.ToLower().Contains(termLower)) ||
                    where.Specifications.Genres.Any(any => any.ToLower().Contains(termLower)) ||
                    where.Specifications.Author.ToLower().Contains(termLower) ||
                    where.Specifications.OriginallyPublished.ToLower().Contains(termLower))
                .ToList();
        }

        decimal IBooksService.GetShippingPrice(int? bookId)
        {
            if (!bookId.HasValue)
            {
                return 0;
            }

            var book = GetAllData()
                .Where(where => where.Id == bookId.Value)
                .FirstOrDefault();

            if (book == null)
            {
                return 0;
            }

            decimal percentage = 0.2m;
            return percentage * book.Price;
        }

        IList<BooksResponse> IBooksService.OrderByPrice(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                return null;
            }

            var validSorting = new List<string>() { "asc", "desc" };

            if (!validSorting.Contains(orderBy))
            {
                return null;
            }

            var data = GetAllData();
            return orderBy == "asc" ?
                data.OrderBy(orderBy => orderBy.Price).ToList() :
                data.OrderByDescending(orderBy => orderBy.Price).ToList();
        }
    }
}
