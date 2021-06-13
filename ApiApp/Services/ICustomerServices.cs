using ApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerDto>> GetCustomer();
        Task<IEnumerable<CustomerDto>> GetCustomersByCategory(string Category);
        Task<IEnumerable<string>> GetCustomerCategories();
    }
}
