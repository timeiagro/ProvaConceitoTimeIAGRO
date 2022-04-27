using ProvaConceitoTimeIAGRO.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ProvaConceitoTimeIAGRO.Interface
{
    /// <summary>
    /// Interface IGenericService T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericService<T> : IDisposable
    {
        /// <summary>
        /// Method Get All
        /// </summary>
        /// <param name="item">T</param>
        /// <param name="order">string</param>
        /// <returns>Resultado List T</returns>
        List<T> GetAll([FromBody] T item, string order = "asc");

        /// <summary>
        /// Method Frete
        /// </summary>
        /// <param name="valor">double</param>
        /// <returns>resultado double</returns>
        double Frete(double valor);
    }
}