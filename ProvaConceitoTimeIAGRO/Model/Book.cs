using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProvaConceitoTimeIAGRO.Model
{
    /// <summary>
    /// Class Book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [JsonProperty("Id")]
        public long Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("Price")]
        public long Price { get; set; }

        /// <summary>
        /// Specifications
        /// </summary>
        [JsonProperty("Specifications")]
        public Specifications Specifications { get; set; }
    }
}