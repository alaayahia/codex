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
    public class EmpCompensationsRepository : IEmpCompensationsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmpCompensationsRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddEmpComp(EmployeeCompensation employeeCompensation)
        {
           _context.EmployeeCompensations.Add(employeeCompensation);
        }

        public void DeleteEmpComp(EmployeeCompensation employeeCompensation)
        {
           employeeCompensation.IsActive = false;
           _context.EmployeeCompensations.Update(employeeCompensation);
        }

        public async Task<EmployeeCompensation> GetEmpComp(int id)
        {
           return await _context.EmployeeCompensations.FindAsync(id);
        }

        public async Task<PagedList<EmpCompDto>> GetEmpComps(PaginationParams paginationParams)
        {
            var query = _context.EmployeeCompensations
                    .Include(x => x.Compensation)
                    .Include(x => x.Employee)
                    .OrderByDescending(o => o.EmpId)
                    .AsQueryable();
            var empComp = query.ProjectTo<EmpCompDto>(_mapper.ConfigurationProvider);
            return await PagedList<EmpCompDto>.CreateAsync(empComp, paginationParams.PageNumber, paginationParams.PageSize);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEmpComp(EmployeeCompensation employeeCompensation)
        {
            _context.EmployeeCompensations.Update(employeeCompensation);
        }
    }
}