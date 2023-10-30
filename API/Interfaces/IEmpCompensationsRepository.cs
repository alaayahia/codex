
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IEmpCompensationsRepository
    {
        void AddEmpComp(EmployeeCompensation employeeCompensation);
        void UpdateEmpComp(EmployeeCompensation employeeCompensation);
        void DeleteEmpComp(EmployeeCompensation employeeCompensation);
        Task<EmployeeCompensation> GetEmpComp(int id);
        Task<PagedList<EmpCompDto>> GetEmpComps(PaginationParams paginationParams);
        Task<bool> SaveAsync();
        
    }
}