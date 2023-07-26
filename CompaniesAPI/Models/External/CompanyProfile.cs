using Newtonsoft.Json;

namespace CompaniesAPI.Models.External;
public class CompanyProfile
{
    [JsonProperty("company_name")]
    public string CompanyName { get; set; }

    [JsonProperty("company_number")]
    public string CompanyNumber { get; set; }

    [JsonProperty("company_status")]
    public string CompanyStatus { get; set; }

    [JsonProperty("date_of_creation")]
    public DateTime DateOfCreation { get; set; }

    [JsonProperty("jurisdiction")]
    public string Jurisdiction { get; set; }

    [JsonProperty("registered_office_address")]
    public CompanyProfileAddress? RegisteredOfficeAddress { get; set; }
    
    [JsonProperty("service_address")]
    public CompanyProfileAddress? ServiceAddress { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}