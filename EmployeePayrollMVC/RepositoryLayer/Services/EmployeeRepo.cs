using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConfiguration configuration;

        public EmployeeRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        //To Add new employee record      
        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            if (employee != null)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("uspAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return employee;
            }
            else
            {
                return null;
            }
        }


        //To View all employees details      
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("uspEmployeesList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.EmpId = rdr.GetInt32("EmpId");
                    employee.EmpName = rdr["EmpName"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }



        //Get the details of a particular employee    
        public EmployeeModel GetEmployeeData(int id)
        {
            if (id >= 1)
            {
                EmployeeModel employee = new EmployeeModel();

                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("uspGetEmployeeById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.EmpId = rdr.GetInt32("EmpId");
                        employee.EmpName = rdr["EmpName"].ToString();
                        employee.ProfileImage = rdr["ProfileImage"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.Salary = Convert.ToInt32(rdr["Salary"]);
                        employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        employee.Notes = rdr["Notes"].ToString();
                    }
                    con.Close();
                }
                return employee;
            }
            else
            {
                return null;
            }
        }


        //To Update the records of a particluar employee    
        public string UpdateEmployee(EmployeeModel employee)
        {
            if (employee != null)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Employee is Updated Successfully..........";
            }
            else
            {
                return null;
            }
        }


        //To Delete the record on a particular employee    
        public string DeleteEmployee(int id)
        {
            if (id >= 1)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("uspDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Employee Is Deleted Successfully......................";
            }
            else
            {
                return null;
            }
        }



        public EmployeeModel EmpLogin(EmpLoginModel login)
        {
            if (login != null)
            {
                EmployeeModel employee = new EmployeeModel();

                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("uspEmpLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", login.EmpId);
                    cmd.Parameters.AddWithValue("@EmpName", login.EmpName);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.EmpId = rdr.GetInt32("EmpId");
                        employee.EmpName = rdr["EmpName"].ToString();
                        employee.ProfileImage = rdr["ProfileImage"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.Salary = Convert.ToInt32(rdr["Salary"]);
                        employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        employee.Notes = rdr["Notes"].ToString();
                    }
                    con.Close();
                }
                return employee;
            }
            else
            {
                return null;
            }
        }
        public EmployeeModel GetEmployeeDataByName(string name)
        {
            if (name != null)
            {
                EmployeeModel employee = new EmployeeModel();

                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("uspGetEmployeeByName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpName", name);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.EmpId = rdr.GetInt32("EmpId");
                        employee.EmpName = rdr["EmpName"].ToString();
                        employee.ProfileImage = rdr["ProfileImage"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.Salary = Convert.ToInt32(rdr["Salary"]);
                        employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        employee.Notes = rdr["Notes"].ToString();
                    }
                    con.Close();
                }
                return employee;
            }
            else
            {
                return null;
            }
        }



        public EmployeeModel InsertOrUpdate(EmployeeModel employee)
        {
            if (employee != null)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("uspCheckIdToUpdateOrInsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return employee;
            }
            else
            {
                return null;
            }
        }




    }
}
