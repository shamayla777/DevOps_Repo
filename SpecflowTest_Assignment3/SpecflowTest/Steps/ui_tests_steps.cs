using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTest.Steps
{
    [Binding]
    public class ui_tests_steps
    {

        ChromeDriver driver = new ChromeDriver();
        [Given(@"I navigate to my main page")]
        public void GivenINavigateToMyMainPage()
        {
            driver.Navigate().GoToUrl("http://localhost:52650/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        //[When(@"I click on Create New Employee link")]
        //public void WhenIClickOnCreateNewEmployeeLink()
        //{
        //    driver.FindElement(By.XPath("/html/body/p/a")).Click();
        //    Thread.Sleep(2000);
        //}

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
            //ScenarioContext.Current.Pending();
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
            IWebElement label = driver.FindElement(By.XPath("//*[@id='employees']/li[1]"));
            String labelText = label.Text;
            //labelText = labelText.Substring(13, 3);
            if (labelText != "777")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Assert.Fail();
            }
            //ScenarioContext.Current.Pending();
        }

        //[Then(@"I should be on the main page again")]
        //public void ThenIShouldBeOnTheMainPageAgain()
        //{
        //    IWebElement newEmpBtn = driver.FindElement(By.XPath("/html/body/p/a"));
        //    if (newEmpBtn != null)
        //    {
        //        Console.WriteLine("Passed");
        //    } else
        //    {
        //        Assert.Fail();
        //    }
        //}

    }
}
