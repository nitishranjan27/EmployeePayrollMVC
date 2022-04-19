using Common_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interface
{
    public interface IEmployeeRL
    {
        public string AddEmployee(Employee employee);
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployeeData(int? id);
        public string UpdateEmployee(Employee employee);
        public string DeleteEmployee(int? id);
    } 
}