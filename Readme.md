# Taylor Wessing Technical Test

### Prerequisites

- .NET 6.0 or later

### Set up

Set up a new empty SQL Server database

Navigate to the Companies House Developer API page (https://developer.company-information.service.gov.uk), create a new live application and an API key for this application.

In the CompaniesAPI project, set up your appsettings.Development.json file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }, 
  "AppSettings": {
    "ApiKey": "--YourCompaniesHouseApiKey--",
    "CompaniesHouseApiUrl": "https://api.companieshouse.gov.uk"
  },
  "ConnectionStrings": {
    "CompaniesDb": "--YourConnectionStringHere--"
  }
}
```

In the CompaniesWeb project, make sure your appsettings.Development.json file is set up correctly:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }, 
  "AppSettings": {
    "CompaniesUrl": "https://localhost:7235"
  }
}
```

### Initializing Database

In the root of the project, run the following command:

`dotnet ef database update --project CompaniesAPI`

### Running the Application

Start the API by running the following command:

`dotnet run --project CompaniesAPI`

Start the frontend application by running the following command in a new terminal:

`dotnet run --project CompaniesWeb`

Open a web browser and navigate to https://localhost:7022 to view the application.

You can also navigate to https://localhost:7235/swagger/index.html to view the swagger for the API.

## API Endpoints

#### GET /api/companies/{id}

Get the company response by id.

__Parameters__
- id (required): The id of the company to get.

__Example Response__

```json
{
  "CompanyId": 123,
  "CompanyName": "Example Company",
  "CompanyNumber": "COMPANY123",
  "CompanyStatus": "Active",
  "CompanyStatusDetail": "",
  "DateOfCreation": "2023-07-23T10:30:00Z",
  "Jurisdiction": "Some Jurisdiction",
  "Type": "Some Type",
  "Email": "",
  "PhoneNumber": "",
  "Addresses": [
    {
      "AddressId": 1,
      "AddressLine1": "123 Main Street",
      "AddressLine2": "",
      "Country": "Example Country",
      "Locality": "Example City",
      "PostalCode": "12345",
      "CareOf": "",
      "PoBox": "",
      "Premises": "",
      "Region": "",
      "AddressType": "Some Address Type"
    }
  ]
}
```

#### POST /api/companies/create

Create a new company.

__Example Request__
```json
{
  "CompanyNumber": "COMPANY123",
  "Email": "test@test.com",
  "PhoneNumber": "0777777777"
}
```

__Example Response__

```json
{
  "CompanyId": 123,
  "CompanyName": "Example Company",
  "CompanyNumber": "COMPANY123",
  "CompanyStatus": "Active",
  "CompanyStatusDetail": "",
  "DateOfCreation": "2023-07-23T10:30:00Z",
  "Jurisdiction": "Jurisdiction",
  "Type": "Type",
  "Email": "test@test.com",
  "PhoneNumber": "0777777777",
  "Addresses": [
    {
      "AddressId": 1,
      "AddressLine1": "123 Main Street",
      "AddressLine2": "",
      "Country": "Example Country",
      "Locality": "Example City",
      "PostalCode": "12345",
      "CareOf": "",
      "PoBox": "",
      "Premises": "",
      "Region": "",
      "AddressType": "Address Type"
    }
  ]
}
```

#### GET /api/companies/search/{companyName}

Searches for companies by name.

__Parameters__
- companyName (required): The name of the company to search for.

__Example Response__

```json
{
  "Items": [
    {
      "CompanyNumber": "COMPANY_NUMBER_1",
      "Title": "Company Title 1",
      "AddressSnippet": "Address 1"
    },
    {
      "CompanyNumber": "COMPANY_NUMBER_2",
      "Title": "Company Title 2",
      "AddressSnippet": "Address 2"
    }
  ]
}
```

#### GET /api/companies/all

Gets the list of all companies.

__Example Response__

```json
{
  "Items": [
    {
      "CompanyId": 1,
      "CompanyName": "Company A",
      "CompanyNumber": "COMPANY123",
      "Email": "companyA@example.com",
      "Jurisdiction": "Jurisdiction"
    },
    {
      "CompanyId": 2,
      "CompanyName": "Company B",
      "CompanyNumber": "COMPANY456",
      "Email": "companyB@example.com",
      "Jurisdiction": "Jurisdiction"
    }
  ]
}
```

#### DELETE /api/companies/{id}

Deletes the company with the specified ID.

__Parameters__
- id (required): The ID of the company to delete.

__Example Response__

```200 OK```

## Web Application
The web application provides a simple user interface for viewing and managing companies.

### Register Company

The `RegisterCompany` page allows the user to register a new company by entering the company number, email address, and phone number; the company number can also be found by searching the company name and selecting the correct option from a dropdown list. When the user clicks the "Register" button, the application sends a request to the API to create a new company. If the company is created successfully, the user is redirected to the `CompanyDetails` page.

### List Companies
The `ListCompanies` page displays a list of all companies in the database. Clicking on a company in the list will take the user to the `CompanyDetails` page for that company.

Each row in the table includes a delete button that allows the user to delete the corresponding company.

### Company Details
The `CompanyDetails` page displays detailed information about a single company. The user can edit the company's name and email address and save the changes by clicking the "Save" button.