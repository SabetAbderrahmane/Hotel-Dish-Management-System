using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDishManagementTests
{
    [TestClass]
    public class AdminLoginTests
    {
        [TestMethod]
        public void Login_WithValidCredentials_ShouldReturnTrue()
        {
            // Arrange
            var adminLogin = new AdminLogin();
            string username = "admin";
            string password = "12345";

            // Act
            bool result = adminLogin.Login(username, password);

            // Assert
            Assert.IsTrue(result, "Login should succeed with valid credentials.");
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ShouldReturnFalse()
        {
            // Arrange
            var adminLogin = new AdminLogin();
            string username = "invalid";
            string password = "wrongpassword";

            // Act
            bool result = adminLogin.Login(username, password);

            // Assert
            Assert.IsFalse(result, "Login should fail with invalid credentials.");
        }
    }

    // Mocked AdminLogin class for testing purposes
    public class AdminLogin
    {
        private const string ValidUsername = "admin";
        private const string ValidPassword = "12345";

        public bool Login(string username, string password)
        {
            return username == ValidUsername && password == ValidPassword;
        }
    }
}
