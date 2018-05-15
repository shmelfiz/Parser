using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using HtmlAgilityPack;

namespace GufoMeParser
{
    class Program
    {
        static void Main(string[] args)
        {
           /* using (IWebDriver driver = new ChromeDriver("C:\\Users\\Дмитрий\\Desktop\\"))
            {*/
                var driver = new ChromeDriver("C:\\Users\\Дмитрий\\Desktop\\");
                //Notice navigation is slightly different than the Java version
                //This is because 'get' is a keyword in C#
                driver.Navigate().GoToUrl("https://gufo.me/dict/ozhegov/а");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var url = "https://gufo.me/dict/ozhegov/а";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var value = doc.DocumentNode
.SelectNodes("//article")
.First().InnerText;


            //var parse = doc.

            // Find the text input element by its name
            // driver.FindElementByXPath("//div[@class='col text-right']/child::a/@href").Click();
            driver.FindElementByXPath("//div[@class='col text-right']/child::a").Click();
            //query.Submit();
            Console.WriteLine(value);
            Console.ReadKey();
            // Enter something to search for
            //query.SendKeys("Cheese");

            // Now submit the form. WebDriver will find the form for us from the element
            //query.Submit();

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

            // Should see: "Cheese - Google Search" (for an English locale)
            Console.WriteLine("Page title is: " + driver.Title);
           // }
        }
    }
}
