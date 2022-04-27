using ProvaConceitoTimeIAGRO.Exceptions;
using System.Reflection;

namespace ProvaConceitoTimeIAGRO.ExtensionMethod
{
    /// <summary>
    /// Class Extension
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Method Extensão Is Null Or Empty
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="parametro">string</param>
        /// <returns>retorno bool</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool IsNullValue(this object obj, string parametro)
        {
            try
            {
                bool retorno = false;

                if (obj != null && parametro != null)
                {
                    PropertyInfo[] info = obj.GetType().GetProperties();

                    if (obj is string)
                    {
                        if (obj.ToString().Contains(parametro))
                        {
                            retorno = true;
                        }
                    }
                }

                return retorno;
            }
            catch (ExceptionsMessage ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}