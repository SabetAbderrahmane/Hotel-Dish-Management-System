using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HotelDishManagementTests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void GenerateReport_ShouldReturnCorrectSummary()
        {
            // Arrange: Set up the ReportGenerator and the list of orders
            var reportGenerator = new ReportGenerator();

            var orders = new List<Order>
            {
                new Order { DishName = "Pizza", Quantity = 2, Price = 10 }, // 2 x $10 = $20
                new Order { DishName = "Pasta", Quantity = 1, Price = 8 }   // 1 x $8 = $8
            };

            // Act: Generate the summary using the GenerateSummary method
            var summary = reportGenerator.GenerateSummary(orders);

            // Assert: Verify that the total price and total orders are correct
            Assert.AreEqual(28, summary.TotalPrice, "The total price should be $28.");
            Assert.AreEqual(2, summary.TotalOrders, "The total number of orders should be 2.");
        }
    }

    // Mock classes or stubs for ReportGenerator and Order for the sake of completeness:
    public class ReportGenerator
    {
        public Summary GenerateSummary(List<Order> orders)
        {
            int totalOrders = orders.Count;
            double totalPrice = 0;

            foreach (var order in orders)
            {
                totalPrice += order.Quantity * order.Price;
            }

            return new Summary
            {
                TotalOrders = totalOrders,
                TotalPrice = totalPrice
            };
        }
    }

    public class Order
    {
        public string DishName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class Summary
    {
        public int TotalOrders { get; set; }
        public double TotalPrice { get; set; }
    }
}
