using System;
using PostAPI.Persistence.Repository;
using PostAPI.Models;
using PostAPI.Persistence.Context;
using System.Threading.Tasks;

namespace PostAPI.Persistence.Repository
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            
        }
    }
}
