using DeskBooker.Core.Domain;
using System;

namespace DeskBooker.Core.Processor
{
    public class DeskingBookingRequestProcessor
    {
        public DeskingBookingRequestProcessor()
        {
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            return new DeskBookingResult 
            { 
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date,
            };
        }
    }
}