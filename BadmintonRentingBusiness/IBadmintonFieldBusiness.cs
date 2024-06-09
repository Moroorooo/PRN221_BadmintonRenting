using BadmintonRentingBusiness.Base;
using BadmintonRentingData.DTO;

namespace BadmintonRentingBusiness
{
    public interface IBadmintonFieldBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(long id);
        //Task<IBusinessResult> Create(BadmintonFieldRequestDTO newBadmintonField);
        Task<IBusinessResult> Update(long id, CustomerRequestDTO newBadmintonField);
        Task<IBusinessResult> DeleteById(long id);
    }
}
