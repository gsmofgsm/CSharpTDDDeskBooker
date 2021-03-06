using DeskBooker.Web.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeskBooker.Web.Tests.Pages
{
    public class BookDeskConfirmationModelTests
    {
        [Fact]
        public void ShouldStoreParameterValuesInProperties()
        {
            // Arrange
            const int deskBookingId = 7;
            const string firstName = "Thomas";
            var date = new DateTime(2020, 1, 28);

            var bookDeskConfirmationModel = new BookDeskConfirmationModel();

            // Act
            bookDeskConfirmationModel.OnGet(deskBookingId, firstName, date);

            // Assert
            Assert.Equal(deskBookingId, bookDeskConfirmationModel.DeskBookingId);
            Assert.Equal(firstName, bookDeskConfirmationModel.FirstName);
            Assert.Equal(date, bookDeskConfirmationModel.Date);
        }
    }
}
