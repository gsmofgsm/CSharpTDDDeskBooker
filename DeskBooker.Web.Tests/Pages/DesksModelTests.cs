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
    public class DesksModelTests
    {
        [Fact]
        public void ShouldGetAllDesks()
        {
            // Arrange
            var desks = new[]
            {
                new Desk(),
                new Desk(),
                new Desk()
            };

            var deskRepositoryMock = new Mock<IDeskRepository>();
            deskRepositoryMock.Setup(x => x.GetAll())
                .Returns(desks);

            var desksModel = new DesksModel(deskRepositoryMock.Object);

            // Act
            desksModel.OnGet();

            // Assert
            Assert.Equal(desks, desksModel.Desks);
        }
    }
}
