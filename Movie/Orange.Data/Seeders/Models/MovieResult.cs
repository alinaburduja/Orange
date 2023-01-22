using Newtonsoft.Json;

namespace Orange.Data.Seeders.Models
{
    public class MovieResult
    {
        public int Page { get; set; }
        public MovieDescription[] Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
