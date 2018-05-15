using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using GufoMeParser.Core.Selenium.Classes.BaseClasses;

namespace GufoMeParser.Core.Selenium.Classes.BaseClasses
{
    abstract class Base
    {
        public abstract IWebDriver GetDriver(string name, string path);

        public abstract void Click(string xpath, IWebDriver driver);
    }
}
