using NUnit.Framework;
using MonitoringService.Interfaces.REST.Resources.Room;

namespace MonitoringService.Tests.Interfaces.REST.Resources.Room
{
    [TestFixture]
    public class UpdateRoomStateResourceTests
    {
        [Test]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            int expectedId = 1;
            string expectedRoomState = "Available";

            // Act
            var resource = new UpdateRoomStateResource(expectedId, expectedRoomState);

            // Assert
            Assert.AreEqual(expectedId, resource.Id);
            Assert.AreEqual(expectedRoomState, resource.RoomState);
        }
    }

}
