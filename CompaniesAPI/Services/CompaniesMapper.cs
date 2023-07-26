using CompaniesAPI.Entities;
using CompaniesAPI.Enums;
using CompaniesAPI.Models.Dtos.Request;
using CompaniesAPI.Models.Dtos.Response;
using CompaniesAPI.Models.External;

namespace CompaniesAPI.Services;

public class CompaniesMapper
{
    public Company MapCompanyProfileToCompany(CompanyProfile companyProfile)
    {
        throw new NotImplementedException();
    }

    public Company MapCreateCompanyRequestToCompany(CreateCompanyRequest createCompanyRequest, CompanyProfile companyProfile)
    {
        Company company = new()
        {
            CompanyNumber = createCompanyRequest.CompanyNumber,
            Email = createCompanyRequest.Email,
            PhoneNumber = createCompanyRequest.PhoneNumber,
            CompanyName = companyProfile.CompanyName,
            CompanyStatus = companyProfile.CompanyStatus,
            DateOfCreation = companyProfile.DateOfCreation,
            Jurisdiction = companyProfile.Jurisdiction,
            Type = companyProfile.Type
        };

        company.Addresses = new List<Address>();

        if (companyProfile.ServiceAddress != null)
            company.Addresses.Add(MapCompanyProfileAddressToAddress(companyProfile.ServiceAddress, AddressType.Service));

        if (companyProfile.RegisteredOfficeAddress != null)
            company.Addresses.Add(MapCompanyProfileAddressToAddress(companyProfile.RegisteredOfficeAddress, AddressType.Registered_Office));

        return company;
    }

    public Address MapCompanyProfileAddressToAddress(CompanyProfileAddress companyProfileAddress, AddressType addressType)
    {
        Address address = new()
        {
            AddressLine1 = companyProfileAddress.AddressLine1,
            AddressLine2 = companyProfileAddress.AddressLine2,
            CareOf = companyProfileAddress.CareOf,
            Country = companyProfileAddress.Country,
            Locality = companyProfileAddress.Locality,
            PoBox = companyProfileAddress.PoBox,
            PostalCode = companyProfileAddress.PostalCode,
            Premises = companyProfileAddress.Premises,
            Region = companyProfileAddress.Region,
            AddressType = addressType
        };

        return address;
    }

    public CompanyResponse MapCompanyToCompanyResponse(Company company)
    {
        CompanyResponse companyResponse = new()
        {
            CompanyId = company.CompanyId,
            CompanyNumber = company.CompanyNumber,
            CompanyName = company.CompanyName,
            CompanyStatus = CompanyStatusEnumToText[company.CompanyStatus],
            DateOfCreation = company.DateOfCreation,
            Email = company.Email ?? string.Empty,
            Jurisdiction = JurisdictionEnumToText[company.Jurisdiction],
            PhoneNumber = company.PhoneNumber ?? string.Empty,
            Type = CompanyTypeEnumToText[company.Type]
        };

        companyResponse.Addresses = new List<AddressResponse>();

        if (company.Addresses != null)
        {
            foreach (var address in company.Addresses)
            {
                companyResponse.Addresses.Add(MapAddressToAddressResponse(address));
            }
        }

        return companyResponse;
    }

    public CompanyListResponse MapCompaniesToCompanyListResponse(List<Company> companies)
    {
        CompanyListResponse companyListResponse = new();

        companyListResponse.Items = companies.Select(c => MapCompanyToCompanyListResponseItem(c)).ToList();

        return companyListResponse;
    }

    private CompanyListResponseItem MapCompanyToCompanyListResponseItem(Company company)
    {
        return new CompanyListResponseItem
        {
            CompanyId = company.CompanyId,
            CompanyNumber = company.CompanyNumber,
            CompanyName = company.CompanyName,
            Email = company.Email ?? string.Empty,
            Jurisdiction = JurisdictionEnumToText[company.Jurisdiction]
        };
    }

    private AddressResponse MapAddressToAddressResponse(Address address)
    {
        AddressResponse addressResponse = new()
        {
            AddressId = address.AddressId,
            AddressLine1 = address.AddressLine1 ?? string.Empty,
            AddressLine2 = address.AddressLine2 ?? string.Empty,
            Country = address.Country ?? string.Empty,
            Locality = address.Locality ?? string.Empty,
            PostalCode = address.PostalCode ?? string.Empty,
            CareOf = address.CareOf ?? string.Empty,
            PoBox = address.PoBox ?? string.Empty,
            Premises = address.Premises ?? string.Empty,
            Region = address.Region ?? string.Empty,
            AddressType = address.AddressType.ToString().Replace("_", " ")
        };

        return addressResponse;
    }

