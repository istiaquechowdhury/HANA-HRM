using HRM.WEB.BaseEntitiesDTO;
using HRM.WEB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM.WEB.Controllers
{
    [Route("api/dropdowns")]
    [ApiController]
    public class BaseEntitiesController(AppDbContext appDbContext) : ControllerBase
    {

       


        [HttpGet("reportingmanagersdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetReportingManagers([FromQuery] int IdClient)
        {
            var managers = await appDbContext.Employees
                .Where(e => e.IdClient == IdClient && e.IsActive == true)
                .Select(e => new BaseDropdownDto
                {
                    Id = e.Id,
                    Text = e.EmployeeName ?? ""
                })
                .ToListAsync();

            return Ok(managers);
        }


        [HttpGet("jobtypesdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetJobTypes([FromQuery] int IdClient)
        {
            var jobTypes = await appDbContext.JobTypes
                .Where(j => j.IdClient == IdClient)
                .Select(j => new BaseDropdownDto
                {
                    Id = j.Id,
                    Text = j.JobTypeName
                })
                .ToListAsync();

            return Ok(jobTypes);
        }




        [HttpGet("employeetypesdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetEmployeeTypes([FromQuery] int IdClient)
        {
            var types = await appDbContext.EmployeeTypes
                .Where(t => t.IdClient == IdClient)
                .Select(t => new BaseDropdownDto
                {
                    Id = t.Id,
                    Text = t.TypeName ?? ""
                })
                .ToListAsync();

            return Ok(types);
        }


        [HttpGet("gendersdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetGenders([FromQuery] int IdClient)
        {
            var genders = await appDbContext.Genders
                .Where(g => g.IdClient == IdClient)
                .Select(g => new BaseDropdownDto
                {
                    Id = g.Id,
                    Text = g.GenderName ?? ""
                })
                .ToListAsync();

            return Ok(genders);
        }




        [HttpGet("religionsdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetReligions([FromQuery] int IdClient)
        {
            var religions = await appDbContext.Religions
                .Where(r => r.IdClient == IdClient)
                .Select(r => new BaseDropdownDto
                {
                    Id = r.Id,
                    Text = r.ReligionName
                })
                .ToListAsync();

            return Ok(religions);
        }



        [HttpGet("departmentsdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetDepartments([FromQuery] int IdClient)
        {
            var departments = await appDbContext.Departments
                .Where(d => d.IdClient == IdClient)
                .Select(d => new BaseDropdownDto
                {
                    Id = d.Id,
                    Text = d.DepartName
                })
                .ToListAsync();

            return Ok(departments);
        }




        [HttpGet("sectionsdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetSections([FromQuery] int IdClient)
        {
            var sections = await appDbContext.Sections
                .Where(s => s.IdClient == IdClient)
                .Select(s => new BaseDropdownDto
                {
                    Id = s.Id,
                    Text = s.SectionName
                })
                .ToListAsync();

            return Ok(sections);
        }


        [HttpGet("designationsdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetDesignations([FromQuery] int IdClient)
        {
            var designations = await appDbContext.Designations
                .Where(d => d.IdClient == IdClient && (d.IsActive == true || d.IsActive == null))
                .Select(d => new BaseDropdownDto
                {
                    Id = d.Id,
                    Text = d.DesignationName
                })
                .ToListAsync();

            return Ok(designations);
        }



        [HttpGet("weekoffsdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetWeekOffs([FromQuery] int IdClient)
        {
            var weekOffs = await appDbContext.WeekOffs
                .Where(w => w.IdClient == IdClient)
                .Select(w => new BaseDropdownDto
                {
                    Id = w.Id,
                    Text = w.WeekOffDay ?? ""
                })
                .ToListAsync();

            return Ok(weekOffs);
        }




        [HttpGet("maritalstatusesdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetMaritalStatuses([FromQuery] int IdClient)
        {
            var statuses = await appDbContext.MaritalStatuses
                .Where(m => m.IdClient == IdClient)
                .Select(m => new BaseDropdownDto
                {
                    Id = m.Id,
                    Text = m.MaritalStatusName
                })
                .ToListAsync();

            return Ok(statuses);
        }



        [HttpGet("relationshipsdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetRelationships([FromQuery] int IdClient)
        {
            var relationships = await appDbContext.Relationships
                .Where(m => m.IdClient == IdClient)
                .Select(m => new BaseDropdownDto
                {
                    Id = m.Id,
                    Text = m.RelationName
                })
                .ToListAsync();

            return Ok(relationships);
        }




        [HttpGet("educationleveldropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetEducationLevels([FromQuery] int IdClient)
        {
            var educationlevels = await appDbContext.EducationLevels
                .Where(m => m.IdClient == IdClient)
                .Select(m => new BaseDropdownDto
                {
                    Id = m.Id,
                    Text = m.EducationLevelName
                })
                .ToListAsync();

            return Ok(educationlevels);
        }


        [HttpGet("educationexaminationdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetEducationExaminations([FromQuery] int IdClient)
        {
            var educationexaminations = await appDbContext.EducationExaminations
                .Where(m => m.IdClient == IdClient)
                .Select(m => new BaseDropdownDto
                {
                    Id = m.Id,
                    Text = m.ExamName
                })
                .ToListAsync();

            return Ok(educationexaminations);
        }




        [HttpGet("educationresultdropdown")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GerEducationResults([FromQuery] int IdClient)
        {
            var educationresults = await appDbContext.EducationResults
                .Where(m => m.IdClient == IdClient)
                .Select(m => new BaseDropdownDto
                {
                    Id = m.Id,
                    Text = m.ResultName
                })
                .ToListAsync();

            return Ok(educationresults);
        }











    }
}
