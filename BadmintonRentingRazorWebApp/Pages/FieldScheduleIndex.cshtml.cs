using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;
using BadmintonRentingData;
using BadmintonRentingData.DTO;

namespace BadmintonRentingRazorWebApp.Pages
{
    public class FieldScheduleIndexModel : PageModel
    {
        private readonly UnitOfWork _repository;

        public FieldScheduleIndexModel(UnitOfWork repository)
        {
            _repository = repository;
        }

        public IList<FieldScheduleListViewDTO> BookingBadmintonFieldSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_repository != null)
            {
                var result = await _repository.BookingBadmintonFieldScheduleRepository.GetAllAsync();
                var dto = new FieldScheduleListViewDTO();
                foreach (var data in result) 
                {
                    dto.TransformData(data);
                };
            }
        }
    }
}
