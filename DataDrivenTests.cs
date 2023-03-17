using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace DataDrivenWebDriverTests
{
    public class DataDrivenTests
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

         IWebElement firstInput;
         IWebElement operationField;
         IWebElement secondInput;
         IWebElement calcButton;
         IWebElement resultField;
        IWebElement resetButtton;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;

            firstInput = driver.FindElement(By.Id("number1"));
            operationField = driver.FindElement(By.Id("operation"));
            secondInput = driver.FindElement(By.Id("number2"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            resetButtton = driver.FindElement(By.Id("resetButton"));
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            resetButtton.Click();
            firstInput.SendKeys("10");

            
            operationField.SendKeys("+");

            secondInput.SendKeys("2");

            
            calcButton.Click();

           var expectedResult = "Result: 12";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            resetButtton.Click();
            firstInput.SendKeys("-10");

           
            operationField.SendKeys("+");

            secondInput.SendKeys("-2");

            
            calcButton.Click();

          

            var expectedResult = "Result: -12";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
        [Test]
        public void Test_Multiply_TwoPositiveNumbers()
        {
            resetButtton.Click();
            firstInput.SendKeys("10");

            
            operationField.SendKeys("*");

            secondInput.SendKeys("2");

            
            calcButton.Click();

           

            var expectedResult = "Result: 20";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
        [Test]
        public void Test_Multiply_TwoNegativeNumbers()
        {
            resetButtton.Click();
            firstInput.SendKeys("-10");

           
            operationField.SendKeys("*");

            
            secondInput.SendKeys("-2");

            
            calcButton.Click();

            

            var expectedResult = "Result: 20";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
        [Test]
        public void Test_Substract_TwoNegativeNumbers()
        {
            resetButtton.Click();
            firstInput.SendKeys("-10");

            
            operationField.SendKeys("-");

            secondInput.SendKeys("-2");

           
            calcButton.Click();

            

            var expectedResult = "Result: -8";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
        [Test]
        public void Test_Substract_TwoPositiveNumbers()
        {
            resetButtton.Click();
            firstInput.SendKeys("10");

            operationField.SendKeys("-");

            
            secondInput.SendKeys("2");

         
            calcButton.Click();

            

            var expectedResult = "Result: 8";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
    }
}