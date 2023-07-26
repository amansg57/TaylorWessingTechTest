using Newtonsoft.Json;

namespace CompaniesAPI.Models.External;
public class CompanySearch
{
    [JsonProperty("items")]
    public List<CompanySearchItem> Items { get; set; }
}