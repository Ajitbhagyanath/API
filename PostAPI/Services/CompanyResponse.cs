using System;
using PostAPI.Models;
namespace PostAPI.Services
{
    public class CompanyResponse : BaseResponse<Company>
    {
        public CompanyResponse(Company company) : base(company)
        { }

        
        public CompanyResponse(string message) : base(message)
        { }
    }
}
