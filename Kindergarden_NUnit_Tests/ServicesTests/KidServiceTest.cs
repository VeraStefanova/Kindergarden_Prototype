using Kindergarden_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Moq;
using Kindergarden_Data;
using Kindergarden_Services;
using NUnit.Framework.Legacy;

namespace Kindergarden_NUnit_Tests.ServicesTests
{
    [TestFixture]
    public class KidServiceTests
    {
        [Test]
        public void CreateKid_WhenCalled_AddsKidToDatabase()
        {
            // Arrange
            var mockDbContext = new Mock<KindergardenDbContext>();
            var service = new KidService(mockDbContext.Object);

            // Act
            service.CreateKid("John", "Doe", 5, "Jane", "Doe", "123456789", "123 Main St");

            // Assert
            mockDbContext.Verify(db => db.Kids.Add(It.IsAny<Kid>()), Times.Once);
            mockDbContext.Verify(db => db.SaveChanges(), Times.Once);
        }

        [Test]
        public void Delete_ExistingKid_RemovesKidFromDatabase()
        {
            // Arrange
            var mockDbContext = new Mock<KindergardenDbContext>();
            var service = new KidService(mockDbContext.Object);
            var existingKid = new Kid { FirstName = "John" };
            mockDbContext.Setup(db => db.Kids.FirstOrDefault(It.IsAny<Func<Kid, bool>>())).Returns(existingKid);

            // Act
            var result = service.Delete("John");

            // Assert
            ClassicAssert.IsTrue(result);
            mockDbContext.Verify(db => db.Kids.Remove(existingKid), Times.Once);
            mockDbContext.Verify(db => db.SaveChanges(), Times.Once);
        }

        [Test]
        public void Delete_NonExistingKid_ReturnsFalse()
        {
            // Arrange
            var mockDbContext = new Mock<KindergardenDbContext>();
            var service = new KidService(mockDbContext.Object);
            mockDbContext.Setup(db => db.Kids.FirstOrDefault(It.IsAny<Func<Kid, bool>>())).Returns((Kid)null);

            // Act
            var result = service.Delete("NonExistingKid");

            // Assert
            ClassicAssert.IsFalse(result);
            mockDbContext.Verify(db => db.SaveChanges(), Times.Never);
        }

        // Similar tests can be written for other methods like FetchKidAndParent and Update methods
    }
}
