using CompaniesAPI.Entities;

namespace CompaniesAPI.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyWithAddressesAsync(int companyId);
        Task<List<Company>> GetCompaniesWithAddressesAsync();
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> GetCompanyByIdAsync(int id);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(Company company);
    }
}
