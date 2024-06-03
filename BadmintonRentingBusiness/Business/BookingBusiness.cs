using BadmintonRentingBusiness.Base;
using BadmintonRentingBusiness.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadmintonRentingCommon;
using BadmintonRentingData;
using BadmintonRentingData.Repository;
using BadmintonRentingData.Model;
using BadmintonRentingData.DTO;


namespace BadmintonRentingBusiness
{
    public class BookingBusiness : IBookingBusiness
    {
        //private readonly BookingDAO _DAO;
        private readonly UnitOfWork _unitOfWork;

        public BookingBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IBusinessResult> Create(BookingDTO newBookingDTO)
        {
            try
            {
                var newBooking = new Booking
                {
                    BookingId = newBookingDTO.BookingId,
                    CreatedAt = newBookingDTO.CreatAt,
                    TotalPrice = newBookingDTO.TotalPrice,
                    BookingType = newBookingDTO.BookingType,
                    CheckInStatus = newBookingDTO.CheckInStatus,
                    IsStatus = newBookingDTO.IsStatus,
                    CustomerId = newBookingDTO.CustomerId,
                    PaymentType = newBookingDTO.PaymentType,
                };
                var result = await _unitOfWork.BookingRepository.CreateAsync(newBooking);
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

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                //var currencies = _DAO.GetAll();
                //var currencies = await _bookingRepository.GetAllAsync();
                var listBooking = await _unitOfWork.BookingRepository.GetAllAsync();


                if (listBooking == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, listBooking);
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
                #region Business rule
                #endregion

                //var booking = await _bookingRepository.GetByIdAsync(code);
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

        public async Task<IBusinessResult> Save(Booking booking)
        {
            try
            {
                //int result = await _bookingRepository.CreateAsync(booking);
                int result = await _unitOfWork.BookingRepository.CreateAsync(booking);
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

        public async Task<IBusinessResult> Update(long id, BookingDTO newBookingDTO)
        {
            try
            {
                //int result = await _bookingRepository.UpdateAsync(booking);
                var existingBooking = await _unitOfWork.BookingRepository.GetByIdAsync(id);

                existingBooking.BookingId = newBookingDTO.BookingId;
                existingBooking.CreatedAt = newBookingDTO.CreatAt;
                existingBooking.TotalPrice = newBookingDTO.TotalPrice;
                existingBooking.BookingType = newBookingDTO.BookingType;
                existingBooking.CheckInStatus = newBookingDTO.CheckInStatus;
                existingBooking.IsStatus = newBookingDTO.IsStatus;
                existingBooking.CustomerId = newBookingDTO.CustomerId;
                existingBooking.PaymentType = newBookingDTO.PaymentType;

                var result = await _unitOfWork.BookingRepository.UpdateAsync(existingBooking);

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
                //var booking = await _bookingRepository.GetByIdAsync(code);
                var booking = await _unitOfWork.BookingRepository.GetByIdAsync(id);
                if (booking != null)
                {
                    //var result = await _bookingRepository.RemoveAsync(booking);
                    var result = await _unitOfWork.BookingRepository.UpdateAsync(booking);
                    if (result > 0)
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
