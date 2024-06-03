using BadmintonRentingBusiness.Base;
using BadmintonRentingCommon;
using BadmintonRentingData;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingBusiness
{
    public interface IBookingBadmintonFieldScheduleBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(long id);
        Task<IBusinessResult> Create(BookingBadmintonFieldSchedule entity);
        Task<IBusinessResult> Update(BookingBadmintonFieldSchedule entity);
        Task<IBusinessResult> DeleteById(long id);
        //Task<IBusinessResult> ConvertToDTO(BookingBadmintonFieldSchedule entity);
    }

    public class BookingBadmintonFieldScheduleBusiness : IBookingBadmintonFieldScheduleBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public BookingBadmintonFieldScheduleBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var listSchedule = await _unitOfWork.BookingBadmintonFieldScheduleRepository.GetAllAsync();

                if (listSchedule == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, listSchedule);
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
                var schedule = await _unitOfWork.BookingBadmintonFieldScheduleRepository.GetByIdAsync(id);
                if (schedule != null)
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, schedule);
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

        public async Task<IBusinessResult> Create(BookingBadmintonFieldSchedule entity)
        {
            try
            {
                var result = await _unitOfWork.BookingBadmintonFieldScheduleRepository.CreateAsync(entity);
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

        public async Task<IBusinessResult> Update(BookingBadmintonFieldSchedule entity)
        {
            try
            {
                var result = await _unitOfWork.BookingBadmintonFieldScheduleRepository.UpdateAsync(entity);
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

        public async Task<IBusinessResult> DeleteById(long id)
        {
            try
            {
                var schedule = await _unitOfWork.BookingBadmintonFieldScheduleRepository.GetByIdAsync(id);
                if (schedule != null)
                {
                    var result = await _unitOfWork.BookingBadmintonFieldScheduleRepository.RemoveAsync(schedule);
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

        //public async Task<IBusinessResult> ConvertToDTO(BookingBadmintonFieldSchedule entity)
        //{
        //    try
        //    {
        //        var BadmintonField = await _unitOfWork.
        //        var dto = new FieldScheduleListViewDTO()
        //        {
        //            OrderBadmintonFieldScheduleId = entity.OrderBadmintonFieldScheduleId,
        //            BookingId = entity.BookingId,
        //            StartDate = entity.StartDate,
        //            EndDate = entity.EndDate,
        //            BadmintonFieldName
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
        //    }
        //}
    }
}
