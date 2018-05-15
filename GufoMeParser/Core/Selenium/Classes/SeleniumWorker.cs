using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GufoMeParser.Core.Selenium.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GufoMeParser.Core.Selenium.Classes
{
    class SeleniumWorker : SeleniumWorkerCommonBase, IWorker
    {
        public void DoWork()
        {
            using (var driver = GetDriver("Chrome","C:\\Users\\Дмитрий\\Desktop\\"))
            {

            }
        }
    }
}
