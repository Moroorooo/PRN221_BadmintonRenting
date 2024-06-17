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
        public async Task<IBusinessResult> Create(BadmintonFieldRequestDTO newBadmintonFieldRequestDTO)
        {
            try
            {
                var newBadmintonField = new BadmintonField
                {
                    BadmintonFieldName = newBadmintonFieldRequestDTO.BadmintonFieldName,
                    Address = newBadmintonFieldRequestDTO.Address,
                    Description = newBadmintonFieldRequestDTO.Description,
                    StartTime = newBadmintonFieldRequestDTO.StartTime,
                    EndTime = newBadmintonFieldRequestDTO.EndTime,
                    IsActive = newBadmintonFieldRequestDTO.IsActive
                };
                var result = await _unitOfWork.BadmintonFieldReposiory.CreateAsync(newBadmintonField);
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

        public async Task<IBusinessResult> Create(BadmintonField entity)
        {
            try
            {
                var result = await _unitOfWork.BadmintonFieldReposiory.CreateAsync(entity);
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
                var badmintonField = await _unitOfWork.BadmintonFieldReposiory.GetByIdAsync(id);
                if (badmintonField != null)
                {
                    var result = await _unitOfWork.BadmintonFieldReposiory.DeleteAsync(badmintonField);
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
                var listField = await _unitOfWork.BadmintonFieldReposiory.GetAllAsync();

                if (listField == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, listField);
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
                var badmintonField = await _unitOfWork.BadmintonFieldReposiory.GetByIdAsync(id);
                if (badmintonField != null)
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, badmintonField);
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

        public async Task<IBusinessResult> GetById(long? id)
        {
            try
            {
                var badmintonField = await _unitOfWork.BadmintonFieldReposiory.GetByIdAsync(id);
                if (badmintonField != null)
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, badmintonField);
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

        public async Task<IBusinessResult> Update(long id, BadmintonFieldRequestDTO newbadmintonFieldRequestDTO)
        {
            try
            {
                var existingField = await _unitOfWork.BadmintonFieldReposiory.GetByIdAsync(id);

                existingField.BadmintonFieldName = newbadmintonFieldRequestDTO.BadmintonFieldName;
                existingField.Address = newbadmintonFieldRequestDTO.Address;
                existingField.Description = newbadmintonFieldRequestDTO.Description;
                existingField.StartTime = newbadmintonFieldRequestDTO.StartTime;
                existingField.EndTime = newbadmintonFieldRequestDTO.EndTime;
                existingField.IsActive = newbadmintonFieldRequestDTO.IsActive;

                var result = await _unitOfWork.BadmintonFieldReposiory.UpdateAsync(existingField);
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

        public async Task<IBusinessResult> Update(long id, BadmintonField badmintonField)
        {
            try
            {
                var existingField = await _unitOfWork.BadmintonFieldReposiory.GetByIdAsync(id);

                existingField.BadmintonFieldName = badmintonField.BadmintonFieldName;
                existingField.Address = badmintonField.Address;
                existingField.Description = badmintonField.Description;
                existingField.StartTime = badmintonField.StartTime;
                existingField.EndTime = badmintonField.EndTime;
                existingField.IsActive = badmintonField.IsActive;

                var result = await _unitOfWork.BadmintonFieldReposiory.UpdateAsync(existingField);
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
