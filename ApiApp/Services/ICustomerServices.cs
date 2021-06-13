using ApiApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiApp.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<IEnumerable<CustomerDto>> GetCustomersByCategory(string Category);
        Task<IEnumerable<string>> GetCustomerCategories();
    }
}
