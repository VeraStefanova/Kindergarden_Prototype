using Kindergarden_Data;
using Kindergarden_Services;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Kindergarden_NUnit_Tests.Tests
{
    [TestFixture]
    public class GroupServiceTests
    {
        private KindergardenDbContext _dbContext;
        private GroupService _groupService;

        [SetUp]
        public void SetUp()
        {
            // Initialize your database context.
            _dbContext = new KindergardenDbContext();
            _groupService = new GroupService(_dbContext);
        }

        [Test]
        public void Fetch_ValidId_ReturnsGroup()
        {
            // Arrange
            int groupId = 1; // Replace with a valid group ID from your database.

            // Act
            var result = _groupService.Fetch(groupId);

            // Assert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(groupId, result.GroupId);
        }

        [Test]
        public void Fetch_InvalidId_ReturnsNull()
        {
            // Arrange
            int invalidId = -1; // Replace with an invalid group ID.

            // Act
            var result = _groupService.Fetch(invalidId);

            // Assert
            ClassicAssert.Null(result);
        }
    }
}

