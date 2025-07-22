using HRM.WEB.ChildEntitiesDTO;
using HRM.WEB.Data;
using HRM.WEB.DTO;
using HRM.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM.WEB.Controllers
{
    [Route("api/Employee")]
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
                .AsNoTracking()
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
                    ReportingManagerName = e.ReportingManager != null ? e.ReportingManager.EmployeeName : null,

                    CreatedBy = e.CreatedBy,
                    SetDate = e.SetDate,
                    EmployeeImage = e.EmployeeImage,

                    EmployeeDocuments = e.EmployeeDocuments.Select(doc => new EmployeeDocumentDTO
                    {
                        DocumentName = doc.DocumentName,
                        FileName = doc.FileName,
                        UploadedFileExtention = doc.UploadedFileExtention,
                    }).ToList(),

                    EmployeeEducationInfos = e.EmployeeEducationInfos.Select(edu => new EmployeeEducationInfosDTO
                    {
                        IdEducationLevel = edu.IdEducationLevel,
                        IdEducationExamination = edu.IdEducationExamination,
                        IdEducationResult = edu.IdEducationResult,
                        Cgpa = edu.Cgpa,
                        ExamScale = edu.ExamScale,
                        Marks = edu.Marks,
                        Major = edu.Major,
                        PassingYear = edu.PassingYear,
                        InstituteName = edu.InstituteName,
                        IsForeignInstitute = edu.IsForeignInstitute,
                        Duration = edu.Duration,
                        Achievement = edu.Achievement
                    }).ToList(),

                    EmployeeProfessionalCertifications = e.EmployeeProfessionalCertifications.Select(cert => new EmployeeProfessionalCertificationDTO
                    {
                        CertificationTitle = cert.CertificationTitle,
                        CertificationInstitute = cert.CertificationInstitute,
                        InstituteLocation = cert.InstituteLocation,
                        FromDate = cert.FromDate,
                        ToDate = cert.ToDate
                    }).ToList()
                })
                .ToListAsync();

            return Ok(employees);
        }





        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _appDbContext.Employees
                .AsNoTracking()
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
                    SetDate = e.SetDate,
                    EmployeeImage = e.EmployeeImage,




                    EmployeeDocuments = e.EmployeeDocuments.Select(doc => new EmployeeDocumentDTO
                    {
                        DocumentName = doc.DocumentName,
                        FileName = doc.FileName,
                        UploadedFileExtention = doc.UploadedFileExtention
                    }).ToList(),

                    // Related Education Info
                    EmployeeEducationInfos = e.EmployeeEducationInfos.Select(edu => new EmployeeEducationInfosDTO
                    {
                        IdEducationLevel = edu.IdEducationLevel,
                        IdEducationExamination = edu.IdEducationExamination,
                        IdEducationResult = edu.IdEducationResult,
                        Cgpa = edu.Cgpa,
                        ExamScale = edu.ExamScale,
                        Marks = edu.Marks,
                        Major = edu.Major,
                        PassingYear = edu.PassingYear,
                        InstituteName = edu.InstituteName,
                        IsForeignInstitute = edu.IsForeignInstitute,
                        Duration = edu.Duration,
                        Achievement = edu.Achievement
                    }).ToList(),

                    // Related Certifications
                    EmployeeProfessionalCertifications = e.EmployeeProfessionalCertifications.Select(cert => new EmployeeProfessionalCertificationDTO
                    {
                        CertificationTitle = cert.CertificationTitle,
                        CertificationInstitute = cert.CertificationInstitute,
                        InstituteLocation = cert.InstituteLocation,
                        FromDate = cert.FromDate,
                        ToDate = cert.ToDate
                    }).ToList(),

                    // Reporting Manager Name from self-reference
                    ReportingManagerName = e.ReportingManager != null ? e.ReportingManager.EmployeeName : null
                })
                .FirstOrDefaultAsync();

            if (employee == null)
                return NotFound("Employee not found.");

            return Ok(employee);
        }












        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDTO createDto)
        {
            //byte[] imageBytes = null;
            //if (createDto.EmployeeImage != null && createDto.EmployeeImage.Length > 0)
            //{
            //    using var ms = new MemoryStream();
            //    await createDto.EmployeeImage.CopyToAsync(ms);
            //    imageBytes = ms.ToArray();
            //}


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

                EmployeeDocuments = createDto.Documents.Select(doc => new EmployeeDocument
                {
                    DocumentName = doc.DocumentName,
                    FileName = doc.FileName,
                    UploadedFileExtention = doc.UploadedFileExtention,
                    UploadedFile = doc.UploadedFile,
                    SetDate = DateTime.UtcNow,
                    CreatedBy = createDto.CreatedBy,
                    IdClient = 10001001
                }).ToList(),



                EmployeeEducationInfos = createDto.EducationInfos.Select(edu => new EmployeeEducationInfo
                {
                    IdEducationLevel = edu.IdEducationLevel,
                    IdEducationExamination = edu.IdEducationExamination,
                    IdEducationResult = edu.IdEducationResult,
                    Cgpa = edu.Cgpa,
                    ExamScale = edu.ExamScale,
                    Marks = edu.Marks,
                    Major = edu.Major,
                    PassingYear = edu.PassingYear,
                    InstituteName = edu.InstituteName,
                    IsForeignInstitute = edu.IsForeignInstitute,
                    Duration = edu.Duration,
                    Achievement = edu.Achievement,
                    SetDate = DateTime.UtcNow,
                    CreatedBy = createDto.CreatedBy,
                    IdClient = 10001001
                }).ToList(),

                EmployeeProfessionalCertifications = createDto.ProfessionalCertification.Select(cert => new EmployeeProfessionalCertification
                {
                    CertificationTitle = cert.CertificationTitle,
                    CertificationInstitute = cert.CertificationInstitute,
                    InstituteLocation = cert.InstituteLocation,
                    FromDate = cert.FromDate,
                    ToDate = cert.ToDate,
                    SetDate = DateTime.UtcNow,
                    CreatedBy = createDto.CreatedBy,
                    IdClient = 10001001
                }).ToList()







            };




            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();

            return Ok(new { message = "Employee created successfully." });




        }


        [HttpPut]

        public async Task<int> UpdateAsync(UpdateEmployeeDto employee, CancellationToken cancellationToken)
        {
            if (employee == null)
                throw new Exception($"data not found: {nameof(employee)}");

            var idClient = employee.IdClient;
            var id = employee.Id;

            var existingEmployee = await _appDbContext.Employees
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .FirstOrDefaultAsync(e => e.IdClient == idClient && e.Id == id, cancellationToken);

            if (existingEmployee == null) return 0;

            existingEmployee.EmployeeName = employee.EmployeeName ?? existingEmployee.EmployeeName;
            existingEmployee.EmployeeNameBangla = employee.EmployeeNameBangla ?? existingEmployee.EmployeeNameBangla;
            existingEmployee.FatherName = employee.FatherName ?? existingEmployee.FatherName;
            existingEmployee.MotherName = employee.MotherName ?? existingEmployee.MotherName;
            existingEmployee.IdDepartment = employee.IdDepartment;
            existingEmployee.IdSection = employee.IdSection;
            existingEmployee.BirthDate = employee.BirthDate ?? existingEmployee.BirthDate;
            existingEmployee.Address = employee.Address ?? existingEmployee.Address;
            existingEmployee.PresentAddress = employee.PresentAddress ?? existingEmployee.PresentAddress;
            existingEmployee.NationalIdentificationNumber = employee.NationalIdentificationNumber ?? existingEmployee.NationalIdentificationNumber;
            existingEmployee.ContactNo = employee.ContactNo ?? existingEmployee.ContactNo;
            existingEmployee.IsActive = employee.IsActive ?? existingEmployee.IsActive;
            existingEmployee.SetDate = DateTime.Now;


            //delete obsolete data

            var deletedEmployeeDocumentList = existingEmployee.EmployeeDocuments
                .Where(ed => ed.IdClient == ed.IdClient && !employee.Documents.Any(d => d.IdClient == ed.IdClient && d.Id == ed.Id))
                .ToList();
            if (deletedEmployeeDocumentList != null)
            {
                _appDbContext.EmployeeDocuments.RemoveRange(deletedEmployeeDocumentList);
            }

            var deletedEmployeeEducationInfoList = existingEmployee.EmployeeEducationInfos
                .Where(eei => eei.IdClient == eei.IdClient && !employee.EducationInfos.Any(ei => ei.IdClient == eei.IdClient && ei.Id == eei.Id))
                .ToList();
            if (deletedEmployeeEducationInfoList != null)
            {
                _appDbContext.EmployeeEducationInfos.RemoveRange(deletedEmployeeEducationInfoList);
            }

            var deletedCertificationList = existingEmployee.EmployeeProfessionalCertifications
                .Where(epc => epc.IdClient == epc.IdClient && !employee.ProfessionalCertifications.Any(c => c.IdClient == epc.IdClient && c.Id == epc.Id))
                .ToList();

            if (deletedCertificationList != null)
            {
                _appDbContext.EmployeeProfessionalCertifications.RemoveRange(deletedCertificationList);
            }


            //up/insert information
            foreach (var item in employee.Documents)
            {
                var existingEntry = existingEmployee.EmployeeDocuments.FirstOrDefault(ed => ed.IdClient == item.IdClient && ed.Id == item.Id);
                if (existingEntry != null)
                {
                    existingEntry.DocumentName = item.DocumentName;
                    existingEntry.FileName = item.FileName;
                    existingEntry.UploadDate = item.UploadDate;
                    existingEntry.UploadedFileExtention = item.UploadedFileExtention;
                    existingEntry.SetDate = DateTime.UtcNow;
                }
                else
                {
                    var newEmployeeDocument = new EmployeeDocument()
                    {
                        IdClient = item.IdClient,
                        IdEmployee = existingEmployee.Id,
                        DocumentName = item.DocumentName,
                        FileName = item.FileName,
                        UploadDate = item.UploadDate,
                        UploadedFileExtention = item.UploadedFileExtention,
                        SetDate = DateTime.UtcNow
                    };

                    existingEmployee.EmployeeDocuments.Add(newEmployeeDocument);
                }
            }


            foreach (var item in employee.EducationInfos)
            {
                var existingEntry = existingEmployee.EmployeeEducationInfos.FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id);
                if (existingEntry != null)
                {
                    existingEntry.IdEducationLevel = item.IdEducationLevel;
                    existingEntry.IdEducationExamination = item.IdEducationExamination;
                    existingEntry.IdEducationResult = item.IdEducationResult;
                    existingEntry.Cgpa = item.Cgpa;
                    existingEntry.Marks = item.Marks;
                    existingEntry.PassingYear = item.PassingYear;
                    existingEntry.InstituteName = item.InstituteName;
                    existingEntry.Major = item.Major;
                    existingEntry.IsForeignInstitute = item.IsForeignInstitute;
                    existingEntry.Duration = item.Duration;
                    existingEntry.Achievement = item.Achievement;
                    existingEntry.SetDate = DateTime.Now;
                }
                else
                {
                    var newEmployeeEducationInfo = new EmployeeEducationInfo()
                    {
                        IdClient = item.IdClient,
                        IdEmployee = existingEmployee.Id,
                        IdEducationLevel = item.IdEducationLevel,
                        IdEducationExamination = item.IdEducationExamination,
                        IdEducationResult = item.IdEducationResult,
                        Cgpa = item.Cgpa,
                        Marks = item.Marks,
                        PassingYear = item.PassingYear,
                        InstituteName = item.InstituteName,
                        Major = item.Major,
                        IsForeignInstitute = item.IsForeignInstitute,
                        Duration = item.Duration,
                        Achievement = item.Achievement,
                        SetDate = DateTime.UtcNow
                    };

                    existingEmployee.EmployeeEducationInfos.Add(newEmployeeEducationInfo);
                }
            }


            foreach (var item in employee.ProfessionalCertifications)
            {
                var existingEntry = existingEmployee.EmployeeProfessionalCertifications.FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id);
                if (existingEntry != null)
                {
                    existingEntry.CertificationTitle = item.CertificationTitle;
                    existingEntry.CertificationInstitute = item.CertificationInstitute;
                    existingEntry.InstituteLocation = item.InstituteLocation;
                    existingEntry.FromDate = item.FromDate;
                    existingEntry.ToDate = item.ToDate;
                    existingEntry.SetDate = DateTime.Now;
                }
                else
                {
                    var newCertification = new EmployeeProfessionalCertification
                    {
                        IdClient = item.IdClient,
                        IdEmployee = existingEmployee.Id,
                        CertificationTitle = item.CertificationTitle,
                        CertificationInstitute = item.CertificationInstitute,
                        InstituteLocation = item.InstituteLocation,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate,
                        SetDate = DateTime.Now
                    };
                    existingEmployee.EmployeeProfessionalCertifications.Add(newCertification);
                }
            }

            var result = await _appDbContext.SaveChangesAsync();

            return result;
        }






        //[HttpPut]
        //public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateDto)
        //{
        //    var employee = await _appDbContext.Employees
        //        .Include(e => e.EmployeeDocuments)
        //        .Include(e => e.EmployeeEducationInfos)
        //        .Include(e => e.EmployeeProfessionalCertifications)
        //        .FirstOrDefaultAsync(e => e.Id == updateDto.Id && e.IdClient == 10001001);

        //    if (employee == null)
        //    {
        //        return NotFound("Employee not found.");
        //    }

        //    // Update basic properties
        //    employee.EmployeeName = updateDto.EmployeeName;
        //    employee.EmployeeNameBangla = updateDto.EmployeeNameBangla;
        //    employee.EmployeeImage = updateDto.EmployeeImage;
        //    employee.FatherName = updateDto.FatherName;
        //    employee.MotherName = updateDto.MotherName;
        //    employee.IdReportingManager = updateDto.IdReportingManager;
        //    employee.IdJobType = updateDto.IdJobType;
        //    employee.IdEmployeeType = updateDto.IdEmployeeType;
        //    employee.BirthDate = updateDto.BirthDate;
        //    employee.JoiningDate = updateDto.JoiningDate;
        //    employee.IdGender = updateDto.IdGender;
        //    employee.IdReligion = updateDto.IdReligion;
        //    employee.IdDepartment = updateDto.IdDepartment;
        //    employee.IdSection = updateDto.IdSection;
        //    employee.IdDesignation = updateDto.IdDesignation;
        //    employee.HasOvertime = updateDto.HasOvertime ?? false;
        //    employee.HasAttendenceBonus = updateDto.HasAttendenceBonus ?? false;
        //    employee.IdWeekOff = updateDto.IdWeekOff;
        //    employee.Address = updateDto.Address;
        //    employee.PresentAddress = updateDto.PresentAddress;
        //    employee.NationalIdentificationNumber = updateDto.NationalIdentificationNumber;
        //    employee.ContactNo = updateDto.ContactNo;
        //    employee.IdMaritalStatus = updateDto.IdMaritalStatus;
        //    employee.IsActive = updateDto.IsActive ?? true;
        //    employee.CreatedBy = updateDto.CreatedBy;
        //    employee.SetDate = DateTime.UtcNow;

        //    // Replace documents
        //    _appDbContext.EmployeeDocuments.RemoveRange(employee.EmployeeDocuments);
        //    employee.EmployeeDocuments = updateDto.Documents.Select(doc => new EmployeeDocument
        //    {
        //        DocumentName = doc.DocumentName,
        //        FileName = doc.FileName,
        //        UploadedFileExtention = doc.UploadedFileExtention,
        //        UploadedFile = doc.UploadedFile,
        //        CreatedBy = updateDto.CreatedBy,
        //        SetDate = DateTime.UtcNow,
        //        IdClient = 10001001
        //    }).ToList();

        //    // Replace education info
        //    _appDbContext.EmployeeEducationInfos.RemoveRange(employee.EmployeeEducationInfos);
        //    employee.EmployeeEducationInfos = updateDto.EducationInfos.Select(edu => new EmployeeEducationInfo
        //    {
        //        IdEducationLevel = edu.IdEducationLevel,
        //        IdEducationExamination = edu.IdEducationExamination,
        //        IdEducationResult = edu.IdEducationResult,
        //        Cgpa = edu.Cgpa,
        //        ExamScale = edu.ExamScale,
        //        Marks = edu.Marks,
        //        Major = edu.Major,
        //        PassingYear = edu.PassingYear,
        //        InstituteName = edu.InstituteName,
        //        IsForeignInstitute = edu.IsForeignInstitute,
        //        Duration = edu.Duration,
        //        Achievement = edu.Achievement,
        //        CreatedBy = updateDto.CreatedBy,
        //        SetDate = DateTime.UtcNow,
        //        IdClient = 10001001
        //    }).ToList();

        //    // Replace certifications
        //    _appDbContext.EmployeeProfessionalCertifications.RemoveRange(employee.EmployeeProfessionalCertifications);
        //    employee.EmployeeProfessionalCertifications = updateDto.ProfessionalCertifications.Select(cert => new EmployeeProfessionalCertification
        //    {
        //        CertificationTitle = cert.CertificationTitle,
        //        CertificationInstitute = cert.CertificationInstitute,
        //        InstituteLocation = cert.InstituteLocation,
        //        FromDate = cert.FromDate,
        //        ToDate = cert.ToDate,
        //        CreatedBy = updateDto.CreatedBy,
        //        SetDate = DateTime.UtcNow,
        //        IdClient = 10001001
        //    }).ToList();

        //    await _appDbContext.SaveChangesAsync();

        //    return Ok(new { message = "Employee updated successfully." });
        //}










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




        [HttpPost("UploadImage/{employeeId}")]
        public async Task<IActionResult> UploadImage(int employeeId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();

            var employee = await _appDbContext.Employees.FindAsync(10001001,employeeId);
            if (employee == null)
                return NotFound("Employee not found.");

            employee.EmployeeImage = imageBytes;
            await _appDbContext.SaveChangesAsync();

            return Ok("Image uploaded successfully.");
        }



        [HttpGet("GetImage/{employeeId}")]
        public async Task<IActionResult> GetImage(int employeeId)
        {
            var employee = await _appDbContext.Employees.FindAsync(10001001, employeeId);
            if (employee == null)
                return NotFound("Employee not found.");

            if (employee.EmployeeImage == null || employee.EmployeeImage.Length == 0)
                return NotFound("No image found for this employee.");

            // Hardcoded MIME type as PNG for now
            return File(employee.EmployeeImage, "image/jpg");
        }









    }
}
