using Kindergarden_Data;
using Kindergarden_Services;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Linq;

namespace Kindergarden_NUnit_Tests.Tests
{
    [TestFixture]
    public class KidServiceTests
    {
        private KindergardenDbContext _dbContext;
        private KidService _kidService;

        [SetUp]
        public void SetUp()
        {
            // Initialize your database context.
            _dbContext = new KindergardenDbContext();
            _kidService = new KidService(_dbContext);
        }

        [Test]
        public void CreateKid_ValidData_AddsKidToDatabase()
        {
            // Arrange
            var parentPhoneNumber = "1234567890"; // Replace with a valid phone number.
            var kidData = new
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 4,
                ParentFirstName = "Alice",
                ParentLastName = "Smith",
                PhoneNumber = parentPhoneNumber,
                Address = "123 Main St"
            };

            // Act
            _kidService.CreateKid(
                kidData.FirstName,
                kidData.LastName,
                kidData.Age,
                kidData.ParentFirstName,
                kidData.ParentLastName,
                kidData.PhoneNumber,
                kidData.Address);

            // Assert
            var addedKid = _dbContext.Kids.FirstOrDefault(k => k.FirstName == kidData.FirstName);
            ClassicAssert.NotNull(addedKid);
            ClassicAssert.AreEqual(kidData.Age, addedKid.Age);
        }


        [Test]
        public void Delete_NonExistingKid_ReturnsFalse()
        {
            // Arrange
            var nonExistingKidName = "NonExistent"; // Replace with a non-existing kid's first name.

            // Act
            var result = _kidService.Delete(nonExistingKidName);

            // Assert
            ClassicAssert.False(result);
        }

        [Test]
        public void FetchKidAndParent_ExistingKid_ReturnsKid()
        {
            // Arrange
            var existingKidName = "John"; // Replace with an existing kid's first name.

            // Act
            var result = _kidService.FetchKidAndParent(existingKidName);

            // Assert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(existingKidName, result.FirstName);
        }

        [Test]
        public void UpdateName_ExistingKid_UpdatesName()
        {
            // Arrange
            var existingKidId = 1; // Replace with an existing kid's ID.
            var newName = "Alice Smith"; // Replace with the new name.

            // Act
            var result = _kidService.UpdateName(existingKidId, newName);

            // Assert
            var updatedKid = _dbContext.Kids.FirstOrDefault(k => k.KidId == existingKidId);
            ClassicAssert.Null(updatedKid);
        }
        [Test]
        public void UpdateAge_ExistingKid_UpdatesAgeAndAssignsToCorrectGroup()
        {
            // Arrange
            var existingKidId = 1; // Replace with an existing kid's ID.
            var newAge = 4; // Replace with the new age.

            // Act
            var result = _kidService.UpdateAge(existingKidId, newAge);

            // Assert
            ClassicAssert.False(result);
            var updatedKid = _dbContext.Kids.FirstOrDefault(k => k.KidId == existingKidId);
            ClassicAssert.Null(updatedKid);
            // Verify that the kid is assigned to the correct group based on age.
        }

        [Test]
        public void UpdateAge_NonExistingKid_ReturnsFalse()
        {
            // Arrange
            var nonExistingKidId = 999; // Replace with a non-existing kid's ID.

            // Act
            var result = _kidService.UpdateAge(nonExistingKidId, 5);

            // Assert
            ClassicAssert.False(result);
        }
    }
}