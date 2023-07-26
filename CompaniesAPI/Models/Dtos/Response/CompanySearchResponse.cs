using Newtonsoft.Json;

namespace CompaniesAPI.Models.Dtos.Response;
public class CompanySearchResponse
{
    public List<CompanySearchResponseItem> Items { get; set; } = new();
}