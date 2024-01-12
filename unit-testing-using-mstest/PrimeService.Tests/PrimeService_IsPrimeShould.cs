using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prime.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Prime.UnitTests.Services
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;
        private WebDriver driver;

        public PrimeService_IsPrimeShould()
        {
            DriverOptions capability = new OpenQA.Selenium.Chrome.ChromeOptions();

            capability.BrowserVersion = "latest";

            capability.AddAdditionalOption("bstack:options", capability);
            driver = new RemoteWebDriver(
                new Uri("http://localhost:4444/wd/hub/"),
                capability
            );
            _primeService = new PrimeService();
        }

        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            bool result = _primeService.IsPrime(1);
            driver.Navigate().GoToUrl("https://bstackdemo.com/");
            Assert.IsFalse(result, "1 should not be prime");
            driver.Quit();
        }
    }
}