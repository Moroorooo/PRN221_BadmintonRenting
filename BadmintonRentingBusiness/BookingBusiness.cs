using BadmintonRentingBusiness.Base;
using BadmintonRentingCommon;
using BadmintonRentingData;
using BadmintonRentingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingBusiness
{
    public interface IBookingBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(long id);
        Task<IBusinessResult> GetById(string id);
        Task<IBusinessResult> Create(Booking entity);
        Task<IBusinessResult> Update(Booking entity);
        Task<IBusinessResult> DeleteById(long id);
        Task<IBusinessResult> GetAllCustomer();
    }
    public class BookingBusiness : IBookingBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public BookingBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IBusinessResult> Create(Booking entity)
        {
            try
            {
                var result = await _unitOfWork.BookingRepository.CreateAsync(entity);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> DeleteById(long id)
        {
            try 
            {
                var booking = await _unitOfWork.BookingRepository.GetByIdAsync(id);
                if (booking  != null)
                {
                    var result = await _unitOfWork.BookingRepository.RemoveAsync(booking);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var list = await _unitOfWork.BookingRepository.GetAllAsync();
                if (list == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, list);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAllCustomer()
        {
            try
            {
                var list = await _unitOfWork.CustomerRepository.GetAllAsync();
                if (list == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, list);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(long id)
        {
            try
            {
                var booking = await _unitOfWork.BookingRepository.GetByIdAsync(id);
                if (booking == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, booking);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(string id)
        {
            try
            {
                var booking = await _unitOfWork.BookingRepository.GetByNameAsync(id);
                if (booking == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, booking);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Update(Booking entity)
        {
            try
            {
                var result = await _unitOfWork.BookingRepository.UpdateAsync(entity);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
