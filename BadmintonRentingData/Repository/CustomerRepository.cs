using BadmintonRentingCommon;
using BadmintonRentingData.Base;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingData.Repository
{

    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository() { }

        public CustomerRepository(Net1702_PRN221_BadmintonRentingContext context) => _context = context;

        public async Task<List<Customer>> SearchByNameByEmailByPhone(string name, string email, int? phone)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.CustomerName.Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(c => c.Email.Contains(email));
            }

            if (phone.HasValue)
            {
                query = query.Where(c => c.Phone == phone.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<PagedResult<Customer>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Customers.AsQueryable();
            var totalCount = await query.CountAsync();
            var customers = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<Customer>
            {
                Items = customers,
                TotalCount = totalCount
            };
        }
    }
}
