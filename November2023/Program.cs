
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Open Chrome browser
IWebDriver driver = new ChromeDriver(); //instance of a browser
driver.Manage().Window.Maximize();

//Launch TurnUp portal and navigate to the login page
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");

IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();

IWebElement loginMessage = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

if(loginMessage.Text == "Hello hari!")
{
    Console.WriteLine("User has logged in successfully");
}
else
{
    Console.WriteLine("User hasn't been logged in");
}



