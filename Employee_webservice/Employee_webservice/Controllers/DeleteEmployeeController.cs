using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee_webservice.Models;

namespace Employee_webservice.Controllers
{
    public class DeleteEmployeeController : ApiController
    {
        [Route("employee/delete/{employeeID}")]

        public String DeleteEmployee(String employeeID)
        {
            Console.WriteLine("In deleteEmployeeRecord");
            return EmployeeRegistration.getInstance().Remove(employeeID);
        }
    }
}
