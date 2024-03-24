using Kindergarden_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_NUnit_Tests.Tests
{

    [TestFixture]
    public class KidModelTest
    {
        [Test]
        public void FirstNameIsRequired()
        {
            // Arrange
            var kid = new Kid
            {
                LastName = "Doe",
                Age = 3,
                ParentId = 1,
                GroupId = 1
            };

            // Act
            var validationResults = ValidateModel(kid);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1));
            Assert.That(validationResults[0].MemberNames, Contains.Item("FirstName"));
            Assert.That(validationResults[0].ErrorMessage, Does.Contain("required"));
        }

        [Test]
        public void LastNameIsRequired()
        {
            // Arrange
            var kid = new Kid
            {
                FirstName = "John",
                Age = 3,
                ParentId = 1,
                GroupId = 1
            };

            // Act
            var validationResults = ValidateModel(kid);

            // Assert
            
            Assert.That(validationResults.Count, Is.EqualTo(1));
            Assert.That(validationResults[0].MemberNames, Contains.Item("LastName"));
            Assert.That(validationResults[0].ErrorMessage, Does.Contain("required"));
        }

        [Test]
        public void AgeIsNotRequired()
        {
            // Arrange
            var kid = new Kid
            {
                FirstName = "John",
                LastName = "Doe",
                ParentId = 1,
                GroupId = 1
            };

            // Act
            var validationResults = ValidateModel(kid);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(0));
        }

        // Helper method to validate model using DataAnnotations
        private static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, context, validationResults, true);
            return validationResults;
        }
    }
}

