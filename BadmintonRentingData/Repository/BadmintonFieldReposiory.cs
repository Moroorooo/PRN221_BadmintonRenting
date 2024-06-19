using BadmintonRentingData.Base;
using BadmintonRentingData.Model;

namespace BadmintonRentingData.Repository
{
    public class BadmintonFieldReposiory : GenericRepository<BadmintonField>
    {
        public BadmintonFieldReposiory()
        {

        }
        public async Task<int> DeleteAsync(BadmintonField entity)
        {
            _context.BadmintonFields.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public BadmintonFieldReposiory(Net1702_PRN221_BadmintonRentingContext context) => _context = context;
    }
}
