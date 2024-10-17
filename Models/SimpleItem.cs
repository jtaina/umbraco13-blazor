using Newtonsoft.Json;

namespace Models
{

    public class SimpleItem
    {
        // [JsonProperty("id")]
        public Guid Id { get; set; }
        // [JsonProperty("name")]
        public string? Name { get; set; }
        // [JsonProperty("description")]
        public string? Description { get; set; }
        // [JsonProperty("price")]
        public decimal Price { get; set; }
        // [JsonProperty("available")]
        public bool Available { get; set; }
        // [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

}
