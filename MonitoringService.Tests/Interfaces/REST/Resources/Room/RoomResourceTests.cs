using NUnit.Framework;
using MonitoringService.Interfaces.REST.Resources.Room;

namespace MonitoringService.Tests.Interfaces.REST.Resources.Room
{
    [TestFixture]
    public class RoomResourceTests
    {
        [Test]
        public void Constructor_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            int expectedId = 10;
            int expectedTypeRoomId = 20;
            string expectedRoomState = "Occupied";

            // Act
            var resource = new RoomResource(expectedId, expectedTypeRoomId, expectedRoomState);

            // Assert
            Assert.AreEqual(expectedId, resource.Id);
            Assert.AreEqual(expectedTypeRoomId, resource.TypeRoomId);
            Assert.AreEqual(expectedRoomState, resource.RoomState);
        }
    }
}

