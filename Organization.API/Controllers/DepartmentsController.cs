using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Organization.API.Dto;
using Organization.API.IRepository;

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var departmentFromRepo = await _departmentRepository.GetDepartmentsAsync();
            return Ok(_mapper.Map<IEnumerable<DepartmentDto>>(departmentFromRepo));
        }

        [HttpGet("{departmentId}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(Guid departmentId)
        {
            var departmentFromRepo = await _departmentRepository.GetDepartmentAsync(departmentId);
            if (departmentFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DepartmentDto>(departmentFromRepo));
        }

        [HttpPut("{departmentId}")]
        public async Task<ActionResult<DepartmentDto>> UpdateDepartment(Guid departmentId,
            DepartmentForUpdateDto departmentForUpdateDto)
        {
            var departmentFromRepo = await _departmentRepository.GetDepartmentAsync(departmentId);

            if (departmentFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(departmentForUpdateDto, departmentFromRepo);

            //Update and Save
            _departmentRepository.UpdateDepartment(departmentFromRepo);
            await _departmentRepository.SaveChangesAsync();

            //Return the Department
            return Ok(_mapper.Map<DepartmentDto>(departmentFromRepo));
        }

        [HttpPatch("{departmentId}")]
        public async Task<ActionResult<DepartmentDto>> UpdateDepartment(Guid departmentId,
            JsonPatchDocument<DepartmentForUpdateDto> patchDocument)
        {
            var departmentFromRepo = await _departmentRepository.GetDepartmentAsync(departmentId);
            if (departmentFromRepo == null)
            {
                return NotFound();
            }

            // map to DTO to apply the patch
            var department = _mapper.Map<DepartmentForUpdateDto>(departmentFromRepo);
            patchDocument.ApplyTo(department, ModelState);

            // If any error occurs when applying the patch 
            // and the patchdocument formed incorrect, so the ApiController validtion not able to caught
            //so we have check manually to check error and show
            if (!ModelState.IsValid)
            {
                return  new UnprocessableEntityObjectResult(ModelState);
            }

            //Map the applied changes on the DTO back into the entity
            _mapper.Map(department, departmentFromRepo);

            //Update and Save
            _departmentRepository.UpdateDepartment(departmentFromRepo);
            await _departmentRepository.SaveChangesAsync();

            //return the department
            return Ok(_mapper.Map<DepartmentDto>(departmentFromRepo));
        }
    }
}
