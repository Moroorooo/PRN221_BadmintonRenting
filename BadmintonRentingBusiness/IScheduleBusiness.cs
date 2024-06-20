using BadmintonRentingBusiness.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadmintonRentingData.DTO;
namespace BadmintonRentingBusiness
{
    public interface IScheduleBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(long id);
        Task<IBusinessResult> Create(ScheduleDTO newSchedule);
        Task<IBusinessResult> Update(long id, ScheduleDTO newSchedule);
        Task<IBusinessResult> DeleteById(long id);
        Task<IBusinessResult> GetAllPaged(int pageNumber, int pageSize);
        Task<IBusinessResult> SearchByScheduleNameAndTimeFrame(string scheduleName, DateTime? startTime, DateTime? endTime, int pageNumber, int pageSize);
    }
}
