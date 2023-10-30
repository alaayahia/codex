using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ICompensationsRepository
    {
        void AddCompensation(Compensation compensation);
        void DeleteCompensation(Compensation compensation);
        void UpdateCompenation(Compensation compensation);
        Task<Compensation> GetCompensation(int id);
        Task<PagedList<CompensationDto>> GetCompensations(PaginationParams paginationParams);
        Task<bool> SaveAsync();
        
    }
}