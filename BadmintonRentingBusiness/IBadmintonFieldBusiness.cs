using BadmintonRentingBusiness.Base;
using BadmintonRentingData.DTO;

namespace BadmintonRentingBusiness
{
    public interface IBadmintonFieldBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(long id);
        Task<IBusinessResult> Create(BadmintonFieldRequestDTO newBadmintonField);
        Task<IBusinessResult> Update(long id, BadmintonFieldRequestDTO newBadmintonField);
        Task<IBusinessResult> DeleteById(long id);
    }
}
