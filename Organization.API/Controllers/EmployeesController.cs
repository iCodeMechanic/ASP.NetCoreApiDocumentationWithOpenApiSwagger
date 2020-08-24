using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organization.API.Dto;
using Organization.API.IRepository;
using Organization.API.Model;

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IDepartmentRepository departmentRepository,
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees(Guid departmentId)
        {
            if (!await _departmentRepository.DepartmentExistsAsync(departmentId))
            {
                return NotFound();
            }

            var employeesFromRepo = await _employeeRepository.GetEmployeesAsync(departmentId);

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeesFromRepo));
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(
            Guid departmentId,
            Guid employeeId)
        {
            if (!await _departmentRepository.DepartmentExistsAsync(departmentId))
            {
                return NotFound();
            }

            var employeeFromRepo = await _employeeRepository.GetEmployeeAsync(departmentId, employeeId);
            if (employeeFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeDto>(employeeFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(
            Guid departmentId,
            EmployeeForCreationDto employeeForCreationDto)
        {
            if (!await _departmentRepository.DepartmentExistsAsync(departmentId))
            {
                return NotFound();
            }

            var employeeToAdd = _mapper.Map<Employee>(employeeForCreationDto);
            _employeeRepository.AddEmployee(employeeToAdd);
            await _employeeRepository.SaveChangesAsync();

            return CreatedAtRoute(
                
                "GetEmployee",
                new {departmentId, employeeId=employeeToAdd.Id},
                _mapper.Map<EmployeeDto>(employeeToAdd));
                
        }
    }
}
