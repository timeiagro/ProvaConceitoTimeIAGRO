using ProvaConceitoTimeIAGRO.Model;
using System.Collections.Generic;

namespace ProvaConceitoTimeIAGRO.Interface
{
    /// <summary>
    /// Interface IRepositorio
    /// </summary>
    public interface IRepositorio
    {
        /// <summary>
        /// Method GetBook
        /// </summary>
        /// <returns></returns>
        List<Book> GetBook();
    }
}