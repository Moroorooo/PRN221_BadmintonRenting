using BadmintonRentingBusiness.Base;
using BadmintonRentingCommon;
using BadmintonRentingData.Model;
using BadmintonRentingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadmintonRentingData.DTO;
using System.Diagnostics;
using System.Numerics;
using System.Xml.Linq;

namespace BadmintonRentingBusiness
{
    public class ScheduleBusiness : IScheduleBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public ScheduleBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IBusinessResult> GetAllPaged(int pageNumber, int pageSize)
        {
            try
            {
                var result = await _unitOfWork.ScheduleRepository.GetAllPaged(pageNumber, pageSize);
                return new BusinessResult(Const.SUCCESS_READ_CODE, "Get all schedules successful", result);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, $"An error occurred: {ex.Message}");
            }
        }
        public async Task<IBusinessResult> SearchByScheduleNameAndTimeFrame(string scheduleName, DateTime? startTime, DateTime? endTime, int pageNumber, int pageSize)
        {
            try
            {
                var scheduleResult = await _unitOfWork.ScheduleRepository.SearchByScheduleNameAndTimeFrame(scheduleName, startTime, endTime, pageNumber, pageSize);

                return new BusinessResult(Const.SUCCESS_READ_CODE, "Search successful", scheduleResult);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, $"An error occurred: {ex.Message}");
            }
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var listSchedule = await _unitOfWork.ScheduleRepository.GetAllAsync();

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
                var schedule = await _unitOfWork.ScheduleRepository.GetByIdAsync(id);
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

        public async Task<IBusinessResult> Create(ScheduleDTO scheduleDTO)
        {   

            try
            {
                double totalHours = (double)(scheduleDTO.EndTimeFrame - scheduleDTO.StartTimeFrame).TotalHours;
                var newSchedule = new Schedule()
                {
                    ScheduleName = scheduleDTO.ScheduleName,
                    StartTimeFrame = scheduleDTO.StartTimeFrame,
                    EndTimeFrame = scheduleDTO.EndTimeFrame,
                    Price = scheduleDTO.Price,
                    TotalHours = totalHours
                };
                var result = await _unitOfWork.ScheduleRepository.CreateAsync(newSchedule);
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

        public async Task<IBusinessResult> Update(long id, ScheduleDTO newScheduleDTO)
        {
            try
            {
                
                //var newSchedule = new Schedule()
                //{
                //    ScheduleName = scheduleDTO.ScheduleName,
                //    StartTimeFrame = scheduleDTO.StartTimeFrame,
                //    EndTimeFrame = scheduleDTO.EndTimeFrame,
                //    Price = scheduleDTO.Price,
                //    TotalHours = totalHours
                //};
                
                var existingSchedule = await _unitOfWork.ScheduleRepository.GetByIdAsync(id);
                existingSchedule.ScheduleName=newScheduleDTO.ScheduleName;
                existingSchedule.StartTimeFrame = newScheduleDTO.StartTimeFrame;
                existingSchedule.EndTimeFrame= newScheduleDTO.EndTimeFrame;
                existingSchedule.Price = newScheduleDTO.Price;
                existingSchedule.TotalHours = newScheduleDTO.TotalHours;
                var result = await _unitOfWork.ScheduleRepository.UpdateAsync(existingSchedule);
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
                var schedule = await _unitOfWork.ScheduleRepository.GetByIdAsync(id);
                if (schedule != null)
                {   
                    var result = await _unitOfWork.ScheduleRepository.RemoveAsync(schedule);
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
    }
}
