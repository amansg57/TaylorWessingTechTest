namespace CompaniesWeb.Models;
public class CompanyDetailsViewModel
{
    public string CompanyName { get; set; }
    public string CompanyNumber { get; set; }
    public string CompanyStatus { get; set; }
    public string CompanyStatusDetail { get; set; }
    public DateTime DateOfCreation { get; set; }
    public string Jurisdiction { get; set; }
    public string Type { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public IList<AddressViewModel> Addresses { get; set; }
}