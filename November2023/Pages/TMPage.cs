using November2023.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
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
           
            Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 4);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 4);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if (newCode.Text == "Sasikala")
            {
                Console.WriteLine("New record has been created successfully");
            }
            else
            {
                Console.WriteLine("Record has not created");
            }
        }

        public void Edit_TimeRecord(IWebDriver driver)
        {
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            IWebElement codeTextboxEdit = driver.FindElement(By.Id("Code"));
            codeTextboxEdit.Clear();
            codeTextboxEdit.SendKeys("SasikalaSudharsan");

            IWebElement descriptionTextboxEdit = driver.FindElement(By.Id("Description"));
            descriptionTextboxEdit.Clear();
            descriptionTextboxEdit.SendKeys("SasikalaSudharsanDescription");

            IWebElement saveButtonEdit = driver.FindElement(By.Id("SaveButton"));
            saveButtonEdit.Click();

            Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 4);

            IWebElement goToLastPageButtonEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonEdit.Click();

            Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 4);

            IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (editCode.Text == "SasikalaSudharsan")
            {
                Console.WriteLine("Existing record has been edited successfully");
            }
            else
            {
                Console.WriteLine("Record has not been edited");
            }
        }

        public void Delete_TimeRecord(IWebDriver driver)
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("Deleted the record successfully");
        }
    }
}
