using BadmintonRentingData.Base;
using BadmintonRentingData.Model;

namespace BadmintonRentingData.Repository
{
    public class BadmintonFieldReposiory : GenericRepository<BadmintonField>
    {
        public BadmintonFieldReposiory()
        {

        }

        public BadmintonFieldReposiory(Net1702_PRN221_BadmintonRentingContext context) => _context = context;
    }
}
