using Newtonsoft.Json.Linq;
using ProvaConceitoTimeIAGRO.Exceptions;
using ProvaConceitoTimeIAGRO.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaConceitoTimeIAGRO.Utils
{
    /// <summary>
    /// Class Util
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Method Existe
        /// </summary>
        /// <param name="param1">string[]</param>
        /// <param name="param2">string</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        private static bool Existe(string[] param1, string param2)
        {
            try
            {
                bool result = false;
                foreach (string item in param1)
                {
                    if (item.Contains(param2))
                    {
                        result = true;
                    }
                }

                return result;

            }
            catch (ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method Existe Genres
        /// </summary>
        /// <param name="genres">dynamic</param>
        /// <param name="book">Model Book</param>
        /// <returns>Resultado em bool</returns>
        /// <exception cref="System.Exception"></exception>
        private static bool ExisteGenres(dynamic genres, Book book)
        {
            try
            {
                bool result = false;

                if (genres != null)
                {
                    if (book?.Specifications?.Genres is string)
                    {
                        string gen = book?.Specifications?.Genres;

                        if (gen.Contains(genres))
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        if (book?.Specifications?.Genres != null && 
                            Existe(book?.Specifications?.Genres, genres))
                        {
                            result = true;
                        }
                    }
                }

                return result;

            }
            catch (ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method Existe Illustrator
        /// </summary>
        /// <param name="illustrator">dynamic</param>
        /// <param name="book">Model Book</param>
        /// <returns>Resultado em bool</returns>
        /// <exception cref="System.Exception"></exception>
        private static bool ExisteIllustrator(dynamic illustrator, Book book)
        {
            try
            {
                bool result = false;

                if (illustrator != null)
                {
                    if (book?.Specifications?.Illustrator is string)
                    {
                        string illustratorArray = book?.Specifications?.Illustrator;

                        if (illustratorArray.Contains(illustrator))
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        if (book?.Specifications?.Illustrator != null && 
                            Existe(book.Specifications?.Illustrator, illustrator))
                        {
                            result = true;
                        }

                    }
                }

                return result;

            }
            catch (ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method Filtrar
        /// </summary>
        /// <param name="books">List Book</param>
        /// <param name="genres">dynamic</param>
        /// <param name="illustrator">dynamic</param>
        /// <returns>resultado em List Book</returns>
        /// <exception cref="System.Exception"></exception>
        public static List<Book> Filtrar(List<Book> books, dynamic genres, dynamic illustrator)
        {
            try
            {
                List<Book> result = new List<Book>();

                foreach (var item in books)
                {
                    if (ExisteGenres(genres, item))
                    {
                        result.Add(item);
                    }

                    if (ExisteIllustrator(illustrator, item))
                    {
                        result.Add(item);
                    }
                }

                return result.Distinct().ToList();
            }
            catch (ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method Is Not Default
        /// </summary>
        /// <param name="book">Model Book</param>
        /// <returns>Resultado em bool</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool IsNotDefault(Book book)
        {
            try
            {
                bool result = false;

                if (!string.IsNullOrWhiteSpace(book.Name) ||
                        book.Id > 0 ||
                        book.Price > 0 ||
                        !string.IsNullOrWhiteSpace(book?.Specifications?.Author) ||
                        book?.Specifications?.PageCount > 0 ||
                        !string.IsNullOrWhiteSpace(book?.Specifications?.OriginallyPublished)
                        )
                {
                    result = true;
                }

                return result;
            }
            catch (ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method Get Valor
        /// </summary>
        /// <param name="parametro">dynamic</param>
        /// <returns>Resultado string/string[]</returns>
        public static dynamic GetValor(dynamic parametro)
        {

            if (parametro is string)
            {
                return parametro.ToString();
            }

            else if (parametro is JArray)
            {
                return parametro.ToObject<string[]>();

            }

            else
            {
                Array array = parametro as Array;

                if (array != null)
                {
                    return array;
                }
                else
                {

                    return parametro?.ToString();
                }
            }
        }
    }
}