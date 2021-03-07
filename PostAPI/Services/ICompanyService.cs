using System.Threading.Tasks;
using PostAPI.Models;
namespace PostAPI.Services
{
    public interface ICompanyService
    {
        Task<CompanyResponse> SaveAsync(Company company);
    }
}
