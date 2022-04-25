using IAGRO.Domain.Decorator;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IAGRO.Domain.Entities
{
    public class Specifications
    {
        [JsonPropertyName("Originally published")]
        public string OriginallyPublished { get; set; }
        [JsonPropertyName("Author")]
        public string Author { get; set; }
        [JsonPropertyName("Page count")]
        public int PageCount { get; set; }
        [JsonPropertyName("Illustrator")]
        [JsonConverter(typeof(StringOrArrayConverterDecorator<string>))]
        public List<string> Illustrator { get; set; }
        [JsonPropertyName("Genres")]
        [JsonConverter(typeof(StringOrArrayConverterDecorator<string>))]
        public List<string> Genres { get; set; }
    }
}
