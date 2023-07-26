using CompaniesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompaniesAPI.Repositories;
public class CompanyRepository : ICompanyRepository
{
    private readonly CompaniesDbContext _context;

    public CompanyRepository(CompaniesDbContext context)
    {
        _context = context;
    }

    public async Task<Company> GetCompanyWithAddressesAsync(int companyId)
    {
        return await _context.Companies.Include(c => c.Addresses).FirstOrDefaultAsync(c => c.CompanyId == companyId);
    }
    
    public async Task<List<Company>> GetCompaniesWithAddressesAsync()
    {
        return await _context.Companies.Include(c => c.Addresses).ToListAsync();
    }

    public async Task<Company> CreateCompanyAsync(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<Company> GetCompanyByIdAsync(int id)
    {
        return await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
    }

    public async Task UpdateCompanyAsync(Company company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCompanyAsync(Company company)
    {
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }
}
