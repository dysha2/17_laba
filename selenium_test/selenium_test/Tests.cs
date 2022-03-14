using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace selenium_test
{
    [TestFixture]
    public class Tests
    {
        IWebDriver webDriver= new ChromeDriver();

        [TestCase]
        public void calc_mainTitle()
        {
            webDriver.Url = "https://calcus.ru/kalkulyator-ipoteki";
            Assert.AreEqual("Калькулятор ипотеки, рассчитать ипотеку", webDriver.Title);
            webDriver.Close();
        }
        [TestCase]
        public void Calc_But()
        {
            webDriver.Url = "https://calcus.ru/kalkulyator-ipoteki";
            if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[10]/div/input"))
            {
                IWebElement button = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[10]/div/input"));
                button.Click();
            }
            IWebElement result = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[14]/div[1]/div[1]/div[2]/div"));
            Assert.IsFalse(result.Displayed);
        }
        [TestCase]
        public void Calc_SendErrodData()
        {
            webDriver.Url = "https://calcus.ru/kalkulyator-ipoteki";
            if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[3]/div[2]/div[1]/input"))
            {
                IWebElement search = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[3]/div[2]/div[1]/input"));
                search.SendKeys("Функциональное тестирование");
                Assert.AreEqual("",search.Text);
            }
        }
        [TestCase]
        public void Calc_GoToMainPage()
        {
            webDriver.Url = "https://calcus.ru/kalkulyator-ipoteki";
            if (IsLoaded("/html/body/div[1]/ul/li[1]/a/span"))
            {
                IWebElement element = webDriver.FindElement(By.XPath("/html/body/div[1]/ul/li[1]/a/span"));
                element.Click();
                Assert.AreEqual(webDriver.Url, "https://calcus.ru/");
            }
        }
        [TestCase]
        public void Calc_SummOfCredit()
        {
            webDriver.Url = "https://calcus.ru/kalkulyator-ipoteki";
            if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[2]/div[2]/div[1]/input"))
            {
                IWebElement fullPrice = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/div[2]/div[1]/input"));
                fullPrice.SendKeys("1000");
                IWebElement payedPrice = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[3]/div[2]/div[1]/input"));
                payedPrice.SendKeys("100");
                IWebElement Credit = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[4]/div[2]/span[1]"));
                Assert.AreEqual(Credit.Text, "900");
            }
        }
        [TestCase]
        public void Calc_PercentsAndDuty()
        {
            webDriver.Url = "https://calcus.ru/kalkulyator-ipoteki";
            if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[2]/div[2]/div[1]/input"))
            {
                IWebElement fullPrice = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/div[2]/div[1]/input"));
                fullPrice.SendKeys("1000");
                IWebElement payedPrice = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[3]/div[2]/div[1]/input"));
                payedPrice.SendKeys("100");
                IWebElement termCredit = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[6]/div[2]/div[1]/input"));
                termCredit.SendKeys("3");
                IWebElement percents = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[8]/div[2]/div[1]/input"));
                percents.SendKeys("10");
                IWebElement button = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[10]/div/input"));
                button.Click();
                if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[14]/div[1]/div[5]/div[2]/div"))
                {
                    IWebElement DutyAndPercents = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[14]/div[1]/div[5]/div[2]/div"));
                    Assert.AreEqual(DutyAndPercents.Text, "1 045,44");
                }
            }
        }
        [TestCase]
        public void Calc_MonthlyPayment()
        {
            webDriver.Url = "https://calcus.ru/kalkulyator-ipoteki";
            if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[2]/div[2]/div[1]/input"))
            {
                IWebElement fullPrice = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/div[2]/div[1]/input"));
                fullPrice.SendKeys("1000");
                IWebElement payedPrice = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[3]/div[2]/div[1]/input"));
                payedPrice.SendKeys("100");
                IWebElement termCredit = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[6]/div[2]/div[1]/input"));
                termCredit.SendKeys("3");
                IWebElement percents = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[8]/div[2]/div[1]/input"));
                percents.SendKeys("10");
                IWebElement button = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[10]/div/input"));
                button.Click();
                if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[14]/div[1]/div[5]/div[2]/div"))
                {
                    IWebElement DutyAndPercents = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[14]/div[1]/div[1]/div[2]/div"));
                    Assert.AreEqual(DutyAndPercents.Text, "29,04");
                }
            }
        }
        [TestCase]
        public void Calc_InterestCharges()
        {
            webDriver.Url = "https://calcus.ru/kalkulyator-ipoteki";
            if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[2]/div[2]/div[1]/input"))
            {
                IWebElement fullPrice = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/div[2]/div[1]/input"));
                fullPrice.SendKeys("1000");
                IWebElement payedPrice = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[3]/div[2]/div[1]/input"));
                payedPrice.SendKeys("100");
                IWebElement termCredit = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[6]/div[2]/div[1]/input"));
                termCredit.SendKeys("3");
                IWebElement percents = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[8]/div[2]/div[1]/input"));
                percents.SendKeys("10");
                IWebElement button = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[10]/div/input"));
                button.Click();
                if (IsLoaded("/html/body/div[1]/div[2]/div[1]/form/div[14]/div[1]/div[5]/div[2]/div"))
                {
                    IWebElement DutyAndPercents = webDriver.FindElement(By.XPath("//html/body/div[1]/div[2]/div[1]/form/div[14]/div[1]/div[4]/div[2]/div"));
                    Assert.AreEqual(DutyAndPercents.Text, "145,44");
                }
            }
        }
        public bool IsLoaded(string XPath)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));
            bool element = wait.Until(condition =>
            {
                try
                {
                    var elementDisplayes = webDriver.FindElement(By.XPath(XPath));
                    return elementDisplayes.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            );
            return element;
        }
        [TearDown]
        public void testEnd()
        {
            webDriver.Quit();
        }
    }
}
