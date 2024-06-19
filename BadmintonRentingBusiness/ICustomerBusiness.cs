using BadmintonRentingBusiness.Base;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingBusiness
{
    public interface ICustomerBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(long id);
        Task<IBusinessResult> Create(CustomerRequestDTO newCustomer);
        Task<IBusinessResult> Update(long id, CustomerRequestDTO newCustomer);
        Task<IBusinessResult> DeleteById(long id);
        Task<IBusinessResult> SearchByNameByEmailByPhone(string name, string email, int? phone);

        Task<IBusinessResult> GetAllPaged(int pageNumber, int pageSize);
    }
}
