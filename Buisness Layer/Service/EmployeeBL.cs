using Buisness_Layer.Interface;
using Common_Layer.Models;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL EmployeeRL;
        public EmployeeBL(IEmployeeRL EmployeeRL)
        {
            this.EmployeeRL= EmployeeRL;
        }

        public string AddEmployee(Employee employee)
        {
            try
            {
                return EmployeeRL.AddEmployee(employee);  
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return EmployeeRL.GetAllEmployees();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UpdateEmployee(Employee employee)
        {
            try
            {
                return EmployeeRL.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteEmployee(int? id)
        {
            try 
            {
                return EmployeeRL.DeleteEmployee(id); 
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Employee GetEmployeeData(int? id)
        {
            try
            {
                return EmployeeRL.GetEmployeeData(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
