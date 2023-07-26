using CompaniesAPI.Models.Dtos.Request;
using CompaniesAPI.Models.Dtos.Response;
using CompaniesAPI.Models.External;
using CompaniesAPI.Repositories;

namespace CompaniesAPI.Services;
public class CompaniesService
{
    private readonly CompaniesHouseApiClient _companiesHouseApiClient;
    private readonly CompaniesMapper _companiesMapper;
    private readonly ICompanyRepository _companyRepository;
    public CompaniesService(CompaniesHouseApiClient companiesHouseApiClient, CompaniesMapper companiesMapper, ICompanyRepository companyRepository)
    {
        _companiesHouseApiClient = companiesHouseApiClient;
        _companiesMapper = companiesMapper;
        _companyRepository = companyRepository;
    }

    public async Task<CompanyResponse> CreateCompany(CreateCompanyRequest createCompanyRequest)
    {
        var companyProfile = await _companiesHouseApiClient.GetCompanyProfile(createCompanyRequest.CompanyNumber);
        var company = _companiesMapper.MapCreateCompanyRequestToCompany(createCompanyRequest, companyProfile);
        company = await _companyRepository.CreateCompanyAsync(company);

        return _companiesMapper.MapCompanyToCompanyResponse(company);
    }

    public async Task<CompanySearchResponse> SearchCompanies(string companyName)
    {
        var companySearch = await _companiesHouseApiClient.SearchCompanies(companyName);

        return _companiesMapper.MapCompanySearch(companySearch);
    }

    public async Task<CompanyResponse> GetCompanyById(int id)
    {
        var company = await _companyRepository.GetCompanyWithAddressesAsync(id);

        if (company == null)
        {
            return null;
        }

        return _companiesMapper.MapCompanyToCompanyResponse(company);
    }

    public async Task<CompanyListResponse> GetAllCompanies()
    {
        var companies = await _companyRepository.GetCompaniesWithAddressesAsync();

        return _companiesMapper.MapCompaniesToCompanyListResponse(companies);
    }

    public async Task DeleteCompany(int id)
    {
        var company = await _companyRepository.GetCompanyByIdAsync(id);

        if (company == null)
        {
            throw new KeyNotFoundException($"Company with id {id} not found");
        }

        await _companyRepository.DeleteCompanyAsync(company);
    }
}