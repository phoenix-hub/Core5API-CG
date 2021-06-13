using ApiApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Services
{
    public class CustomerServices : ICustomerServices
    { 

        private readonly WideWorldImportersContext _db;

        public CustomerServices(WideWorldImportersContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<CustomerDto>> GetCustomer()
        {
            var customers = await _db.Customers.ToListAsync(); 

            return customers;
        }

        public async Task<IEnumerable<string>> GetCustomerCategories()
        {
            var customers = await _db.Customers.Select(x=> x.CustomerCategoryName).Distinct().ToListAsync();

            return customers;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersByCategory(string Category)
        {
            var customers = await _db.Customers.Where(x => x.CustomerCategoryName== Category).ToListAsync();

            return customers;
        }
    }
}
