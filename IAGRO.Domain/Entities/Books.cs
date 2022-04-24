using System.Text.Json.Serialization;

namespace IAGRO.Domain.Entities
{
    public class Books
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("specifications")]
        public Specifications Specifications { get; set; }
    }
}
