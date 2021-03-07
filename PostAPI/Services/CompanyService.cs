using System;
using System.Threading.Tasks;
using PostAPI.Models;
using PostAPI.Persistence.Repository;

namespace PostAPI.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                return new CompanyResponse(company);
            }
            catch (Exception ex)
            {
                
                return new CompanyResponse($"An error occurred when saving the Company: {ex.Message}");
            }
        }
    }
}
