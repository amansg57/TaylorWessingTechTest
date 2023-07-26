namespace CompaniesAPI.Models.Dtos.Request;
public class CreateCompanyRequest
{
    public string CompanyNumber { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
