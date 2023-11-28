using November2023.Pages;
using November2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace November2023.Tests
{
    [Parallelizable]
    [TestFixture]
    public class Employee_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();

        [SetUp]
        public void EmployeeSetUp()
        {
            //Open Chrome browser
            driver = new ChromeDriver(); //instance of a browser

            loginPageObj.LoginActions(driver);

            homePageObj.GotoEmployeePage(driver);
        }

        [Test, Order(1), Description("This test is creating a new employee record")]
        public void CreateEmployee_Test()
        {
            employeePageObj.Create_EmployeeRecord(driver);

        }

        [Test, Order(2), Description("This test is editing an existing employee record")]
        public void EditEmployee_Test()
        {
            employeePageObj.Edit_EmployeeRecord(driver);
        }

        [Test, Order(3), Description("This test is deleting an existing employee record")]
        public void DeleteEmployee_Test()
        {
            employeePageObj.Delete_EmployeeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
