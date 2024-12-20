using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDishManagement; // Replace with your project's namespace
using System.Collections.Generic;

namespace HotelDishManagementTests
{
    [TestClass]
    public class AddButtonTests
    {
        [TestMethod]
        public void AddDish_ShouldAddDishToList()
        {
            // Arrange: Set up the necessary objects and inputs
            List<string> dishes = new List<string>();
            string newDish = "Spaghetti";

            // Act: Perform the action being tested
            dishes.Add(newDish);

            // Assert: Verify the expected outcome
            Assert.AreEqual(1, dishes.Count);
            Assert.AreEqual("Spaghetti", dishes[0]);
        }
    }
}
