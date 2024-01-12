using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowBDD.Drivers
{
    public class DriveBase
    {
        public IWebDriver? Driver { get; set; }

        /// <summary>
        /// Method will generate an instance of driver according to the browser requirements
        /// </summary>
        /// <param name="browserName">Chrome or Firefox</param>
        /// <returns>An instance of IWebDriver</returns>
        /// <exception cref="ArgumentException">Wrong browser selection, No implementation for browsers other than chrome and firefox</exception>
        public IWebDriver GetWebDriver(string browserName = "chrome")
        {
            Driver = browserName.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                _ => throw new Exception("Not supported browser"),
            };
            if (Driver is not null)
            {
                Driver!.Manage().Window.Maximize();
            }
            else
            {
                throw new InvalidOperationException("Failed to initialize the driver.");
            }

            return Driver;
        }
    }
}