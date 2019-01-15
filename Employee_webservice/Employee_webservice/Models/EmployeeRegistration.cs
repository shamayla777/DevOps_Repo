using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_webservice.Models
{
    public class EmployeeRegistration
    {
        List<Employees> employeeList;
        static EmployeeRegistration stdregd = null;

        private EmployeeRegistration()
        {
            employeeList = new List<Employees>();
        }


        public static EmployeeRegistration getInstance()
        {
            if (stdregd == null)
            {
                stdregd = new EmployeeRegistration();
                return stdregd;
            }
            else
            {
                return stdregd;
            }
        }


        public void Add(Employees employee)
        {
            employeeList.Add(employee);
        }


        public String Remove(String employeeId)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                Employees stdn = employeeList.ElementAt(i);
                if (stdn.EmployeeID.Equals(employeeId))
                {
                    employeeList.RemoveAt(i); //update the new record
                    return "Delete successful";
                }
            }
            return "Delete un-successful";
        }

        public List<Employees> getAllEmployees()
        {
            return employeeList;
        }

    }



}