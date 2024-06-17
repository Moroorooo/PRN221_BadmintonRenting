using BadmintonRentingBusiness.Base;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;

namespace BadmintonRentingBusiness
{
    public interface IBadmintonFieldBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(long id);
        Task<IBusinessResult> Create(BadmintonFieldRequestDTO newBadmintonField);
        Task<IBusinessResult> Create(BadmintonField entity);
        Task<IBusinessResult> Update(long id, BadmintonFieldRequestDTO newBadmintonField);
        Task<IBusinessResult> DeleteById(long id);
        Task<IBusinessResult> GetById(long? id);
        Task<IBusinessResult> Update(long id, BadmintonField badmintonField);
    }
}
