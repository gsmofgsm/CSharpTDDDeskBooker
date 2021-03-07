using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using System;

namespace DeskBooker.Core.Processor
{
    public class DeskingBookingRequestProcessor
    {
        private readonly IDeskBookingRepository _deskBookingRepository;

        public DeskingBookingRequestProcessor(IDeskBookingRepository deskBookingRepository, IDeskRepository @object)
        {
            _deskBookingRepository = deskBookingRepository;
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _deskBookingRepository.Save(Create<DeskBooking>(request));

            return Create<DeskBookingResult>(request);
        }

        private static T Create<T>(DeskBookingRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date,
            };
        }
    }
}