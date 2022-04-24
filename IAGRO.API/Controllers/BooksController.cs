using IAGRO.Application.Interfaces;
using IAGRO.Application.Services.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace IAGRO.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _booksService;

        public BooksController(ILogger<BooksController> logger, IBooksService booksService)
        {
            _logger = logger;
            _booksService = booksService;
        }

        /// <summary>
        /// Retorna todos os produtos contidos no arquivo books.json.
        /// </summary>
        /// <returns>IEnumerable</returns>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<BooksResponse> GetAll()
        {
            return _booksService.GetAll();
        }

        /// <summary>
        /// Retorna todos os produtos a partir do nome do autor.
        /// </summary>
        /// <param name="author">Nome do autor</param>
        /// <returns>IEnumerable</returns>
        [Route("get-by-author")]
        [HttpGet]
        public IEnumerable<BooksResponse> GetByAuthor(string author)
        {
            return _booksService.GetByAuthor(author);
        }

        /// <summary>
        /// Retorna todos os produtos a partir do nome do livro.
        /// </summary>
        /// <param name="book">Nome do livro</param>
        /// <returns></returns>
        [Route("get-by-books-name")]
        [HttpGet]
        public IEnumerable<BooksResponse> GetByBooksName(string book)
        {
            return _booksService.GetByBooksName(book);
        }

        /// <summary>
        /// Retorna todos os produtos a partir de alguma especificação.
        /// </summary>
        /// <param name="term">Descrição de alguma especificação do produto (publicação, autor, ilustradores, gêneros)</param>
        /// <returns>IEnumerable</returns>
        [Route("find-any-specification")]
        [HttpGet]
        public IEnumerable<BooksResponse> FindAnySpecification(string term)
        {
            return _booksService.FindAnySpecification(term);
        }

        /// <summary>
        /// Retorna o valor do frete do produto, considerando 20% do seu valor.
        /// </summary>
        /// <param name="bookId">Código do produto</param>
        /// <returns>decimal</returns>
        [Route("get-shipping-price")]
        [HttpGet]
        public decimal GetShippingPrice(int? bookId)
        {
            return _booksService.GetShippingPrice(bookId);
        }

        /// <summary>
        /// Ordena a listagem de produtos pelo seu preço.
        /// </summary>
        /// <param name="orderBy">Parâmetro de ordenação (somente 'asc' ou 'desc')</param>
        /// <returns>IEnumerable</returns>
        [Route("order-by-price")]
        [HttpGet]
        public IEnumerable<BooksResponse> OrderByPrice(string orderBy)
        {
            return _booksService.OrderByPrice(orderBy);
        }
    }
}
