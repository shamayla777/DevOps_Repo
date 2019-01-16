using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee_webservice.Models;

namespace Employee_webservice.Controllers
{
    public class AddEmployeeController : ApiController
    {
        public EmployeeRegistrationReply addEmployee(Employees empregd)
        {
            Console.WriteLine("In registerStudent");
            EmployeeRegistrationReply empregreply = new EmployeeRegistrationReply();
            EmployeeRegistration.getInstance().Add(empregd);
            empregreply.firstName = empregd.firstName;
            empregreply.lastName = empregd.lastName;
            empregreply.Email = empregd.Email;
            empregreply.HireDate = empregd.HireDate;
            empregreply.EmployeeID = empregd.EmployeeID;
            empregreply.DepartmentName = empregd.DepartmentName;
            empregreply.Salary = empregd.Salary;
            empregreply.RegistrationStatus = "Successful";
            return empregreply;
        }
    }
}
