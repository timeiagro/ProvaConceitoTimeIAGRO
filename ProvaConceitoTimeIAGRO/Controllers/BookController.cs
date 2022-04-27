using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaConceitoTimeIAGRO.Interface;
using ProvaConceitoTimeIAGRO.Model;
using System;
using System.Collections.Generic;

namespace ProvaConceitoTimeIAGRO.Controllers
{
    /// <summary>
    /// Book Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : IGenericService<Book>
    {
        private IGenericService<Book> GenericService;

        /// <summary>
        /// Construtor Book Controller
        /// </summary>
        /// <param name="genericService"></param>
        public BookController(IGenericService<Book> genericService)
        {
            GenericService = genericService;
        }

        /// <summary>
        /// Method Frete
        /// </summary>
        /// <param name="valor">Double</param>
        /// <example>
        /// api/Book/Frete/111.3
        /// </example>
        /// <returns>resultado valor em double</returns>
        [HttpGet("Frete/{valor}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public double Frete(double valor)
        {
            return GenericService.Frete(valor);
        }

        /// <summary>
        /// Method Get All
        /// </summary>
        /// <param name="item">Model Book</param>
        /// <param name="order" value="asc">string</param>
        ///  <remarks> 
        /// <para>
        /// Example1: { }
        /// </para>
        /// <para>
        /// Example2: { "id": 2}
        /// </para>
        /// <para>
        /// Example3: { "name": "Journey" }
        /// </para>
        /// <para>
        /// Example4: { "price": 10 }
        /// </para>
        /// <para>
        /// Example5: { "specifications": { "originallyPublished": null } }
        /// </para>
        /// <para>
        /// Example6: { "specifications": { "author": "Jules Verne" } }
        /// </para>
        /// <para>
        ///  Example7: { "specifications": { "pageCount": 183 } }
        /// </para>
        /// <para>
        ///  Example8: { "specifications": { "illustrator": "Édouard Riou" } }
        /// </para>
        /// <para>
        ///  Example9: { "specifications": { "genres": "Adventure" } }
        /// </para>
        ///  </remarks> 
        ///  
        /// <example>After class initialisation, call this method:
        /// <code>
        /// { "id": 2}
        /// </code>
        /// </example>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST  
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <returns>resultado list book</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  List<Book> GetAll([FromBody] Book item, string order)
        {
            return GenericService.GetAll(item, order);
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