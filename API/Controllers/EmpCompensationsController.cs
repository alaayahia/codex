
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class EmpCompensationsController : BaseApiController
    {
        private readonly IEmpCompensationsRepository _empCompensationsRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly ICompensationsRepository _compensationsRepository;
        public EmpCompensationsController(IEmpCompensationsRepository empCompensationsRepository, IEmployeesRepository employeesRepository, ICompensationsRepository compensationsRepository, IMapper mapper)
        {
            _compensationsRepository = compensationsRepository;
            _employeesRepository = employeesRepository;
            _mapper = mapper;
            _empCompensationsRepository = empCompensationsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeCompensation>> AddEmpComp(EmpCompDto empCompDto)
        {
            var emp = await _employeesRepository.GetEmployee(empCompDto.EmpId);
            var comp = await _compensationsRepository.GetCompensation(empCompDto.CompId);
            var empComp = new EmployeeCompensation
            {
                Employee = emp,
                Compensation = comp,
                CompValue = empCompDto.CompValue,
                StartFrom = empCompDto.StartFrom,
            };
            _empCompensationsRepository.AddEmpComp(empComp);
            if(await _empCompensationsRepository.SaveAsync()) return Ok(_mapper.Map<EmpCompDto>(empComp));
            return BadRequest("Faild to save data");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpCompDto>>> GetEmpComp([FromQuery] PaginationParams paginationParams)
        {
            var empComps = await _empCompensationsRepository.GetEmpComps(paginationParams);
            Response.AddPaginationHeader(empComps.CurrentPage, empComps.PageSize, empComps.TotalCount, empComps.TotalPages);
            return Ok(empComps);
        }
        [HttpPut]
        public async Task<ActionResult> EditEmpComp(EmpCompDto empCompDto)
        {
            var empComp = await _empCompensationsRepository.GetEmpComp(empCompDto.Id);
            _mapper.Map(empCompDto, empComp);
            _empCompensationsRepository.UpdateEmpComp(empComp);
            if(await _empCompensationsRepository.SaveAsync()) return NoContent();
            return BadRequest("Faild to edit ");
        }
    }
}