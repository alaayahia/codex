
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
    public class EmpDocumentsRepository : IEmpDocumentsRepository
    {
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmpDocumentsRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddEmpDoc(EmployeeDocument employeeDocument)
        {
            _context.EmployeeDocuments.Add(employeeDocument);
        }

        public void DeleteEmpDoc(EmployeeDocument employeeDocument)
        {
            employeeDocument.IsActive = false;
            _context.EmployeeDocuments.Update(employeeDocument);
        }

        public async Task<PagedList<EmpDocDto>> GetEmpDocs(PaginationParams paginationParams)
        {
            var query = _context.EmployeeDocuments
                    .Include(x => x.Employee)
                    .OrderByDescending(o => o.DocName)
                    .AsQueryable();
            var empDoc = query.ProjectTo<EmpDocDto>(_mapper.ConfigurationProvider);
            return await PagedList<EmpDocDto>.CreateAsync(empDoc, paginationParams.PageNumber, paginationParams.PageSize);
            
        }

        public async Task<EmployeeDocument> GetEmployeeDocument(int id)
        {
            return await _context.EmployeeDocuments.FindAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEmpDoc(EmployeeDocument employeeDocument)
        {
           _context.EmployeeDocuments.Update(employeeDocument);
        }
    }
}