using Kindergarden_Models;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_NUnit_Tests.ModelTests
{
    [TestFixture]
    public class GroupModelTests
    {
        [Test]
        public void GroupName_Should_Be_Required()
        {
            // Arrange
            var group = new Group();

            // Act

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

            // Act

            // Assert
            ClassicAssert.NotNull(group.Kids);
            ClassicAssert.IsInstanceOf(typeof(ICollection<Kid>), group.Kids);
        }

        [Test]
        public void Group_Kids_Collection_Should_Be_Empty_By_Default()
        {
            // Arrange
            var group = new Group();

            // Act

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
    }
}
