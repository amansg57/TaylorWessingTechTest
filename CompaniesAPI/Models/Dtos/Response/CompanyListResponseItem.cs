namespace CompaniesAPI.Models.Dtos.Response;
public class CompanyListResponseItem
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyNumber { get; set; }
    public string Email { get; set; }
    public string Jurisdiction { get; set; }
}