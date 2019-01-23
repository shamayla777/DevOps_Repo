using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_webservice.Models
{
    public class EmployeeRegistrationReply
    {
        String fname;
        public String firstName
        {
            get { return fname; }
            set { fname = value; }
        }

        String lname;
        public String lastName
        {
            get { return lname; }
            set { lname = value; }
        }

        String email;
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        String hireDate;
        public String HireDate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }

        String employeeId;
        public String EmployeeID
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        String departmentName;
        public String DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        int salary;
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        String registrationStatus;
        public String RegistrationStatus
        {
            get { return registrationStatus; }
            set { registrationStatus = value; }
        }
    }
}