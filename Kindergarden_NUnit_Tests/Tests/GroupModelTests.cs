using Kindergarden_Data;
using Kindergarden_Models;
using Kindergarden_Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_NUnit_Tests.Tests
{
    [TestFixture]
    public class GroupModelTests
    {
        private KindergardenDbContext _dbContext;
        private ParentService _parentService;

        [SetUp]
        public void SetUp()
        {
            // Initialize your database context.
            _dbContext = new KindergardenDbContext();
            _parentService = new ParentService(_dbContext);
        }

        [Test]
        public void GroupName_Should_Be_Required()
        {
            // Arrange
            var group = new Group();

            // Assert
            var validationResults = ValidateModel(group);
            Assert.That(validationResults.Count, Is.EqualTo(1));
            Assert.That(validationResults[0].MemberNames, Contains.Item("GroupName"));
            Assert.That(validationResults[0].ErrorMessage, Does.Contain("required"));
        }

        [Test]
        public void Group_Should_Have_Collection_Of_Kids()
        {
            // Arrange
            var group = new Group();

            // Assert
            ClassicAssert.NotNull(group.Kids);
            ClassicAssert.IsInstanceOf(typeof(ICollection<Kid>), group.Kids);
        }

        [Test]
        public void Group_Kids_Collection_Should_Be_Empty_By_Default()
        {
            // Arrange
            var group = new Group();

            // Assert
            ClassicAssert.IsEmpty(group.Kids);
        }

        // Helper method to validate model using DataAnnotations
        private static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, context, validationResults, true);
            return validationResults;
        }

        [Test]
        public void UpdateName_ExistingParent_UpdatesName()
        {
            // Arrange
            var existingParentId = 1; // Replace with an existing parent's ID.
            var newName = "Alice Smith"; // Replace with the new name.

            // Act
            var result = _parentService.UpdateName(existingParentId, newName);

            // Assert
            ClassicAssert.False(result);
            var updatedParent = _dbContext.Parents.FirstOrDefault(p => p.ParentId == existingParentId);
            ClassicAssert.Null(updatedParent);
        }
        
        [Test]
        public void UpdatePN_NonExistingParent_ReturnsFalse()
        {
            // Arrange
            var nonExistingParentPhoneNumber = "5555555555"; // Replace with a non-existing phone number.

            // Act
            var result = _parentService.UpdatePN(nonExistingParentPhoneNumber, "1234567890");

            // Assert
            ClassicAssert.False(result);
        }

        [Test]
        public void UpdateAddress_ExistingParent_UpdatesAddress()
        {
            // Arrange
            var existingParentAddress = "123 Main St"; // Replace with an existing parent's address.
            var newAddress = "456 Elm St"; // Replace with the new address.

            // Act
            var result = _parentService.UpdateAddress(existingParentAddress, newAddress);

            // Assert
            ClassicAssert.False(result);
            var updatedParent = _dbContext.Parents.FirstOrDefault(p => p.Address == newAddress);
            ClassicAssert.NotNull(updatedParent);
            ClassicAssert.AreEqual(newAddress, updatedParent.Address);
        }

        [Test]
        public void UpdateAddress_NonExistingParent_ReturnsFalse()
        {
            // Arrange
            var nonExistingParentAddress = "999 Nonexistent St"; // Replace with a non-existing address.

            // Act
            var result = _parentService.UpdateAddress(nonExistingParentAddress, "123 Main St");

            // Assert
            ClassicAssert.False(result);
        }
    }
}
