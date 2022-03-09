using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_test
{
    [TestFixture]
    public class Tests
    {
        IWebDriver webDriver= new ChromeDriver();

        [TestCase]
        public void mainTitle()
        {
            webDriver.Url = "https://sibsutis.ru";
            Assert.AreEqual("Сибирский государственный университет телекоммуникаций и информатики", webDriver.Title);
            webDriver.Close();
        }
        [TearDown]
        public void testEnd()
        {
            webDriver.Quit();
        }
    }
}
