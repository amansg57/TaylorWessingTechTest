namespace CompaniesAPI.Entities;
public class Company
{
    public int CompanyId { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string CompanyName { get; set; }
    public string CompanyNumber { get; set; }
    public string CompanyStatus { get; set; }
    public DateTime DateOfCreation { get; set; }
    public string Jurisdiction { get; set; }
    public string Type { get; set; }
    public ICollection<Address> Addresses { get; set; }
}