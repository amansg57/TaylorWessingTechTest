using System.Net;
using System.Text;
using CompaniesAPI.Exceptions;
using CompaniesAPI.Models.External;
using Newtonsoft.Json;

namespace CompaniesAPI.Services;
public class CompaniesHouseApiClient
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;
    public CompaniesHouseApiClient(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _apiKey = _configuration["AppSettings:ApiKey"];
        _baseUrl = _configuration["AppSettings:CompaniesHouseApiUrl"];

        // Assign encoded API key to Authorization header
    }

    public Task<CompanyProfile> GetCompanyProfile(string companyNumber)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/company/{companyNumber}");

        return GetResponse<CompanyProfile>(request);
    }

    public Task<CompanySearch> SearchCompanies(string companyName, int itemsPerPage = 10)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/search/companies?q={companyName}&items_per_page={itemsPerPage}");

        return GetResponse<CompanySearch>(request);
    }

    public async Task<T> GetResponse<T>(HttpRequestMessage request)
    {
        var byteArray = Encoding.ASCII.GetBytes($"{_apiKey}:");
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        HttpResponseMessage response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string jsonContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
        else if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new ExternalApiUnauthorizedException("Invalid API key");
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new ExternalApiNotFoundException("Company not found");
        }
        else
        {
            throw new ExternalApiException($"Error calling Companies House API: {response.StatusCode}");
        }
    }
}