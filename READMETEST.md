# Test Cases for Hotel Dish Management System

This file documents the test cases implemented for the **Hotel Dish Management System** project. Each test ensures the functionality and reliability of various modules in the system.

## 📋 Table of Contents
1. [Purpose](#purpose)
2. [Test Environment](#test-environment)
3. [Test Cases](#test-cases)
   - [Add Button Tests](#add-button-tests)
   - [Login Tests](#login-tests)

---

## 📌 Purpose
The purpose of these tests is to ensure that the core functionality of the application works as expected and adheres to the business logic.

---

## 🛠️ Test Environment
- **Test Framework**: MSTest
- **Programming Language**: C#
- **IDE**: Visual Studio 2022
- **Target Framework**: .NET 5.0 or later

---

## ✅ Test Cases

### Add Button Tests
#### Test Name: `AddDish_ShouldAddDishToList()`
- **Description**: Verifies that the `Add` button correctly adds a new dish to the dish list.
- **Steps**:
  1. Create a new dish object.
  2. Simulate clicking the `Add` button.
  3. Assert that the dish is added to the list.
- **Expected Result**: The dish count increases, and the dish name is in the list.

---

### Login Tests
#### Test Name: `Login_ShouldSucceedWithValidCredentials()`
- **Description**: Validates that a user can log in with correct credentials.
- **Steps**:
  1. Provide username: `admin` and password: `12345`.
  2. Call the login method.
  3. Assert that the login succeeds.
- **Expected Result**: Login returns `true`.

#### Test Name: `Login_ShouldFailWithInvalidCredentials()`
- **Description**: Ensures that login fails with invalid credentials.
- **Steps**:
  1. Provide an invalid username and password.
  2. Call the login method.
  3. Assert that the login fails.
- **Expected Result**: Login returns `false`.

---

## 📖 Additional Notes
- Test cases should be updated as new features or bug fixes are added.
- Refer to the `HotelDishManagementTests` project for implementation details.
