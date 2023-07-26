using CompaniesAPI.Models.Dtos.Request;
using CompaniesWeb.Models;
using CompaniesWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesWeb.Controllers;

public class CompaniesWebController : Controller
{
    private readonly CompaniesApiService _companiesApiService;

    public CompaniesWebController(CompaniesApiService companiesApiService)
    {
        _companiesApiService = companiesApiService;
    }

    [HttpGet]
    public async Task<IActionResult> SearchCompanies([FromQuery] string companyName)
    {
        var searchResults = await _companiesApiService.SearchCompanies(companyName);
        return Json(searchResults);
    }

    public IActionResult RegisterCompany()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> RegisterCompany(RegisterCompanyViewModel model)
    {
        if (ModelState.IsValid)
        {
            var company = await _companiesApiService.CreateCompany(new CreateCompanyRequest
            {
                CompanyNumber = model.CompanyNumber,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            });

            if (company != null)
            {
                return RedirectToAction("CompanyDetails", new { id = company.CompanyId });
            }
        }

        return View(model);
    }

    public async Task<ActionResult> CompanyDetails(int id)
    {
        var company = await _companiesApiService.GetCompanyById(id);

        if (company == null)
        {
            return NotFound();
        }

        var viewModel = new CompanyDetailsViewModel
        {
            CompanyName = company.CompanyName,
            CompanyNumber = company.CompanyNumber,
            CompanyStatus = company.CompanyStatus,
            CompanyStatusDetail = company.CompanyStatusDetail,
            DateOfCreation = company.DateOfCreation,
            Jurisdiction = company.Jurisdiction,
            Type = company.Type,
            Email = company.Email,
            PhoneNumber = company.PhoneNumber,
            Addresses = company.Addresses.Select(a => new AddressViewModel
            {
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                Country = a.Country,
                Locality = a.Locality,
                PostalCode = a.PostalCode,
                CareOf = a.CareOf,
                PoBox = a.PoBox,
                Premises = a.Premises,
                Region = a.Region,
                AddressType = a.AddressType
            }).ToList()
        };

        return View(viewModel);
    }

    public async Task<IActionResult> ListCompanies()
    {
        var companies = await _companiesApiService.GetAllCompanies();

        var viewModel = new CompanyListViewModel
        {
            Items = companies.Items.Select(x => new CompanyListItemViewModel
            {
                CompanyId = x.CompanyId,
                CompanyName = x.CompanyName,
                CompanyNumber = x.CompanyNumber,
                Email = x.Email,
                Jurisdiction = x.Jurisdiction
            }).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        try
        {
            await _companiesApiService.DeleteCompany(id);
            return RedirectToAction("ListCompanies");
        }
        catch (Exception ex)
        {
            return View("Error");
        }
    }
}
