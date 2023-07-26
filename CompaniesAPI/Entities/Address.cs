using CompaniesAPI.Enums;

namespace CompaniesAPI.Entities;
public class Address
{
    public int AddressId { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? Country { get; set; }
    public string? Locality { get; set; }
    public string? PostalCode { get; set; }
    public string? CareOf { get; set; }
    public string? PoBox { get; set; }
    public string? Premises { get; set; }
    public string? Region { get; set; }
    public AddressType AddressType { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
}