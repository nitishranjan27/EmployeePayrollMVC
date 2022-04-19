using Common_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

//Interface
namespace Buisness_Layer.Interface
{
    public interface IEmployeeBL
    {
        public string AddEmployee(Employee employee);
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployeeData(int? id);
        public string UpdateEmployee(Employee employee);
        public string DeleteEmployee(int? id);
    }
}
