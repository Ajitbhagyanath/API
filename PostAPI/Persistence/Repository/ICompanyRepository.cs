using System;
using System.Threading.Tasks;
using PostAPI.Models;
namespace PostAPI.Persistence.Repository
{
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);
    }
}
