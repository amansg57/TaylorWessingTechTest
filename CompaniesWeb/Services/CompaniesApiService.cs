using CompaniesAPI.Models.Dtos.Request;
using CompaniesAPI.Models.Dtos.Response;

namespace CompaniesWeb.Services;

public class CompaniesApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CompaniesApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<CompanyResponse> CreateCompany(CreateCompanyRequest createCompanyRequest)
    {
        var path = $"{_configuration["AppSettings:CompaniesUrl"]}/companies/create";
        var response = await _httpClient.PostAsJsonAsync($"{_configuration["AppSettings:CompaniesUrl"]}/companies/create", createCompanyRequest);

        return await HandleResponseAsync<CompanyResponse>(response);
    }

    public async Task<CompanySearchResponse> SearchCompanies(string companyName)
    {
        var response = await _httpClient.GetAsync($"{_configuration["AppSettings:CompaniesUrl"]}/companies/search/{companyName}");

        return await HandleResponseAsync<CompanySearchResponse>(response);
    }

    public async Task<CompanyResponse> GetCompanyById(int id)
    {
        var response = await _httpClient.GetAsync($"{_configuration["AppSettings:CompaniesUrl"]}/companies/{id}");

        return await HandleResponseAsync<CompanyResponse>(response);
    }

    public async Task<CompanyListResponse> GetAllCompanies()
    {
        var response = await _httpClient.GetAsync($"{_configuration["AppSettings:CompaniesUrl"]}/companies/all");

        return await HandleResponseAsync<CompanyListResponse>(response);
    }

    public async Task DeleteCompany(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_configuration["AppSettings:CompaniesUrl"]}/companies/{id}");

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
    }

    private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
    }
}