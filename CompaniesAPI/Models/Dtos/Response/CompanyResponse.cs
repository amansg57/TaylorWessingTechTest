namespace CompaniesAPI.Models.Dtos.Response;
public class CompanyResponse
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyNumber { get; set; }
    public string CompanyStatus { get; set; }
    public string CompanyStatusDetail { get; set; } = string.Empty;
    public DateTime DateOfCreation { get; set; }
    public string Jurisdiction { get; set; }
    public string Type { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<AddressResponse> Addresses { get; set; }
}