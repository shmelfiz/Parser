using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GufoMeParser.Core.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using GufoMeParser.Core.Selenium.Classes.BaseClasses;

namespace GufoMeParser.Core.Selenium.Classes
{
    class SeleniumWorkerCommonBase : Base, IDisposable
    {
        private IWebDriver _driver { get; set; }

        public override void Click(string xpath, IWebDriver driver)
        {
            IWebElement query = driver.FindElement(By.Name("q"));
        }

        public override IWebDriver GetDriver(string name, string path)
        {
            switch (name)
            {
                case "Chrome" :
                    {
                        _driver = new ChromeDriver(path);
                        return _driver;
                    }
                case "Firefox":
                    {
                        _driver = new FirefoxDriver(path);
                        return _driver;
                    }
                case "Opera":
                    {
                        _driver = new OperaDriver(path);
                        return _driver;
                    }
            }

            throw new Exception("Введите корректное имя браузера!");
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
