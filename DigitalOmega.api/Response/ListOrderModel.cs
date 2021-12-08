using Newtonsoft.Json;

namespace DigitalOmega.api.Response
{
    public class ListOrderModel
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "totalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty(PropertyName = "sortIndex")]
        public int SortIndex { get; set; } = -1;

        [JsonProperty(PropertyName = "search")]
        public string? Search { get; set; }

        [JsonProperty(PropertyName = "sortBy")]
        public string? SortBy { get; set; }

        [JsonProperty(PropertyName = "fromDate")]
        public DateTime? FromDate { get; set; }

        [JsonProperty(PropertyName = "toDate")]
        public DateTime? ToDate { get; set; }
    }
}
