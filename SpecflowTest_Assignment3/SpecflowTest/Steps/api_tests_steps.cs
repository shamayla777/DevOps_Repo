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
using RestSharp;

namespace SpecflowTest.Steps
{
    [Binding]
    class api_tests_steps
    {

        RestClient client = null;
        RestRequest request = null;
        IRestResponse response = null;
        Employee employee = null;
        [Given(@"I send GET request to my API")]
        public void GivenISendGETRequestToMyAPI()
        {
            client = new RestClient("http://localhost:52650/");
            request = new RestRequest("api/getemployee", Method.GET);
            response = client.Execute(request);
        }

        [When(@"I send a POST request to API to add employee")]
        public void WhenISendAPOSTRequestToAPIToAddEmployee()
        {
            request = new RestRequest("api/addemployee", Method.POST);
            employee = new Employee();
            employee.firstName = "Shamayla";
            employee.Email = "shamayla.shahzadi@spglobal.com";
            employee.EmployeeID = "777";
            request.AddJsonBody(employee);
            response = client.Execute(request);
        }

        [Then(@"I should get ""(.*)"" in response")]
        public void ThenIShouldGetInResponse(int p0)
        {
            
            String response_content = response.StatusCode.ToString();
            Console.WriteLine(response_content);
            if (response_content == "OK")
            {
                // Do Nothing
            }
            else
            {
                Assert.Fail();
            }
        }

        [When(@"I send GET request to API for an employee")]
        public void WhenISendGETRequestToAPIForAnEmployee()
        {
            client = new RestClient("http://localhost:52650/");
            request = new RestRequest("api/getemployee", Method.GET);
            response = client.Execute(request);
        }

        [Then(@"I should have requested employee in result")]
        public void ThenIShouldHaveRequestedEmployeeInResult()
        {
            String response_status = response.StatusCode.ToString();
            String response_content = response.Content;
            Console.WriteLine(response_content);
            if (response_status == "OK")
            {
                if(response_content.Contains("777"))
                    {
                    Console.WriteLine("777 employee found");
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        [When(@"I send DELETE request to API with employeeID")]
        public void WhenISendDELETERequestToAPIWithEmployeeID()
        {
            client = new RestClient("http://localhost:52650/");
            request = new RestRequest("employee/delete/"+"777", Method.DELETE);
            response = client.Execute(request);
        }

        [When(@"I send GET request to API for the deleted employee")]
        public void WhenISendGETRequestToAPIForTheDeletedEmployee()
        {
            client = new RestClient("http://localhost:52650/");
            request = new RestRequest("api/getemployee", Method.GET);
            response = client.Execute(request);
        }

        [Then(@"I should not receive deleted employee in result")]
        public void ThenIShouldNotReceiveDeletedEmployeeInResult()
        {
            String response_status = response.StatusCode.ToString();
            String response_content = response.Content;
            Console.WriteLine(response_content);
            if (response_status == "OK")
            {
                if (response_content.Contains("777"))
                {
                    Assert.Fail();
                }
                else
                {
                    Console.WriteLine("777 Employee is deleted");
                }
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
