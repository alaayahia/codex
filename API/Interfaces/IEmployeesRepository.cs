using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IEmployeesRepository
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        Task<PagedList<EmployeeDto>> GetEmployees(PaginationParams paginationParams);
        Task<Employee> GetEmployee(int id);
        Task<Employee> GetEmployeeById(int id);
        Task<bool> SaveAsync();
    }
}