    public CompanySearchResponse MapCompanySearch(CompanySearch companySearch)
    {
        CompanySearchResponse companySearchResponse = new();

        companySearchResponse.Items = companySearch.Items.Select(c => MapCompanySearchItemToCompanySearchResponse(c)).ToList();

        return companySearchResponse;
    }

    private CompanySearchResponseItem MapCompanySearchItemToCompanySearchResponse(CompanySearchItem companySearchItem)
    {
        CompanySearchResponseItem companySearchResponseItem = new()
        {
            CompanyNumber = companySearchItem.CompanyNumber,
            Title = companySearchItem.Title,
            AddressSnippet = companySearchItem.AddressSnippet
        };

        return companySearchResponseItem;
    }

    private Dictionary<string, string> CompanyTypeEnumToText = new Dictionary<string, string>
    {
        {"private-unlimited", "Private unlimited company"},
        {"ltd", "Private limited company"},
        {"plc", "Public limited company"},
        {"old-public-company", "Old public company"},
        {"private-limited-guarant-nsc-limited-exemption", "Private Limited Company by guarantee without share capital, use of 'Limited' exemption"},
        {"limited-partnership", "Limited partnership"},
        {"private-limited-guarant-nsc", "Private limited by guarantee without share capital"},
        {"converted-or-closed", "Converted / closed"},
        {"private-unlimited-nsc", "Private unlimited company without share capital"},
        {"private-limited-shares-section-30-exemption", "Private Limited Company, use of 'Limited' exemption"},
        {"protected-cell-company", "Protected cell company"},
        {"assurance-company", "Assurance company"},
        {"oversea-company", "Overseas company"},
        {"eeig-establishment", "European Economic Interest Grouping Establishment (EEIG)"},
        {"icvc-securities", "Investment company with variable capital"},
        {"icvc-warrant", "Investment company with variable capital"},
        {"icvc-umbrella", "Investment company with variable capital"},
        {"registered-society-non-jurisdictional", "Registered society"},
        {"industrial-and-provident-society", "Industrial and Provident society"},
        {"northern-ireland", "Northern Ireland company"},
        {"northern-ireland-other", "Credit union (Northern Ireland)"},
        {"llp", "Limited liability partnership"},
        {"royal-charter", "Royal charter company"},
        {"investment-company-with-variable-capital", "Investment company with variable capital"},
        {"unregistered-company", "Unregistered company"},
        {"other", "Other company type"},
        {"european-public-limited-liability-company-se", "European public limited liability company (SE)"},
        {"united-kingdom-societas", "United Kingdom Societas"},
        {"uk-establishment", "UK establishment company"},
        {"scottish-partnership", "Scottish qualifying partnership"},
        {"charitable-incorporated-organisation", "Charitable incorporated organisation"},
        {"scottish-charitable-incorporated-organisation", "Scottish charitable incorporated organisation"},
        {"further-education-or-sixth-form-college-corporation", "Further education or sixth form college corporation"},
        {"eeig", "European Economic Interest Grouping (EEIG)"},
        {"ukeig", "United Kingdom Economic Interest Grouping"},
        {"registered-overseas-entity", "Overseas entity"}
    };

    private Dictionary<string, string> JurisdictionEnumToText = new Dictionary<string, string>()
    {
        {"england-wales", "England/Wales"},
        {"wales", "Wales"},
        {"scotland", "Scotland"},
        {"northern-ireland", "Northern Ireland"},
        {"european-union", "European Union"},
        {"united-kingdom", "United Kingdom"},
        {"england", "England"},
        {"noneu", "Foreign (Non E.U.)"}
    };
    
    private Dictionary<string, string> CompanyStatusEnumToText = new Dictionary<string, string>()
    {
        {"active", "Active"},
        {"dissolved", "Dissolved"},
        {"liquidation", "Liquidation"},
        {"receivership", "Receiver Action"},
        {"converted-closed", "Converted / Closed"},
        {"voluntary-arrangement", "Voluntary Arrangement"},
        {"insolvency-proceedings", "Insolvency Proceedings"},
        {"administration", "In Administration"},
        {"open", "Open"},
        {"closed", "Closed"},
        {"registered", "Registered"},
        {"removed", "Removed"}
    };

}