using AutoMapper;
using backend.Core.Context;
using backend.Core.Dtos.Company;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDto dto)
        {
            Company newCompany = _mapper.Map<Company>(dto);
            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();

            return Ok("Company created Successfully");
        }
        //Read
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanis()
        {
            var companies = await _context.Companies.ToListAsync();
            var convertedCompanies = _mapper.Map< IEnumerable<CompanyGetDto>>(companies);

            return Ok(convertedCompanies);
        }

        //Read (Get Company by ID)
        //Update

        //Delete

    }
}
