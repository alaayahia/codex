
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IEmpDocumentsRepository
    {
        void AddEmpDoc(EmployeeDocument employeeDocument);
        void UpdateEmpDoc(EmployeeDocument employeeDocument);
        void DeleteEmpDoc(EmployeeDocument employeeDocument);
        Task<EmployeeDocument> GetEmployeeDocument(int id);
        Task<PagedList<EmpDocDto>> GetEmpDocs(PaginationParams paginationParams);
        Task<bool> SaveAsync();
        
    }
}