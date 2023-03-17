using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace DataDrivenWebDriverTests
{
    public class DataDrivenTests2
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
        [TestCase("10", "+", "2", "Result: 12")]
        [TestCase("-10", "+", "-2", "Result: -12")]
        [TestCase("10", "*", "2", "Result: 20")]
        [TestCase("-10", "*", "-2", "Result: 20")]
        [TestCase("-10", "-", "-2", "Result: -8")]
        [TestCase("10", "-", "2", "Result: 8")]
        [TestCase("10", "-", "aaaa", "Result: invalid input")]
        public void Test_Calculate_TwoNumbers(string firstNum, string operation, string secondNum, string expectedResult)
        {
            resetButtton.Click();
            firstInput.SendKeys(firstNum);

            operationField.SendKeys(operation);

            secondInput.SendKeys(secondNum);

            
            calcButton.Click();

           
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
            
        }
      }