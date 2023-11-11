using ManagerLayer.Interfaces;
using ModelLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo empRepo;

        public EmployeeManager(IEmployeeRepo empRepo)
        {
            this.empRepo = empRepo;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            return empRepo.AddEmployee(employee);
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return empRepo.GetAllEmployees();
        }

        public EmployeeModel GetEmployeeData(int id)
        {
            return empRepo.GetEmployeeData(id);
        }

        public string UpdateEmployee(EmployeeModel employee)
        {
            return empRepo.UpdateEmployee(employee);
        }

        public string DeleteEmployee(int id)
        {
            return empRepo.DeleteEmployee(id);
        }
    }
}
