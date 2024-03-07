using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SIMS.Tests
{
    [TestFixture]
    public class StudentTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            // Initialize the Chrome Driver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            // Navigate to the SIMS login page
            driver.Navigate().GoToUrl("https://sims.fpl.com");
        }

        [Test]
        public void AddNewStudent()
        {
            // Log into SIMS
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("adminPassword");
            driver.FindElement(By.Id("login-button")).Click();

            // Navigate to Add Student page
            driver.FindElement(By.LinkText("Students")).Click();
            driver.FindElement(By.LinkText("Add New Student")).Click();

            // Fill out the student details form
            driver.FindElement(By.Id("firstName")).SendKeys("Alice");
            driver.FindElement(By.Id("lastName")).SendKeys("Johnson");
            driver.FindElement(By.Id("dateOfBirth")).SendKeys("01/01/2000");
            // ... Assume we fill out the rest of the fields ...

            // Click the 'Save' button
            driver.FindElement(By.Id("saveStudentButton")).Click();

            // Verification that the student has been added
            // Look for success message or navigate to student list and verify the new student appears
            Assert.IsTrue(driver.FindElement(By.ClassName("success-message")).Displayed, "Student was not added successfully.");
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser after each test
            driver.Quit();
        }
    }
}
