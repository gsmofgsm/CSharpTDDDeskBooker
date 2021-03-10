using DeskBooker.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeskBooker.DataAccess.Repositories
{
    public class DeskRepositoryTests
    {
        [Fact]
        public void ShouldReturnTheAvailableDesks()
        {
            // Arrange
            var date = new DateTime(2020, 1, 25);

            var options = new DbContextOptionsBuilder<DeskBookerContext>()
                .UseInMemoryDatabase(databaseName: "ShouldReturnTheAvailableDesks")
                .Options;

            using (var context = new DeskBookerContext(options))
            {
                context.Desk.Add(new Core.Domain.Desk { Id = 1 });
                context.Desk.Add(new Core.Domain.Desk { Id = 2 });
                context.Desk.Add(new Core.Domain.Desk { Id = 3 });

                context.DeskBooking.Add(new DeskBooking { DeskId = 1, Date = date });
                context.DeskBooking.Add(new DeskBooking { DeskId = 2, Date = date.AddDays(1) });

                context.SaveChanges();
            }

            using (var context = new DeskBookerContext(options))
            {
                var repository = new DeskRepository(context);

                // Act
                var desks = repository.GetAvailableDesks(date);

                // Assert
                Assert.Equal(2, desks.Count());
                Assert.Contains(desks, d => d.Id == 2);
                Assert.Contains(desks, d => d.Id == 3);
                Assert.DoesNotContain(desks, d => d.Id == 1);
            }
        }
    }
}
