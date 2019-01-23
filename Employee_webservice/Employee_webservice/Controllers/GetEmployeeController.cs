using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee_webservice.Models;

namespace Employee_webservice.Controllers
{
    //GET api/employeeretrive
    public class GetEmployeeController : ApiController
    {
        public List<Employees> GetAllEmployee()
        {
            //if (EmployeeRegistration.getInstance().getAllEmployees() == null)
            //{
            //    return new List<Employees>
            //{
            //    new Employees
            //    {
            //        firstName = "Glenn",
            //        lastName = "Block",
            //        Email = "",
            //        HireDate = "03/04/2018",
            //        Salary = 8900,
            //        DepartmentName = "QA",
            //        EmployeeID = 777

            //    },
            //    new Employees
            //    {
            //        firstName = "Dan",
            //        lastName = "Roth",
            //        Email = "",
            //        HireDate = "03/02/2018",
            //        Salary = 89000,
            //        DepartmentName = "QA II",
            //        EmployeeID = 333
            //    }

            //};
            //}
            //else
            //{
                Console.WriteLine("Get method is called");
                return EmployeeRegistration.getInstance().getAllEmployees();
            //}
            
        }
    }
}
