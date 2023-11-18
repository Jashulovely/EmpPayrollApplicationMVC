using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IEmployeeManager
    {
        public EmployeeModel AddEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int id);
        public EmployeeModel GetEmployeeDataByName(string name);
        public EmployeeModel InsertOrUpdate(EmployeeModel employee);
        public string UpdateEmployee(EmployeeModel employee);
        public string DeleteEmployee(int id);
        public EmployeeModel EmpLogin(EmpLoginModel login);
    }
}
