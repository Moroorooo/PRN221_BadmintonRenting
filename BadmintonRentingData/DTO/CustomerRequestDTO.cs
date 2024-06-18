using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingData.DTO
{
    public class CustomerRequestDTO
    {
        public string CustomerName { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
        public string IsStatus { get; set; } = null!;
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }
    }
}
