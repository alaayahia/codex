using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpDocumentsController : BaseApiController
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;
        private readonly IEmpDocumentsRepository _empDocumentsRepository;
        public EmpDocumentsController(IEmpDocumentsRepository empDocumentsRepository, IEmployeesRepository employeesRepository, IMapper mapper)
        {
            _empDocumentsRepository = empDocumentsRepository;
            _mapper = mapper;
            _employeesRepository = employeesRepository;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeCompensation>> AddEmpDoc(EmpDocDto empDocDto)
        {
            var emp = await _employeesRepository.GetEmployee(empDocDto.EmpId);
            var empDoc = new EmployeeDocument
            {
                Employee = emp,
                DocName = empDocDto.DocName,
                DocType = empDocDto.DocType,
                DocUrl = empDocDto.DocUrl
            };
            _empDocumentsRepository.AddEmpDoc(empDoc);
            if(await _empDocumentsRepository.SaveAsync()) return Ok(_mapper.Map<EmpDocDto>(empDoc));
            return BadRequest("Faild to add documents");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpDocDto>>> getEmpDoc([FromQuery] PaginationParams paginationParams)
        {
            var empDoc = await _empDocumentsRepository.GetEmpDocs(paginationParams);
            Response.AddPaginationHeader(empDoc.CurrentPage, empDoc.PageSize, empDoc.TotalCount, empDoc.TotalPages);
            return Ok(empDoc);
        }
    }
}
