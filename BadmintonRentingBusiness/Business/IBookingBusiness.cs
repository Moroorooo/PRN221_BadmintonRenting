using BadmintonRentingBusiness.Base;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingBusiness.Business
{
    public interface IBookingBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(long id);
        Task<IBusinessResult> Create(BookingDTO newBooking);
        Task<IBusinessResult> Save(Booking booking);
        Task<IBusinessResult> Update(long id, BookingDTO newBooking);
        Task<IBusinessResult> DeleteById(long id);
    }
}
