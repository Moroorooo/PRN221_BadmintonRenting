using BadmintonRentingBusiness.Base;
using BadmintonRentingCommon;
using BadmintonRentingData;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;

namespace BadmintonRentingBusiness
{
    public class BadmintonFieldBusiness : IBadmintonFieldBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public BadmintonFieldBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task<IBusinessResult> Create(BadmintonFieldRequestDTO newBadmintonFieldRequestDTO)
        //{
        //    try
        //    {
        //        var newBadmintonField = new BadmintonField
        //        {
        //            BadmintonFieldName = newBadmintonFieldRequestDTO.BadmintonFieldName,
        //            Phone = newCustomerDTO.Phone,
        //            Email = newCustomerDTO.Email,
        //            IsStatus = newCustomerDTO.IsStatus
        //        };
        //        var result = await _unitOfWork.CustomerRepository.CreateAsync(newCustomer);
        //        if (result > 0)
        //        {
        //            return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
        //        }
        //        else
        //        {
        //            return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
        //    }
        //}

        public async Task<IBusinessResult> DeleteById(long id)
        {
            try
            {
                var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
                if (customer != null)
                {
                    customer.IsStatus = "Banned";
                    var result = await _unitOfWork.CustomerRepository.UpdateAsync(customer);
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

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var listUser = await _unitOfWork.CustomerRepository.GetAllAsync();

                if (listUser == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, listUser);
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
                var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
                if (customer != null)
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, customer);
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

        public async Task<IBusinessResult> Update(long id, CustomerRequestDTO newCustomerDTO)
        {
            try
            {
                var existingCustomer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);

                existingCustomer.CustomerName = newCustomerDTO.CustomerName;
                existingCustomer.Phone = newCustomerDTO.Phone;
                existingCustomer.Email = newCustomerDTO.Email;
                existingCustomer.IsStatus = newCustomerDTO.IsStatus;

                var result = await _unitOfWork.CustomerRepository.UpdateAsync(existingCustomer);
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
