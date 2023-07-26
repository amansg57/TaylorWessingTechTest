using CompaniesAPI.Exceptions;
using CompaniesAPI.Models.Dtos.Request;
using CompaniesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesAPI.Controllers;

[ApiController]
[Route("companies")]
public class CompaniesController : ControllerBase
{
    private readonly CompaniesService _companiesService;

    public CompaniesController(CompaniesService companiesService)
    {
        _companiesService = companiesService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        try
        {
            var company = await _companiesService.GetCompanyById(id);
            return Ok(company);
        }
        catch (ExternalApiUnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (ExternalApiNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ExternalApiException ex)
        {
            return StatusCode(ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateCompany(CreateCompanyRequest createCompanyRequest)
    {
        try
        {
            var company = await _companiesService.CreateCompany(createCompanyRequest);
            return Ok(company);
        }
        catch (ExternalApiUnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (ExternalApiNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ExternalApiException ex)
        {
            return StatusCode(ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
 
    [HttpGet]
    [Route("search/{companyName}")]
    public async Task<IActionResult> SearchCompanies(string companyName)
    {
        try
        {
            var company = await _companiesService.SearchCompanies(companyName);
            return Ok(company);
        }
        catch (ExternalApiUnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (ExternalApiNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ExternalApiException ex)
        {
            return StatusCode(ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllCompanies()
    {
        try
        {
            var companies = await _companiesService.GetAllCompanies();
            return Ok(companies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        try
        {
            await _companiesService.DeleteCompany(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}