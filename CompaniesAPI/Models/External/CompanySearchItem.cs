using Newtonsoft.Json;

namespace CompaniesAPI.Models.External;
public class CompanySearchItem
{
    [JsonProperty("company_number")]
    public string CompanyNumber { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("address_snippet")]
    public string AddressSnippet { get; set; } = string.Empty;
}