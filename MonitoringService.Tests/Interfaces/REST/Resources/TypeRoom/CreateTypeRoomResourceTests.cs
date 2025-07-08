using MonitoringService.Interfaces.REST.Resources.TypeRoom;
using NUnit.Framework;

namespace MonitoringService.Tests.Interfaces.REST.Resources.TypeRoom
{
    [TestFixture]
    public class CreateTypeRoomResourceTests
    {
        [Test]
        public void Constructor_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            int expectedHotelId = 5;
            string expectedDescription = "Suite";
            decimal expectedPrice = 199.99m;

            // Act
            var resource = new CreateTypeRoomResource(expectedHotelId, expectedDescription, expectedPrice);

            // Assert
            Assert.AreEqual(expectedHotelId, resource.HotelId);
            Assert.AreEqual(expectedDescription, resource.Description);
            Assert.AreEqual(expectedPrice, resource.Price);
        }
    }
}