using Common_Layer.Models;
using Microsoft.Extensions.Configuration;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository_Layer.Service
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration configuration;
        public EmployeeRL(IConfiguration configuration)
        {
            this.configuration= configuration;
        }

        //To Add new Employee record      
        public string AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.profileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Note", employee.Note);
                
                con.Open();
                var result= cmd.ExecuteNonQuery();
                con.Close();
                if (result !=0)
                {
                    return "Employee Added Successfully";
                }
                else
                {
                    return "Added Unsuccessfull";
                }
            }
        }

        //To View all Employees details      
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstemployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.profileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Note = Convert.ToString(rdr["Note"]);

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        //To Update the records of a particluar Employee    
        public string UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.profileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Note", employee.Note);

                con.Open();
                var result=cmd.ExecuteNonQuery();
                con.Close();

                if (result != 0)
                {
                    return "Employee Updated Successfully";
                }
                else
                {
                    return "Update Unsuccessfull";
                }
            }
        }

        //Get the details of a particular employee    
        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                string sqlQuery = "SELECT * FROM Employee WHERE EmployeeId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.profileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Note = Convert.ToString(rdr["Note"]);
                }
            }
            return employee;
        }

        //To Delete the record on a particular Employee    
        public string DeleteEmployee(int? id)
        {

            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if(result != 0)
                {
                    return " Employee Deleted Successfully";
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
