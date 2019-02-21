//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SpecflowTest.Steps
{
    [Binding]
    public class ui_tests_steps_FF
    {
        //FirefoxDriver driver = new FirefoxDriver();
        string uri = "http://10.148.85.159:4444/wd/hub/";
        RemoteWebDriver driver = null;
        private void init_driver_ff()
        {
            FirefoxOptions Options = new FirefoxOptions();
            //options.AddAdditionalCapability("browserName","firefox");
            //options.AddAdditionalCapability("platform", "WIN8_1");
            //options.AddAdditionalCapability("version", "ANY");
            // var caps = new FirefoxOptions().ToCapabilities();

            //var commandTimeOut = TimeSpan.FromMinutes(5);
            //driver = new RemoteWebDriver(new Uri(uri), options.ToCapabilities(), commandTimeOut);

            driver = new RemoteWebDriver(new Uri(uri), Options.ToCapabilities(), TimeSpan.FromSeconds(600));
        }
        [Given(@"I navigate to my main page on FF")]
        public void GivenINavigateToMyMainPageOnFF()
        {
            init_driver_ff();
            driver.Navigate().GoToUrl("http://localhost:52650/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [When(@"I enter valid Employee Information on FF")]
        public void WhenIEnterValidEmployeeInformationOnFF()
        {
            driver.FindElement(By.XPath("//*[@id='empid']")).SendKeys("778");
            driver.FindElement(By.XPath("//*[@id='fname']")).SendKeys("Shamayla");
            driver.FindElement(By.XPath("//*[@id='lname']")).SendKeys("Shahzadi");
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys("shamayla.shahzadi@spglobal.com");
            driver.FindElement(By.XPath("//*[@id='departmentname']")).SendKeys("QA");
            driver.FindElement(By.XPath("//*[@id='save']")).Click();
            Thread.Sleep(2000);
        }

        [Then(@"I should see employee in the list on FF")]
        public void ThenIShouldSeeEmployeeInTheListOnFF()
        {
            IWebElement label = driver.FindElement(By.XPath("//*[@id='employees']"));
            String labelText = label.Text;
            //labelText = labelText.Substring(13, 3);
            if (labelText.Contains("778"))
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Assert.Fail();
            }
        }

        [When(@"I enter valid Employee ID on FF")]
        public void WhenIEnterValidEmployeeIDOnFF()
        {
            driver.FindElement(By.XPath("//*[@id='empid_del']")).SendKeys("778");
            Thread.Sleep(2000);
        }

        [When(@"I click on Delete button on FF")]
        public void WhenIClickOnDeleteButtonOnFF()
        {
            driver.FindElement(By.XPath("//*[@id='delete']")).Click();
        }

        [Then(@"I should not see employee in the list on FF")]
        public void ThenIShouldNotSeeEmployeeInTheListOnFF()
        {
            IWebElement label = driver.FindElement(By.XPath("//*[@id='employees']"));
            String labelText = label.Text;
            //labelText = labelText.Substring(13, 3);
            if (!labelText.Contains("778"))
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
