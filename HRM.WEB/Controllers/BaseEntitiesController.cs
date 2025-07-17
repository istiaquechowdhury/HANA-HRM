using HRM.WEB.BaseEntitiesDTO;
using HRM.WEB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntitiesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BaseEntitiesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet("reporting-managers")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetReportingManagers()
        {
            var managers = await _appDbContext.Employees
                .Where(e => e.IdClient == 10001001 && e.IsActive == true)
                .Select(e => new BaseDropdownDto
                {
                    Id = e.Id,
                    Name = e.EmployeeName ?? ""
                })
                .ToListAsync();

            return Ok(managers);
        }


        [HttpGet("job-types")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetJobTypes()
        {
            var jobTypes = await _appDbContext.JobTypes
                .Where(j => j.IdClient == 10001001)
                .Select(j => new BaseDropdownDto
                {
                    Id = j.Id,
                    Name = j.JobTypeName
                })
                .ToListAsync();

            return Ok(jobTypes);
        }




        [HttpGet("employee-types")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetEmployeeTypes()
        {
            var types = await _appDbContext.EmployeeTypes
                .Where(t => t.IdClient == 10001001)
                .Select(t => new BaseDropdownDto
                {
                    Id = t.Id,
                    Name = t.TypeName ?? ""
                })
                .ToListAsync();

            return Ok(types);
        }


        [HttpGet("genders")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetGenders()
        {
            var genders = await _appDbContext.Genders
                .Where(g => g.IdClient == 10001001)
                .Select(g => new BaseDropdownDto
                {
                    Id = g.Id,
                    Name = g.GenderName ?? ""
                })
                .ToListAsync();

            return Ok(genders);
        }




        [HttpGet("religions")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetReligions()
        {
            var religions = await _appDbContext.Religions
                .Where(r => r.IdClient == 10001001)
                .Select(r => new BaseDropdownDto
                {
                    Id = r.Id,
                    Name = r.ReligionName
                })
                .ToListAsync();

            return Ok(religions);
        }



        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetDepartments()
        {
            var departments = await _appDbContext.Departments
                .Where(d => d.IdClient == 10001001)
                .Select(d => new BaseDropdownDto
                {
                    Id = d.Id,
                    Name = d.DepartName
                })
                .ToListAsync();

            return Ok(departments);
        }




        [HttpGet("sections")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetSections()
        {
            var sections = await _appDbContext.Sections
                .Where(s => s.IdClient == 10001001)
                .Select(s => new BaseDropdownDto
                {
                    Id = s.Id,
                    Name = s.SectionName
                })
                .ToListAsync();

            return Ok(sections);
        }


        [HttpGet("designations")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetDesignations()
        {
            var designations = await _appDbContext.Designations
                .Where(d => d.IdClient == 10001001 && (d.IsActive == true || d.IsActive == null))
                .Select(d => new BaseDropdownDto
                {
                    Id = d.Id,
                    Name = d.DesignationName
                })
                .ToListAsync();

            return Ok(designations);
        }



        [HttpGet("weekoffs")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetWeekOffs()
        {
            var weekOffs = await _appDbContext.WeekOffs
                .Where(w => w.IdClient == 10001001)
                .Select(w => new BaseDropdownDto
                {
                    Id = w.Id,
                    Name = w.WeekOffDay ?? ""
                })
                .ToListAsync();

            return Ok(weekOffs);
        }




        [HttpGet("marital-statuses")]
        public async Task<ActionResult<IEnumerable<BaseDropdownDto>>> GetMaritalStatuses()
        {
            var statuses = await _appDbContext.MaritalStatuses
                .Where(m => m.IdClient == 10001001)
                .Select(m => new BaseDropdownDto
                {
                    Id = m.Id,
                    Name = m.MaritalStatusName
                })
                .ToListAsync();

            return Ok(statuses);
        }








    }
}
