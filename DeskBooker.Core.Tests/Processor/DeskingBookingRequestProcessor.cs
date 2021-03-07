using System;

namespace DeskBooker.Core.Processor
{
    internal class DeskingBookingRequestProcessor
    {
        public DeskingBookingRequestProcessor()
        {
        }

        internal DeskBookingResult BookDesk(DeskBookingRequest request)
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