using Kindergarden_Data;
using Kindergarden_Models;
using Kindergarden_Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_NUnit_Tests.ServicesTests
{
    [TestFixture]
    public class GroupServiceTests
    {
        [Test]
        public void Fetch_ValidId_ReturnsGroup()
        {
            // Arrange
            int groupId = 1;
            var groupData = new List<Group>
        {
            new Group { GroupId = 1, GroupName = "Group 1", Kids = new List<Kid>() }
            // Add more test data as needed
        }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Group>>();
            mockDbSet.As<IQueryable<Group>>().Setup(m => m.Provider).Returns(groupData.Provider);
            mockDbSet.As<IQueryable<Group>>().Setup(m => m.Expression).Returns(groupData.Expression);
            mockDbSet.As<IQueryable<Group>>().Setup(m => m.ElementType).Returns(groupData.ElementType);
            mockDbSet.As<IQueryable<Group>>().Setup(m => m.GetEnumerator()).Returns(groupData.GetEnumerator());

            var mockDbContext = new Mock<KindergardenDbContext>();
            mockDbContext.Setup(db => db.Groups).Returns(mockDbSet.Object);

            var groupService = new GroupService(mockDbContext.Object);

            // Act
            var result = groupService.Fetch(groupId);

            // Assert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(groupId, result.GroupId);
        }

        [Test]
        public void Fetch_InvalidId_ReturnsNull()
        {
            // Arrange
            int groupId = 999; // Assuming there's no group with this ID
            var groupData = new List<Group>().AsQueryable(); // Empty list

            var mockDbSet = new Mock<DbSet<Group>>();
            mockDbSet.As<IQueryable<Group>>().Setup(m => m.Provider).Returns(groupData.Provider);
            mockDbSet.As<IQueryable<Group>>().Setup(m => m.Expression).Returns(groupData.Expression);
            mockDbSet.As<IQueryable<Group>>().Setup(m => m.ElementType).Returns(groupData.ElementType);
            mockDbSet.As<IQueryable<Group>>().Setup(m => m.GetEnumerator()).Returns(groupData.GetEnumerator());

            var mockDbContext = new Mock<KindergardenDbContext>();
            mockDbContext.Setup(db => db.Groups).Returns(mockDbSet.Object);

            var groupService = new GroupService(mockDbContext.Object);

            // Act
            var result = groupService.Fetch(groupId);

            // Assert
            ClassicAssert.IsNull(result);
        }

        // Add more test cases as needed
    }
}
