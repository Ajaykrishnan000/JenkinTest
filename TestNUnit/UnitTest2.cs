using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumTests
{
    [TestFixture]
    public class UnitTest2
    {
        private IWebDriver driver;
        private string gridUrl = "http://localhost:4444/wd/hub"; // URL of your Selenium Grid Hub

        [SetUp]
        public void SetUp()
        {
            // Set up ChromeOptions
            var chromeOptions = new ChromeOptions();
            chromeOptions.PlatformName = "WINDOWS";  // Specify the platform
            chromeOptions.AddAdditionalOption("nodeName", "MyCustomNode");
            //options.PlatformName = "Windows";  // Ensure this matches the platform of the "Windows" node
            driver = new RemoteWebDriver(new Uri(gridUrl), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(60));
        }

        [Test]
        public void SampleTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(3000);
            //Assert.That("Google", Is.EqualTo(title));
            Assert.AreEqual(driver.Title, "Google");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
