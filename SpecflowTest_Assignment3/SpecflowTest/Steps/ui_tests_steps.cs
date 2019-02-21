//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SpecflowTest.Steps
{
    [Binding]
    public class ui_tests_steps
    {
        string uri = "http://10.148.85.159:4444/wd/hub/";
        RemoteWebDriver driver = null;
        //ChromeDriver driver = new ChromeDriver();
        private void init_driver_chrome()
        {
            var caps = new ChromeOptions().ToCapabilities();
            var commandTimeOut = TimeSpan.FromMinutes(5);
            driver = new RemoteWebDriver(new Uri(uri), caps, commandTimeOut);
        }
        [Given(@"I navigate to my main page")]
        public void GivenINavigateToMyMainPage()
        {
            init_driver_chrome();
            driver.Navigate().GoToUrl("http://localhost:52650/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [When(@"I enter valid Employee Information")]
        public void WhenIEnterValidEmployeeInformation()
        {
            driver.FindElement(By.XPath("//*[@id='empid']")).SendKeys("777");
            driver.FindElement(By.XPath("//*[@id='fname']")).SendKeys("Shamayla");
            driver.FindElement(By.XPath("//*[@id='lname']")).SendKeys("Shahzadi");
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys("shamayla.shahzadi@spglobal.com");
            driver.FindElement(By.XPath("//*[@id='departmentname']")).SendKeys("QA");
            driver.FindElement(By.XPath("//*[@id='save']")).Click();
            Thread.Sleep(2000);
        }
        [Then(@"I should see employee in the list")]
        public void ThenIShouldSeeEmployeeInTheList()
        {
            IWebElement label = driver.FindElement(By.XPath("//*[@id='employees']/li[1]"));
            String labelText = label.Text;
            labelText = labelText.Substring(13, 3);
            if (labelText == "777")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Assert.Fail();
            }
        }

        [When(@"I enter valid Employee ID")]
        public void WhenIEnterValidEmployeeID()
        {
            driver.FindElement(By.XPath("//*[@id='empid_del']")).SendKeys("777");
            Thread.Sleep(2000);
        }


        [When(@"I click on Delete button")]
        public void WhenIClickOnDeleteButton()
        {
            driver.FindElement(By.XPath("//*[@id='delete']")).Click();
        }

        [Then(@"I should not see employee in the list")]
        public void ThenIShouldNotSeeEmployeeInTheList()
        {
            IWebElement label = driver.FindElement(By.XPath("//*[@id='employees']"));
            String labelText = label.Text;
            //labelText = labelText.Substring(13, 3);
            if (!labelText.Contains("777"))
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Assert.Fail();
            }
        }

    }
}
