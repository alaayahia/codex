
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class CompensationsController : BaseApiController
    {
        private readonly ICompensationsRepository _compensationsRepository;
        private readonly IMapper _mapper;
        public CompensationsController(ICompensationsRepository compensationsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _compensationsRepository = compensationsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Compensation>> AddCompen(CompensationDto compDto)
        {
            var comp = new Compensation
            {
                CompName = compDto.CompName,
                CompMethod = compDto.CompMethod,
                CompType = compDto.CompType,
                CompEquation = compDto.Equation,
                IsAffected = compDto.IsAffected
            };
            _compensationsRepository.AddCompensation(comp);
            if(await _compensationsRepository.SaveAsync()) return Ok(_mapper.Map<CompensationDto>(comp));
            return BadRequest("Faild to Add Compensation");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompensationDto>>> GetCompensations([FromQuery] PaginationParams paginationParams)
        {
            var compens = await _compensationsRepository.GetCompensations(paginationParams);
            Response.AddPaginationHeader(compens.CurrentPage, compens.PageSize, compens.TotalCount, compens.TotalPages);
            return Ok(compens);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCompen(CompensationDto compensationDto)
        {
            var compens = await _compensationsRepository.GetCompensation(compensationDto.Id);
            _mapper.Map(compensationDto, compens);
            _compensationsRepository.UpdateCompenation(compens);
            if(await _compensationsRepository.SaveAsync()) return NoContent();
            return BadRequest("Faild To Edit a Compensation");
        }
    }
}