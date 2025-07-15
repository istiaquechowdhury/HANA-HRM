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
        public async Task<ActionResult<IEnumerable<EmployeeDropdownDto>>> GetReportingManagers()
        {
            var managers = await _appDbContext.Employees
                .Where(e => e.IdClient == 10001001 && e.IsActive == true)
                .Select(e => new EmployeeDropdownDto
                {
                    Id = e.Id,
                    EmployeeName = e.EmployeeName ?? ""
                })
                .ToListAsync();

            return Ok(managers);
        }


        [HttpGet("job-types")]
        public async Task<ActionResult<IEnumerable<JobTypeDropdownDto>>> GetJobTypes()
        {
            var jobTypes = await _appDbContext.JobTypes
                .Where(j => j.IdClient == 10001001)
                .Select(j => new JobTypeDropdownDto
                {
                    Id = j.Id,
                    JobTypeName = j.JobTypeName
                })
                .ToListAsync();

            return Ok(jobTypes);
        }




        [HttpGet("employee-types")]
        public async Task<ActionResult<IEnumerable<EmployeeTypeDropdownDto>>> GetEmployeeTypes()
        {
            var types = await _appDbContext.EmployeeTypes
                .Where(t => t.IdClient == 10001001)
                .Select(t => new EmployeeTypeDropdownDto
                {
                    Id = t.Id,
                    TypeName = t.TypeName ?? ""
                })
                .ToListAsync();

            return Ok(types);
        }


        [HttpGet("genders")]
        public async Task<ActionResult<IEnumerable<GenderDropdownDto>>> GetGenders()
        {
            var genders = await _appDbContext.Genders
                .Where(g => g.IdClient == 10001001)
                .Select(g => new GenderDropdownDto
                {
                    Id = g.Id,
                    GenderName = g.GenderName ?? ""
                })
                .ToListAsync();

            return Ok(genders);
        }




        [HttpGet("religions")]
        public async Task<ActionResult<IEnumerable<ReligionDropdownDto>>> GetReligions()
        {
            var religions = await _appDbContext.Religions
                .Where(r => r.IdClient == 10001001)
                .Select(r => new ReligionDropdownDto
                {
                    Id = r.Id,
                    ReligionName = r.ReligionName
                })
                .ToListAsync();

            return Ok(religions);
        }



        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<DepartmentDropdownDto>>> GetDepartments()
        {
            var departments = await _appDbContext.Departments
                .Where(d => d.IdClient == 10001001)
                .Select(d => new DepartmentDropdownDto
                {
                    Id = d.Id,
                    DepartName = d.DepartName
                })
                .ToListAsync();

            return Ok(departments);
        }




        [HttpGet("sections")]
        public async Task<ActionResult<IEnumerable<SectionDropdownDto>>> GetSections()
        {
            var sections = await _appDbContext.Sections
                .Where(s => s.IdClient == 10001001)
                .Select(s => new SectionDropdownDto
                {
                    Id = s.Id,
                    SectionName = s.SectionName
                })
                .ToListAsync();

            return Ok(sections);
        }


        [HttpGet("designations")]
        public async Task<ActionResult<IEnumerable<DesignationDropdownDto>>> GetDesignations()
        {
            var designations = await _appDbContext.Designations
                .Where(d => d.IdClient == 10001001 && (d.IsActive == true || d.IsActive == null))
                .Select(d => new DesignationDropdownDto
                {
                    Id = d.Id,
                    DesignationName = d.DesignationName
                })
                .ToListAsync();

            return Ok(designations);
        }



        [HttpGet("weekoffs")]
        public async Task<ActionResult<IEnumerable<WeekOffDropdownDto>>> GetWeekOffs()
        {
            var weekOffs = await _appDbContext.WeekOffs
                .Where(w => w.IdClient == 10001001)
                .Select(w => new WeekOffDropdownDto
                {
                    Id = w.Id,
                    WeekOffDay = w.WeekOffDay ?? ""
                })
                .ToListAsync();

            return Ok(weekOffs);
        }




        [HttpGet("marital-statuses")]
        public async Task<ActionResult<IEnumerable<MaritalStatusDropdownDto>>> GetMaritalStatuses()
        {
            var statuses = await _appDbContext.MaritalStatuses
                .Where(m => m.IdClient == 10001001)
                .Select(m => new MaritalStatusDropdownDto
                {
                    Id = m.Id,
                    MaritalStatusName = m.MaritalStatusName
                })
                .ToListAsync();

            return Ok(statuses);
        }








    }
}
