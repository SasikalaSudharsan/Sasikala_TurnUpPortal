
using November2023.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome browser
        IWebDriver driver = new ChromeDriver(); //instance of a browser

        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        HomePage homePageObj = new HomePage();
        homePageObj.GotoTMPage(driver);

        TMPage tmPageObj = new TMPage();
        tmPageObj.Create_TimeRecord(driver);
        tmPageObj.Edit_TimeRecord(driver);
        tmPageObj.Delete_TimeRecord(driver);

    }
        

        
}