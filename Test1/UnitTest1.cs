using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        private static IWebDriver driver = new ChromeDriver();

        [SetUp]
        

        public void Setup0() => driver.Navigate().GoToUrl("https://localhost:7169/Create");
       

        [TestMethod]
        public void Test()
        {


            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var name = driver.FindElement(By.Id("Name"));
            var phone = driver.FindElement(By.Id("Phone"));
            var reservationDate = driver.FindElement(By.Id("ReservationDate"));
            var reservationDateEnd = driver.FindElement(By.Id("ReservationDateEnd"));
            IWebElement createButton = driver.FindElement(By.CssSelector("input[type='submit']"));
         
            name.SendKeys("John Doe");
            phone.SendKeys("1234567890");
            reservationDate.SendKeys("25.06.2023");
            reservationDateEnd.SendKeys("28.06.2023");

            createButton.Click();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.Url.Contains("https://localhost:7169/Users"));
     
        }

        [TearDown]
        public void Teardown()
        {

            driver.Quit();
            driver.Dispose();
        }
    }



}