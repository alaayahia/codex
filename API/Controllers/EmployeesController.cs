
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeesRepository employeesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeesRepository = employeesRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                EmpName = employeeDto.EmpName,
                DateOfBirth = employeeDto.DateOfBirth,
                Gender = employeeDto.Gender,
                EmpPhone = employeeDto.Phone,
                JopDescription = employeeDto.JopDescription,
                AppointmentDate = employeeDto.AppointmentDate
            };

            _employeesRepository.AddEmployee(employee);
            
            if(await _employeesRepository.SaveAsync()) return Ok(_mapper.Map<EmployeeDto>(employee));
            return BadRequest("Faild to Save An Employee");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpCompDto>>> GetEmployees([FromQuery] PaginationParams paginationParams)
        {
            var employees = await _employeesRepository.GetEmployees(paginationParams);
            Response.AddPaginationHeader(employees.CurrentPage, employees.PageSize, employees.TotalCount, employees.TotalPages);
            return Ok(employees);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            var employee = await _employeesRepository.GetEmployee(employeeDto.Id);
            _mapper.Map(employeeDto, employee);
            _employeesRepository.UpdateEmployee(employee);
            if(await _employeesRepository.SaveAsync()) return NoContent();
            return BadRequest("Fail to Edit An Employee");
        }


    }
}