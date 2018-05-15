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

namespace GufoMeParser.Core.Selenium
{
    abstract class SeleniumWorkerCommonBase : IDisposable
    {
        private IWebDriver _driver { get; set; }

        public virtual IWebDriver GetDriver(string name, string path)
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
