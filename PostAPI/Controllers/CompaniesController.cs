using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostAPI.Models;
using PostAPI.Services;
namespace PostAPI.Controllers
{
    [Route("/api/companies")]
    [Produces("application/json")]
    //[ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            try
            {

                if (!ModelState.IsValid )
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var ms in ModelState.Values)
                    {
                        foreach (var modelError in ms.Errors)
                        {
                            sb.AppendLine(modelError.ErrorMessage);
                        }
                    }
                    return new JsonResult(new { status = 1, errorMsg = sb.ToString() });
                }
                else

                    Validate(company);
                //save to DB context
                if (_companyService != null)
                {
                    var result = await _companyService.SaveAsync(company);
                    if (!result.Success)
                    {
                        return BadRequest(result.Message);
                    }
                    else return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
            
        }
        
        private static void Validate(Company company)
            {

                var errors = new List<string>();

                if (!company.companyName.StartsWith("Company Name:")
                || company.companyName.Length < 5
                || company.companyName.Length > 35)
                {
                    errors.Add("CompanyName is invalid: CompanyName must contain a minimum  of 5 characters and maximum of 35 and it must start with Company Name:");
                }

                if (company.numberOfEmployees <= 1)
                {
                    errors.Add("NumberOfEmployees is invalid: NumberOfEmployees must be greater than 1");
                }
                if (company.averageSalary <= 0)
                {
                    errors.Add("AverageSalary is invalid: AverageSalary must be greater than 0");
                }
            
                if (errors.Count > 0)
                {
                    var errorBuilder = new StringBuilder();

                    foreach (var error in errors)
                    {
                        errorBuilder.AppendLine(error);
                    }

                    throw new Exception(errorBuilder.ToString());
                }
            }
        
    }
}
