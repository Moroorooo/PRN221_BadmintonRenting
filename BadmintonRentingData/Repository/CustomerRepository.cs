using BadmintonRentingData.Base;
using BadmintonRentingData.Model;

namespace BadmintonRentingData.Repository
{

    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository() { }

        public CustomerRepository(Net1702_PRN221_BadmintonRentingContext context) => _context = context;

        public async Task<int> CreateAsync(BadmintonField newBadmintonField)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(BadmintonField badmintonField)
        {
            throw new NotImplementedException();
        }
    }
}
