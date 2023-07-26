using System.ComponentModel.DataAnnotations;

namespace CompaniesWeb.Models;
public class RegisterCompanyViewModel
{
    [Required]
    [Display(Name = "Company Number")]
    public string CompanyNumber { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [Phone]
    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Company Name")]
    public string CompanyName { get; set; }
}