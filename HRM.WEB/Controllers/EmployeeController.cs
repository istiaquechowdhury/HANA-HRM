using HRM.WEB.Data;
using HRM.WEB.DTO;
using HRM.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;
        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetAllEmployees()
        {
            var employees = await _appDbContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Section)
                .Include(e => e.Designation)
                .Include(e => e.EmployeeType)
                .Include(e => e.JobType)
                .Include(e => e.Gender)
                .Include(e => e.Religion)
                .Include(e => e.MaritalStatus)
                .Include(e => e.WeekOff)
                .Where(e => e.IdClient == 10001001)
                .Select(e => new GetEmployeeDTO
                {
                    Id = e.Id,
                    EmployeeName = e.EmployeeName,
                    EmployeeNameBangla = e.EmployeeNameBangla,
                    FatherName = e.FatherName,
                    MotherName = e.MotherName,
                    BirthDate = e.BirthDate,
                    JoiningDate = e.JoiningDate,
                    ContactNo = e.ContactNo,
                    NationalIdentificationNumber = e.NationalIdentificationNumber,
                    Address = e.Address,
                    PresentAddress = e.PresentAddress,
                    HasOvertime = e.HasOvertime,
                    HasAttendenceBonus = e.HasAttendenceBonus,
                    IsActive = e.IsActive,
                    IdDepartment = e.IdDepartment,
                    DepartmentName = e.Department.DepartName,
                    IdSection = e.IdSection,
                    SectionName = e.Section.SectionName,
                    IdDesignation = e.IdDesignation,
                    DesignationName = e.Designation != null ? e.Designation.DesignationName : null,
                    IdEmployeeType = e.IdEmployeeType,
                    EmployeeTypeName = e.EmployeeType != null ? e.EmployeeType.TypeName : null,
                    IdJobType = e.IdJobType,
                    JobTypeName = e.JobType != null ? e.JobType.JobTypeName : null,
                    IdGender = e.IdGender,
                    GenderName = e.Gender != null ? e.Gender.GenderName : null,
                    IdReligion = e.IdReligion,
                    ReligionName = e.Religion != null ? e.Religion.ReligionName : null,
                    IdMaritalStatus = e.IdMaritalStatus,
                    MaritalStatusName = e.MaritalStatus != null ? e.MaritalStatus.MaritalStatusName : null,
                    IdWeekOff = e.IdWeekOff,
                    WeekOffDay = e.WeekOff != null ? e.WeekOff.WeekOffDay : null,
                    IdReportingManager = e.IdReportingManager,
                    ReportingManagerName = _appDbContext.Employees
                        .Where(m => m.Id == e.IdReportingManager && m.IdClient == e.IdClient)
                        .Select(m => m.EmployeeName)
                        .FirstOrDefault(),
                    CreatedBy = e.CreatedBy,
                    SetDate = e.SetDate,
                    EmployeeImage = e.EmployeeImage
                })
                .ToListAsync();

            return Ok(employees);
        }







        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _appDbContext.Employees
                .Where(e => e.IdClient == 10001001 && e.Id == id)
                .Select(e => new GetEmployeeDTO
                {
                    Id = e.Id,
                    EmployeeName = e.EmployeeName,
                    EmployeeNameBangla = e.EmployeeNameBangla,
                    FatherName = e.FatherName,
                    MotherName = e.MotherName,
                    IdReportingManager = e.IdReportingManager,
                    IdJobType = e.IdJobType,
                    IdEmployeeType = e.IdEmployeeType,
                    BirthDate = e.BirthDate,
                    JoiningDate = e.JoiningDate,
                    IdGender = e.IdGender,
                    IdReligion = e.IdReligion,
                    IdDepartment = e.IdDepartment,
                    IdSection = e.IdSection,
                    IdDesignation = e.IdDesignation,
                    HasOvertime = e.HasOvertime,
                    HasAttendenceBonus = e.HasAttendenceBonus,
                    IdWeekOff = e.IdWeekOff,
                    Address = e.Address,
                    PresentAddress = e.PresentAddress,
                    NationalIdentificationNumber = e.NationalIdentificationNumber,
                    ContactNo = e.ContactNo,
                    IdMaritalStatus = e.IdMaritalStatus,
                    IsActive = e.IsActive,
                    CreatedBy = e.CreatedBy,
                    SetDate = e.SetDate
                })
                .FirstOrDefaultAsync();

            if (employee == null)
                return NotFound("Employee not found.");

            return Ok(employee);
        }












        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDTO createDto)
        {

            var employee = new Employee
            {
                EmployeeName = createDto.EmployeeName,
                EmployeeNameBangla = createDto.EmployeeNameBangla,
                EmployeeImage = createDto.EmployeeImage,
                FatherName = createDto.FatherName,
                MotherName = createDto.MotherName,
                IdReportingManager = createDto.IdReportingManager,
                IdJobType = createDto.IdJobType,
                IdEmployeeType = createDto.IdEmployeeType,
                BirthDate = createDto.BirthDate,
                JoiningDate = createDto.JoiningDate,
                IdGender = createDto.IdGender,
                IdReligion = createDto.IdReligion,
                IdDepartment = createDto.IdDepartment,
                IdSection = createDto.IdSection,
                IdDesignation = createDto.IdDesignation,
                HasOvertime = createDto.HasOvertime ?? false,
                HasAttendenceBonus = createDto.HasAttendenceBonus ?? false,
                IdWeekOff = createDto.IdWeekOff,
                Address = createDto.Address,
                PresentAddress = createDto.PresentAddress,
                NationalIdentificationNumber = createDto.NationalIdentificationNumber,
                ContactNo = createDto.ContactNo,
                IdMaritalStatus = createDto.IdMaritalStatus,
                IsActive = createDto.IsActive ?? true,
                CreatedBy = createDto.CreatedBy,
                SetDate = DateTime.UtcNow,
                IdClient = 10001001,
                EmployeeDocuments = new List<EmployeeDocument>
                {
                    new EmployeeDocument
                    {
                            DocumentName = "whatever",
                            FileName = "file.pdf",
                            UploadDate = DateTime.UtcNow,
                            UploadedFileExtention = ".pdf",
                            UploadedFile = Convert.FromBase64String("U29tZSBmaWxlIGNvbnRlbnQ="), // optional
                            SetDate = DateTime.UtcNow,
                            CreatedBy = createDto.CreatedBy,
                            IdClient = 10001001
                    },

                    new EmployeeDocument
                    {
                        DocumentName = "testingphase",
                        FileName = "testing.pdf",
                        UploadDate = DateTime.Now,
                        UploadedFileExtention = ".pdf",
                        UploadedFile = Convert.FromBase64String("U29tZSBmaWxlIGNvbnRlbnQ="), // optional
                        SetDate = DateTime.UtcNow,
                        CreatedBy = createDto.CreatedBy,
                        IdClient = 10001001
                    }
                },

                EmployeeEducationInfos = new List<EmployeeEducationInfo>
                {
                    new EmployeeEducationInfo
                    {
                        IdEducationLevel = 1,
                        IdEducationExamination = 2,
                        IdEducationResult = 3,
                        Cgpa = 3.75m,
                        ExamScale = 4.00m,
                        Marks = null,
                        Major = "Computer Science",
                        PassingYear = 2018,
                        InstituteName = "University of Dhaka",
                        IsForeignInstitute = false,
                        Duration = 4,
                        Achievement = "Dean's List",
                        CreatedBy = createDto.CreatedBy,
                        SetDate = DateTime.UtcNow,
                        IdClient = 10001001
                    },
                    new EmployeeEducationInfo
                    {
                        IdEducationLevel = 2,
                        IdEducationExamination = 3,
                        IdEducationResult = 4,
                        Cgpa = 3.75m,
                        ExamScale = 4.00m,
                        Marks = null,
                        Major = "Software Engineering",
                        PassingYear = 2018,
                        InstituteName = "Daffodil International University",
                        IsForeignInstitute = false,
                        Duration = 4,
                        Achievement = "Dean's List",
                        CreatedBy = createDto.CreatedBy,
                        SetDate = DateTime.UtcNow,
                        IdClient = 10001001
                    }


                },

                EmployeeProfessionalCertifications = new List<EmployeeProfessionalCertification>
                {
                    new EmployeeProfessionalCertification
                    {
                        CertificationTitle = "PMP",
                        CertificationInstitute = "PMI",
                        InstituteLocation = "USA",
                        FromDate = new DateTime(2020, 1, 1),
                        ToDate = new DateTime(2023, 1, 1),
                        SetDate = DateTime.UtcNow,
                        CreatedBy = createDto.CreatedBy,
                        IdClient = 10001001
                    },

                     new EmployeeProfessionalCertification
                    {
                        CertificationTitle = "mp",
                        CertificationInstitute = "npm",
                        InstituteLocation = "UK",
                        FromDate = new DateTime(2020, 1, 1),
                        ToDate = new DateTime(2023, 1, 1),
                        SetDate = DateTime.UtcNow,
                        CreatedBy = createDto.CreatedBy,
                        IdClient = 10001001
                    }
                },





            };

            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();

            return Ok(new { message = "Employee created successfully.", id = employee.Id });




        }







        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest("ID in URL and payload do not match.");

            var employee = await _appDbContext.Employees
                .FirstOrDefaultAsync(e => e.IdClient == 10001001 && e.Id == id);

            if (employee == null)
                return NotFound("Employee not found.");

            // Map fields from updateDto to entity
            employee.EmployeeName = updateDto.EmployeeName;
            employee.EmployeeNameBangla = updateDto.EmployeeNameBangla;
            employee.EmployeeImage = updateDto.EmployeeImage;
            employee.FatherName = updateDto.FatherName;
            employee.MotherName = updateDto.MotherName;
            employee.IdReportingManager = updateDto.IdReportingManager;
            employee.IdJobType = updateDto.IdJobType;
            employee.IdEmployeeType = updateDto.IdEmployeeType;
            employee.BirthDate = updateDto.BirthDate;
            employee.JoiningDate = updateDto.JoiningDate;
            employee.IdGender = updateDto.IdGender;
            employee.IdReligion = updateDto.IdReligion;
            employee.IdDepartment = updateDto.IdDepartment;
            employee.IdSection = updateDto.IdSection;
            employee.IdDesignation = updateDto.IdDesignation;
            employee.HasOvertime = updateDto.HasOvertime ?? false;
            employee.HasAttendenceBonus = updateDto.HasAttendenceBonus ?? false;
            employee.IdWeekOff = updateDto.IdWeekOff;
            employee.Address = updateDto.Address;
            employee.PresentAddress = updateDto.PresentAddress;
            employee.NationalIdentificationNumber = updateDto.NationalIdentificationNumber;
            employee.ContactNo = updateDto.ContactNo;
            employee.IdMaritalStatus = updateDto.IdMaritalStatus;
            employee.IsActive = updateDto.IsActive ?? true;
            employee.CreatedBy = updateDto.CreatedBy;
            employee.SetDate = DateTime.UtcNow;

            _appDbContext.Employees.Update(employee);
            await _appDbContext.SaveChangesAsync();

            return Ok(new { message = "Employee updated successfully." });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteEmployee(int id)
        {
            var employee = await _appDbContext.Employees
                .FirstOrDefaultAsync(e => e.IdClient == 10001001 && e.Id == id);

            if (employee == null)
                return NotFound("Employee not found.");

            employee.IsActive = false;
            await _appDbContext.SaveChangesAsync();

            return Ok(new { message = "Employee soft deleted (deactivated) successfully." });
        }








    }
}
