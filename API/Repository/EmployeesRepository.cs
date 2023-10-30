using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmployeesRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employee.IsActive = false;
           _context.Employees.Add(employee);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> GetEmployeeById(int id) => await _context.Employees
        .SingleOrDefaultAsync(x => x.Id == id);
       

        public async Task<PagedList<EmployeeDto>> GetEmployees(PaginationParams paginationParams)
        {
            var query = _context.Employees
                  .OrderBy(o => o.AppointmentDate)
                  .AsQueryable();
            var employee = query.ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider);
            return await PagedList<EmployeeDto>.CreateAsync(employee, paginationParams.PageNumber, paginationParams.PageSize);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEmployee(Employee employee)
        {
           _context.Employees.Update(employee);
        }
    }
}