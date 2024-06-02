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
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Create(CustomerRequestDTO newCustomer);
        Task<IBusinessResult> Update(int id, CustomerRequestDTO newCustomer);
        Task<IBusinessResult> DeleteById(int id);
    }
}
