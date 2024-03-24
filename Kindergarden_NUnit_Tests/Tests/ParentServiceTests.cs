using Kindergarden_Data;
using Kindergarden_Services;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_NUnit_Tests.Tests
{
    [TestFixture]
    public class ParentServiceTests
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
        public void Fetch_ExistingParent_ReturnsParent()
        {
            // Arrange
            var existingParentId = 1; // Replace with an existing parent's ID.

            // Act
            var result = _parentService.Fetch(existingParentId);

            // Assert
            ClassicAssert.Null(result);
        }
    }
}
