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
            return EmployeeRegistration.getInstance().getAllEmployees();
        }
    }
}
