using BadmintonRentingData.Base;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingData.Repository
{
    public class ScheduleRepository : GenericRepository<Schedule>
    {
        public ScheduleRepository() { }
        public ScheduleRepository(Net1702_PRN221_BadmintonRentingContext context) => _context = context;
        public async Task<PagedResultSchedule<Schedule>> SearchByScheduleNameAndTimeFrame(string scheduleName, DateTime? startTime, DateTime? endTime, int pageNumber, int pageSize)
        {
            var query = _context.Schedules.AsQueryable();

            if (!string.IsNullOrEmpty(scheduleName))
            {
                query = query.Where(s => s.ScheduleName.Contains(scheduleName));
            }

            if (startTime.HasValue)
            {
                query = query.Where(s => s.StartTimeFrame >= startTime.Value);
            }

            if (endTime.HasValue)
            {
                query = query.Where(s => s.EndTimeFrame <= endTime.Value);
            }

            return await GetPagedResultAsync(query, pageNumber, pageSize);
        }

        public async Task<PagedResultSchedule<Schedule>> GetAllPaged(int pageNumber, int pageSize)
        {
            var query = _context.Schedules.AsQueryable();
            return await GetPagedResultAsync(query, pageNumber, pageSize);
        }

        private async Task<PagedResultSchedule<Schedule>> GetPagedResultAsync(IQueryable<Schedule> query, int pageNumber, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return new PagedResultSchedule<Schedule>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
