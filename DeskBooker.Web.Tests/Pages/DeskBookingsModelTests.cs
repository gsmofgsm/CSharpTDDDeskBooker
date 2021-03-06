using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using DeskBooker.Web.Pages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeskBooker.Web.Tests.Pages
{
    public class DeskBookingsModelTests
    {
        [Fact]
        public void ShouldGetAllDeskBookings()
        {
            // Arrange
            var deskBookings = new[]
            {
                new DeskBooking(),
                new DeskBooking(),
                new DeskBooking()
            };

            var deskBookingRepositoryMock = new Mock<IDeskBookingRepository>();
            deskBookingRepositoryMock.Setup(x => x.GetAll())
                .Returns(deskBookings);

            var deskBookingsModel = new DeskBookingsModel(deskBookingRepositoryMock.Object);

            // Act
            deskBookingsModel.OnGet();

            // Assert
            Assert.Equal(deskBookings, deskBookingsModel.DeskBookings);
        }
    }
}
