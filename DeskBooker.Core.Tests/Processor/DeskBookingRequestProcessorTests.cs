﻿using System;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            // Arrange
            var request = new DeskBookingRequest
            {
                FirstName = "Thomas",
                LastName = "Huber",
                Email = "thomas@thomasclaudiushuber.com",
                Date = new DateTime(2020, 1, 28)
            };

            var processor = new DeskingBookingRequestProcessor();

            // Act
            DeskBookingResult result = processor.BookDesk(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }
    }
}
