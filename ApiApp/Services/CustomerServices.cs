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
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            var customers = await _db.Customers.ToListAsync(); 

            return customers;
        }

        public Task<IEnumerable<string>> GetCustomerCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetCustomersByCategory(string Category)
        {
            throw new NotImplementedException();
        }
    }
}
