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
        Task<IBusinessResult> GetById(string id);
        Task<IBusinessResult> Create(BookingBadmintonFieldSchedule entity);
        Task<IBusinessResult> Update(BookingBadmintonFieldSchedule entity);
        Task<IBusinessResult> DeleteById(long id);
        Task<IBusinessResult> GetAllBadmintonField();
        Task<IBusinessResult> GetAllBooking();
        Task<IBusinessResult> GetAllSchedule();
        Task<IBusinessResult> ConvertToDTO(BookingBadmintonFieldSchedule entity);
        Task<IBusinessResult> GetAllForIndex();
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

        public async Task<IBusinessResult> GetById(string id)
        {
            try
            {
                var schedule = await _unitOfWork.BookingBadmintonFieldScheduleRepository.GetByNameAsync(id);
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

        public async Task<IBusinessResult> GetAllBadmintonField()
        {
            try
            {
                var field = await _unitOfWork.BadmintonFieldReposiory.GetAllAsync();
                if (field != null)
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, field);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAllBooking()
        {
            try
            {
                var field = await _unitOfWork.BookingRepository.GetAllAsync();
                if (field != null)
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, field);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAllSchedule()
        {
            try
            {
                var field = await _unitOfWork.ScheduleRepository.GetAllAsync();
                if (field != null)
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, field);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }



        public async Task<IBusinessResult> ConvertToDTO(BookingBadmintonFieldSchedule entity)
        {
            try
            {
                var BadmintonFieldId = entity.BadmintonField;
                BadmintonField BadmintonField = await _unitOfWork.BadmintonFieldReposiory.GetByIdAsync(BadmintonFieldId);
                Schedule Schedule = await _unitOfWork.ScheduleRepository.GetByIdAsync(entity.ScheduleId);
                var dto = new FieldScheduleListViewDTO()
                {
                    OrderBadmintonFieldScheduleId = entity.OrderBadmintonFieldScheduleId,
                    BookingId = entity.BookingId,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    BadmintonFieldName = BadmintonField.BadmintonFieldName,
                    ScheduleName = Schedule.ScheduleName
                };

                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, dto);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAllForIndex()
        {
            try
            {
                var list = await _unitOfWork.BookingBadmintonFieldScheduleRepository.GetAllAsync();
                var listdto = new List<FieldScheduleListViewDTO>();
                foreach (var item in list)
                {
                    var dto = await ConvertToDTO(item);
                    listdto.Add((FieldScheduleListViewDTO)dto.Data);
                }

                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, listdto);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
