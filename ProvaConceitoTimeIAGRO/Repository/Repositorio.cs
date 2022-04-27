using Newtonsoft.Json;
using ProvaConceitoTimeIAGRO.Exceptions;
using ProvaConceitoTimeIAGRO.Interface;
using ProvaConceitoTimeIAGRO.Model;
using System.Collections.Generic;
using System.Text;

namespace ProvaConceitoTimeIAGRO.Repository
{
    /// <summary>
    /// Class Repositorio
    /// </summary>
    public class Repositorio : IRepositorio
    {
        /// <summary>
        /// Method Get Book
        /// </summary>
        /// <returns>Retorno List Book</returns>
        /// <exception cref="System.Exception"></exception>
        public List<Book> GetBook()
        {
            try
            {
                Encoding encoding = Encoding.GetEncoding(28591);

                string json = System.IO.File.ReadAllText(@"books.json", encoding);

                List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(json);
                return bookList;
            }
            catch (ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}