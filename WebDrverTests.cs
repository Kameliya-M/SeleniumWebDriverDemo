using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelenuimWebDriverNUnitDemo
{
    public class WebDriverTests
    {
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            this.driver= new ChromeDriver(options);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Wikipedia_CheckTitle()
        {
            driver.Url = "https://wikipedia.org";
            var pageTitle = driver.Title;

            Assert.That("Wikipedia", Is.EqualTo(pageTitle));
        }
        [Test]
        public void Test_Wikipedia_SearchField()
        {
            //Arrange
            driver.Url = "https://wikipedia.org";

            // Act
            // Locate by ID
            var searchField = driver.FindElement(By.Id("searchInput"));

            searchField.SendKeys("QA" + Keys.Enter);

            var pageTitle = driver.Title;

            // Assert

            Assert.That("QA - Wikipedia", Is.EqualTo(pageTitle));

            
        }
        [Test]
        public void checkSearch()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 738);
            driver.FindElement(By.Id("searchInput")).SendKeys("qa");
            driver.FindElement(By.Id("searchInput")).SendKeys(Keys.Enter);
            driver.Close();
        }
        [Test]
        public void Test_CheckEnglish()
        {
            //Get Element By Tagname
            driver.Url = "https://wikipedia.org";

            var allStrongElements = driver.FindElements(By.TagName("strong"));
            
            var englishLinkText = allStrongElements[1].Text;

            Assert.That("English", Is.EqualTo(englishLinkText));
        }
        [Test]
        public void Test_CheckEnglish_ByLink()
        {
            //Get Element By ID
            driver.Url = "https://wikipedia.org";

            var allStrongElements = driver.FindElements(By.TagName("strong"));

            var englishLink = driver.FindElement(By.PartialLinkText("English"));
            englishLink.Click();

            var pageTitle = driver.Title;

            Assert.That("Wikipedia, the free encyclopedia", Is.EqualTo(pageTitle));
        }
    }
}

