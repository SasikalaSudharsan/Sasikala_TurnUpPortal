using November2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace November2023.Pages
{
    public class TMPage
    {
        public void Create_TimeRecord(IWebDriver driver)
        {
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]"));
            typeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("Sasikala");

            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Sasikala description");

            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("10");

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(4000);
           //Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 4);

            try
            {
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                Thread.Sleep(4000);
                goToLastPageButton.Click();
            }
            catch(Exception e)
            {
                Assert.Fail("Go to last page button hasn't been found.", e.Message);
            }
            
                                   
            Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 4);
           
            
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice= driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            //Assert.That(newCode.Text == "Sasikala", "New code and expected code do not match");
            Assert.That(newTypeCode.Text == "T", "New typecode and expected typecode do not match");
            Assert.That(newDescription.Text == "Sasikala description", "New description and expected description do not match");
            Assert.That(newPrice.Text == "$10.00", "New price and expected price do not match");
        }

        public String getCode(WebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public void Edit_TimeRecord(IWebDriver driver)
        {
            Thread.Sleep(4000);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement createdRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if(createdRecord.Text == "Sasikala")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited has not been found");
            }

            IWebElement codeTextboxEdit = driver.FindElement(By.Id("Code"));
            codeTextboxEdit.Clear();
            codeTextboxEdit.SendKeys("SasikalaSudharsan");

            IWebElement descriptionTextboxEdit = driver.FindElement(By.Id("Description"));
            descriptionTextboxEdit.Clear();
            descriptionTextboxEdit.SendKeys("SasikalaSudharsanDescription");

            IWebElement saveButtonEdit = driver.FindElement(By.Id("SaveButton"));
            saveButtonEdit.Click();

            Thread.Sleep(4000);
            //Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 4);

            IWebElement goToLastPageButtonEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonEdit.Click();

            Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 4);

            IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
                                                       
            Assert.That(editCode.Text == "SasikalaSudharsan", "Edit code and expected code do not match");
            Assert.That(editDescription.Text == "SasikalaSudharsanDescription", "Edit description and expected description do not match");
           /* if (editCode.Text == "SasikalaSudharsan")
            {
                Assert.Pass("Existing record has been edited successfully");
            }
            else
            {
                Assert.Fail("Record has not been edited");
            }*/
        }

        public void Delete_TimeRecord(IWebDriver driver)
        {
            Thread.Sleep(4000);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if(editedRecord.Text == "SasikalaSudharsan")
            {
                Thread.Sleep(4000);
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
            }
            else
            {
                Assert.Fail("Record to be deleted has not been found");
            }

            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(4000);

            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(deletedCode.Text != "SasikalaSudharsan", "Record has not been deleted");


        }
    }
}
