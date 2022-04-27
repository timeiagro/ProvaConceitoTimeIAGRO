using ProvaConceitoTimeIAGRO.Exceptions;
using ProvaConceitoTimeIAGRO.ExtensionMethod;
using ProvaConceitoTimeIAGRO.Interface;
using ProvaConceitoTimeIAGRO.Model;
using ProvaConceitoTimeIAGRO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProvaConceitoTimeIAGRO.Servico
{
    /// <summary>
    /// Class Book Service
    /// </summary>
    public class BookService : IGenericService<Book>
    {
        private IRepositorio Repositorio;

        /// <summary>
        /// Construtor Book Service
        /// </summary>
        /// <param name="repositorio">IRepositorio</param>
        public BookService(IRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        /// <summary>
        /// Method Frete
        /// </summary>
        /// <param name="valor">double</param>
        /// <returns>resultado em double</returns>
        /// <exception cref="System.Exception"></exception>
        public double Frete(double valor)
        {
            try
            {
                double result = valor * 0.20;

                return Math.Round(result, 2);
            }
            catch (ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method Get All
        /// </summary>
        /// <param name="item">Model Book</param>
        /// <param name="order">string</param>
        /// <returns>Resultado em List Book</returns>
        /// <exception cref="System.Exception"></exception>
        public List<Book> GetAll([FromBody] Book item, string order)
        {
            try
            {
                List<Book> bookList = Repositorio.GetBook();

                if (Util.IsNotDefault(item))
                {
                    bookList = bookList.Where(x => x.Name.IsNullValue(item.Name) ||
                                  x.Id.Equals(item.Id) ||
                                  x.Price.Equals(item.Price) ||
                                  x.Specifications.Author.IsNullValue(item.Specifications?.Author) ||
                                  x.Specifications.PageCount.Equals(item.Specifications?.PageCount) ||
                                  x.Specifications.OriginallyPublished.IsNullValue(item.Specifications?.OriginallyPublished)
                                  ).ToList();
                }

                if (item?.Specifications?.Genres != null || item?.Specifications?.Illustrator != null)
                {
                    bookList = Util.Filtrar(bookList, item?.Specifications?.Genres, item?.Specifications?.Illustrator);
                }

                if (order != null)
                {
                    if (order == "asc")
                    {
                        bookList = bookList.OrderBy(x => x.Price).ToList();
                    }
                    else if (order == "desc")
                    {
                        bookList = bookList.OrderByDescending(x => x.Price).ToList();
                    }
                }

                return bookList;
            }
            catch(ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            } 
        }

        /// <summary>
        /// Method Dispose
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}