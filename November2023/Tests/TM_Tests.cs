
using November2023.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using November2023.Utilities;
using System.ComponentModel;
using DescriptionAttribute = NUnit.Framework.DescriptionAttribute;

namespace November2023.Tests
{
    [Parallelizable]
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [SetUp]
        public void TimeSetUp()
        {
            //Open Chrome browser
            driver = new ChromeDriver(); //instance of a browser

            loginPageObj.LoginActions(driver);

            homePageObj.GotoTMPage(driver);
        }

        [Test, Order(1), Description("This test is creating a new time record")]
        public void CreateTime_Test()
        {
            tmPageObj.Create_TimeRecord(driver);
        }

        [Test, Order(2), Description ("This test is editing an existing time record")]
        public void EditTime_Test()
        {
            tmPageObj.Edit_TimeRecord(driver);
        }

        [Test, Order(3), Description ("This test is deleting an existing time record")]
        public void DeleteTime_Test()
        {
            tmPageObj.Delete_TimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
