using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace November2023.Pages
{
    public class EmployeePage
    {
        public void Create_EmployeeRecord(IWebDriver driver)
        {
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createButton.Click();

            IWebElement name = driver.FindElement(By.Id("Name"));
            name.SendKeys("Sasikala");

            IWebElement userName = driver.FindElement(By.Id("Username"));
            userName.SendKeys("Sasikala");

            IWebElement contact = driver.FindElement(By.Id("ContactDisplay"));
            contact.SendKeys("9898989898");

            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("Sasikala$1");

            IWebElement retypePassword = driver.FindElement(By.Id("RetypePassword"));
            retypePassword.SendKeys("Sasikala$1");

            IWebElement isAdmin = driver.FindElement(By.Id("IsAdmin"));
            isAdmin.Click();

            IWebElement groupDropdown = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]"));
            groupDropdown.Click();

            Thread.Sleep(4000);

            IWebElement selectDropdown = driver.FindElement(By.XPath("//*[@id=\"groupList_listbox\"]/li[2]"));
            selectDropdown.Click();

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            IWebElement backtolistLink = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backtolistLink.Click();

            Thread.Sleep(4000);

            IWebElement goToLastPagebutton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPagebutton.Click();

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            Assert.That(newCode.Text == "Sasikala", "New code and expected code do not match");
        }

        public void Edit_EmployeeRecord(IWebDriver driver)
        {
            Thread.Sleep(4000);

            IWebElement goToLastPagebutton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPagebutton.Click();

            IWebElement createdRecord = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if (createdRecord.Text == "Sasikala")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited has not been found");
            }

            IWebElement name = driver.FindElement(By.Id("Name"));
            name.Clear();
            name.SendKeys("SasikalaSudharsan");

            IWebElement userName = driver.FindElement(By.Id("Username"));
            userName.Clear();
            userName.SendKeys("SasikalaSudharsan");

            IWebElement contact = driver.FindElement(By.Id("ContactDisplay"));
            contact.Clear();
            contact.SendKeys("4444444444");

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            IWebElement backtolistLink = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backtolistLink.Click();

            Thread.Sleep(4000);

            IWebElement goToLastPagebutton1 = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPagebutton1.Click();

            IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(editCode.Text == "SasikalaSudharsan", "Edit code and expected code do not match");

        }

        public void Delete_EmployeeRecord(IWebDriver driver)
        {
            Thread.Sleep(4000);

            IWebElement goToLastPagebutton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPagebutton.Click();

            IWebElement editRecord= driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (editRecord.Text == "SasikalaSudharsan")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
                deleteButton.Click();
            }
            else
            {
                Assert.Fail("Record to be deleted has not been found");
            }

            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(4000);

            IWebElement deleteRecord = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(deleteRecord.Text != "SasikalaSudharsan", "Record has not been deleted");
        }
    }
}
