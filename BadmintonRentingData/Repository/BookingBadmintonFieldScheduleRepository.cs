﻿using BadmintonRentingData.Base;
using BadmintonRentingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingData.Repository
{
    public class BookingBadmintonFieldScheduleRepository : GenericRepository<BookingBadmintonFieldSchedule>
    {
        public BookingBadmintonFieldScheduleRepository()
        {
        }

        public BookingBadmintonFieldScheduleRepository(Net1702_PRN221_BadmintonRentingContext context) => _context = context;
    }
}
