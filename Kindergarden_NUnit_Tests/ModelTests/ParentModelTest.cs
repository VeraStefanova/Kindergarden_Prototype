using Kindergarden_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Compatibility;
using NUnit.Framework.Legacy;

namespace Kindergarden_NUnit_Tests.ModelTests
{
    [TestFixture]
    public class ParentModelTests
    {
        [Test]
        public void Parent_Should_Have_Collection_Of_Kids()
        {
            // Arrange
            var parent = new Parent();


            // Assert
            ClassicAssert.NotNull(parent.Kids);
            ClassicAssert.IsInstanceOf(typeof(ICollection<Kid>), parent.Kids);
        }


        [Test]
        public void Parent_Kids_Collection_Should_Be_Empty_By_Default()
        {
            // Arrange
            var parent = new Parent();


            // Assert
            ClassicAssert.IsEmpty(parent.Kids);
        }

        [Test]
        public void Adding_Kid_To_Parent_Should_Reflect_In_Kids_Collection()
        {
            // Arrange
            var parent = new Parent();
            var kid = new Kid();

            // Act
            parent.Kids.Add(kid);

            // Assert
            ClassicAssert.AreEqual(1, parent.Kids.Count);
            ClassicAssert.IsTrue(parent.Kids.Contains(kid));
        }

        [Test]
        public void Removing_Kid_From_Parent_Should_Reflect_In_Kids_Collection()
        {
            // Arrange
            var parent = new Parent();
            var kid = new Kid();
            parent.Kids.Add(kid);

            // Act
            parent.Kids.Remove(kid);

            // Assert
            ClassicAssert.IsEmpty(parent.Kids);
        }
        [Test]
        public void Parent_FirstName_Should_Not_Be_Null_Or_Empty()
        {
            // Arrange
            var parent = new Parent();
            parent.FirstName = "";


            // Assert
            ClassicAssert.IsFalse(!string.IsNullOrEmpty(parent.FirstName));
        }

        [Test]
        public void Parent_LastName_Should_Not_Be_Null_Or_Empty()
        {
            // Arrange
            var parent = new Parent();
            parent.LastName = "";


            // Assert
            ClassicAssert.IsFalse(!string.IsNullOrEmpty(parent.LastName));
        }

        [Test]
        public void Parent_PhoneNumber_Should_Not_Be_Null_Or_Empty()
        {
            // Arrange
            var parent = new Parent();
            parent.PhoneNumber = "";


            // Assert
            ClassicAssert.IsFalse(!string.IsNullOrEmpty(parent.PhoneNumber));
        }

        [Test]
        public void Parent_Address_Should_Not_Be_Null_Or_Empty()
        {
            // Arrange
            var parent = new Parent();
            parent.Address = "";


            // Assert
            ClassicAssert.IsFalse(!string.IsNullOrEmpty(parent.Address));
        }
    }
}
