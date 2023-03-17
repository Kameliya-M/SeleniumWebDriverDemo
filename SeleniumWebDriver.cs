using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriverDemo
{
    public class SeleniumWebDriver
    {
        static void Main()
        {
            // create browser instance
            var driver = new ChromeDriver();

            // navigate to Wikipedia

            driver.Url = "https://wikipedia.org";

            // get browser title
            var pageTitle = driver.Title;
            Console.WriteLine("The page title is " + pageTitle);

            if (pageTitle == "Wikipedia")
            {
                Console.WriteLine("Test Pass");
            }
            else
            {
                Console.WriteLine("Test Fail");
            }

            // close browser
            driver.Quit();  
        }
    }
}