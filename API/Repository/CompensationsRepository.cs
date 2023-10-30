using API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API.Repository
{
    public class CompensationsRepository : ICompensationsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CompensationsRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
           
        }

        public void AddCompensation(Compensation compensation) =>
           _context.Compensations.Add(compensation);
        

        public void DeleteCompensation(Compensation compensation)
        {
            compensation.IsActive = false;
            _context.Compensations.Update(compensation);
        }

        public async Task<Compensation> GetCompensation(int id) =>
          await _context.Compensations.FindAsync(id);        

        public async Task<PagedList<CompensationDto>> GetCompensations(PaginationParams paginationParams)
        {
           var query = _context.Compensations
                   .OrderByDescending(o => o.CompType)
                   .AsQueryable();
           var comp = query.ProjectTo<CompensationDto>(_mapper.ConfigurationProvider);

           return await PagedList<CompensationDto>.CreateAsync(comp, paginationParams.PageNumber, paginationParams.PageSize); 
        }

        public async Task<bool> SaveAsync() =>
           await _context.SaveChangesAsync() > 0;

        public void UpdateCompenation(Compensation compensation)
        {
            _context.Compensations.Update(compensation);
        }
    }
}