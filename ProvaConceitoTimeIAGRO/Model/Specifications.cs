using Newtonsoft.Json.Linq;
using System;
using ProvaConceitoTimeIAGRO.Utils;
using Newtonsoft.Json;

namespace ProvaConceitoTimeIAGRO.Model
{
    /// <summary>
    /// Class Specifications
    /// </summary>
    public partial class Specifications
    {
        /// <summary>
        /// Originallly Published
        /// </summary>
        [JsonProperty( "Originally published")]
        public string OriginallyPublished { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        [JsonProperty("Author")]
        public string Author { get; set; }

        /// <summary>
        /// Page Count
        /// </summary>
        [JsonProperty("Page count")]
        public long PageCount { get; set; }

        /// <summary>
        /// _illustrator
        /// </summary>
        private dynamic _illustrator;

        /// <summary>
        /// Illustrator
        /// </summary>
        [JsonProperty("Illustrator")]
        public dynamic Illustrator
        {
            get { return _illustrator; }
            set { _illustrator = Util.GetValor(value); }
        }

        /// <summary>
        /// _genres
        /// </summary>
        private dynamic _genres;

        /// <summary>
        /// Genres
        /// </summary>
        [JsonProperty("Genres")]
        public dynamic Genres
        {
            get { return _genres; }
            set { _genres = Util.GetValor(value); }
        }
    }
}