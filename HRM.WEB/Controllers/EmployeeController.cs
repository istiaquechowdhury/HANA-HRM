using HRM.WEB.ChildEntitiesDTO;
using HRM.WEB.Data;
using HRM.WEB.DTO;
using HRM.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM.WEB.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController(AppDbContext _appDbContext) : ControllerBase
    {




        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetAllEmployees([FromQuery] int IdClient, CancellationToken cancellationToken)
        {
            var employees = await _appDbContext.Employees
                .AsNoTracking()
                .Where(e => e.IdClient == IdClient && e.IsActive == true)
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
                    EmployeeImageBase64 = ConvertImageToBase64(e.EmployeeImage),


                    EmployeeDocuments = e.EmployeeDocuments.Select(doc => new EmployeeDocumentDTO
                    {
                        DocumentName = doc.DocumentName,
                        FileName = doc.FileName,
                        UploadedFileExtention = doc.UploadedFileExtention,
                        UploadedFileBase64 = ConvertFileToBase64(doc.UploadedFile, doc.UploadedFileExtention),

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
                    }).ToList(),



                    EmployeefamilyInfos = e.EmployeeFamilyInfos.Select(family => new EmployeeFamilyInfoDTO
                    {
                        Name = family.Name, 
                        IdGender = family.IdGender, 
                        IdRelationship = family.IdRelationship, 

                    }).ToList(),    
                })
                .ToListAsync(cancellationToken);

            return Ok(employees);
        }





        [HttpGet("detail")]
        public async Task<ActionResult<GetEmployeeDTO>> GetEmployeeById([FromQuery] int IdClient, [FromQuery] int id,  CancellationToken cancellationToken)
        {
            var employee = await _appDbContext.Employees
                .AsNoTracking()
                .Where(e => e.IdClient == IdClient && e.Id == id)
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
                    EmployeeImageBase64 = ConvertImageToBase64(e.EmployeeImage),





                    EmployeeDocuments = e.EmployeeDocuments.Select(doc => new EmployeeDocumentDTO
                    {
                        DocumentName = doc.DocumentName,
                        FileName = doc.FileName,
                        UploadedFileExtention = doc.UploadedFileExtention,
                        UploadedFileBase64 = ConvertFileToBase64(doc.UploadedFile, doc.UploadedFileExtention),

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
                    ReportingManagerName = e.ReportingManager != null ? e.ReportingManager.EmployeeName : null,


                    EmployeefamilyInfos = e.EmployeeFamilyInfos.Select(family => new EmployeeFamilyInfoDTO
                    {
                        Name = family.Name,
                        IdGender = family.IdGender,
                        IdRelationship = family.IdRelationship,

                    }).ToList(),    


                   
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (employee == null)
                return NotFound("Employee not found.");

            return Ok(employee);
        }












        [HttpPost]

        public async Task<ActionResult<Employee>> CreateEmployee([FromForm] CreateEmployeeDTO createDto, CancellationToken cancellationToken)
        {

            const long maxFileSize = 10 * 1024 * 1024; 

            // Validate EmployeeImage size
            if (createDto.EmployeeImage != null && createDto.EmployeeImage.Length > maxFileSize)
            {
                return BadRequest("Employee image size cannot be greater than 10 MB.");
            }
            // Convert Employee image to byte[]
            byte[]? employeeImageBytes = null;
            if (createDto.EmployeeImage != null && createDto.EmployeeImage.Length > 0)
            {
                using var ms = new MemoryStream();
                await createDto.EmployeeImage.CopyToAsync(ms);
                employeeImageBytes = ms.ToArray();
            }

            // Convert document files to byte[]
            foreach (var doc in createDto.Documents)
            {
                if (doc.UploadedFile != null)
                {
                    if (doc.UploadedFile.Length > maxFileSize)
                    {
                        return BadRequest($"Document '{doc.FileName}' size cannot be greater than 10 MB.");
                    }
                    using var ms = new MemoryStream();
                    await doc.UploadedFile.CopyToAsync(ms);
                    doc.UploadedFileExtention = Path.GetExtension(doc.UploadedFile.FileName);
                    doc.FileName = Path.GetFileName(doc.UploadedFile.FileName);
                    doc.UploadDate = DateTime.Now;
                    doc.UploadedFileBytes = ms.ToArray();

                }
            }





            var employee = new Employee
            {
                EmployeeName = createDto.EmployeeName,
                EmployeeNameBangla = createDto.EmployeeNameBangla,
                EmployeeImage = employeeImageBytes,
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
                SetDate = DateTime.Now,
                IdClient = createDto.IdClient,

                EmployeeDocuments = createDto.Documents.Select(doc => new EmployeeDocument
                {
                    DocumentName = doc.DocumentName,
                    FileName = doc.FileName,
                    UploadedFileExtention = doc.UploadedFileExtention,
                    UploadedFile = doc.UploadedFileBytes,
                    SetDate = DateTime.Now,
                    CreatedBy = createDto.CreatedBy,
                    IdClient = doc.IdClient,
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
                    SetDate = DateTime.Now,
                    CreatedBy = createDto.CreatedBy,
                    IdClient = edu.IdClient,
                }).ToList(),

                EmployeeProfessionalCertifications = createDto.ProfessionalCertification.Select(cert => new EmployeeProfessionalCertification
                {
                    CertificationTitle = cert.CertificationTitle,
                    CertificationInstitute = cert.CertificationInstitute,
                    InstituteLocation = cert.InstituteLocation,
                    FromDate = cert.FromDate,
                    ToDate = cert.ToDate,
                    SetDate = DateTime.Now,
                    CreatedBy = createDto.CreatedBy,
                    IdClient = cert.IdClient,
                }).ToList(),


                EmployeeFamilyInfos = createDto.EmployeeFamilyInfos.Select(family => new EmployeeFamilyInfo
                {
                    Name = family.Name,
                    IdGender = family.IdGender,
                    IdRelationship = family.IdRelationship,

                }).ToList(),







            };




            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Ok(new { message = "Employee created successfully." });




        }


        [HttpPut]

        public async Task<int> UpdateEmployee([FromForm] UpdateEmployeeDto employee, CancellationToken cancellationToken)
        {
            if (employee == null)
                throw new Exception($"data not found: {nameof(employee)}");

            const long maxFileSize = 10 * 1024 * 1024;

            var idClient = employee.IdClient;
            var id = employee.Id;

            var existingEmployee = await _appDbContext.Employees
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .Include(e => e.EmployeeFamilyInfos)
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

            if (employee.EmployeeImage != null && employee.EmployeeImage.Length > 0)
            {

                if (employee.EmployeeImage.Length > maxFileSize)
                    throw new Exception("Employee image size cannot exceed 10 MB.");

                using var ms = new MemoryStream();
                await employee.EmployeeImage.CopyToAsync(ms, cancellationToken);
                existingEmployee.EmployeeImage = ms.ToArray();
            }


            //delete obsolete data

            var deletedEmployeeDocumentList = existingEmployee.EmployeeDocuments
                .Where(ed => ed.IdClient == idClient && !employee.Documents.Any(d => d.IdClient == ed.IdClient && d.Id == ed.Id))
                .ToList();

            if (deletedEmployeeDocumentList.Any())
            {
                _appDbContext.EmployeeDocuments.RemoveRange(deletedEmployeeDocumentList);
            }

            var deletedEmployeeEducationInfoList = existingEmployee.EmployeeEducationInfos
                .Where(eei => eei.IdClient == idClient && !employee.EducationInfos.Any(ei => ei.IdClient == eei.IdClient && ei.Id == eei.Id))
                .ToList();
            if (deletedEmployeeEducationInfoList.Any())
            {
                _appDbContext.EmployeeEducationInfos.RemoveRange(deletedEmployeeEducationInfoList);
            }

            var deletedCertificationList = existingEmployee.EmployeeProfessionalCertifications
                .Where(epc =>epc.IdClient == idClient && !employee.ProfessionalCertifications.Any(c => c.IdClient == epc.IdClient && c.Id == epc.Id))
                .ToList();

            if (deletedCertificationList.Any())
            {
                _appDbContext.EmployeeProfessionalCertifications.RemoveRange(deletedCertificationList);
            }

            var deletedfamilyInfoList = existingEmployee.EmployeeFamilyInfos
               .Where(epc => epc.IdClient == idClient && !employee.FamilyInfos.Any(c => c.IdClient == epc.IdClient && c.Id == epc.Id))
               .ToList();

            if (deletedfamilyInfoList.Any())
            {
                _appDbContext.EmployeeFamilyInfos.RemoveRange(deletedfamilyInfoList);
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
                    existingEntry.SetDate = DateTime.Now;

                    if (item.UploadedFile != null && item.UploadedFile.Length > 0)
                    {
                        if (item.UploadedFile.Length > maxFileSize)
                            throw new Exception($"Document '{item.FileName}' exceeds the 10 MB size limit."); // 🔽 Validation

                        using var ms = new MemoryStream();
                        await item.UploadedFile.CopyToAsync(ms, cancellationToken);
                        existingEntry.UploadedFile = ms.ToArray();
                    }
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
                        SetDate = DateTime.Now


                    };

                    if (item.UploadedFile != null && item.UploadedFile.Length > 0)
                    {
                        if (item.UploadedFile.Length > maxFileSize)
                            throw new Exception($"Document '{item.FileName}' exceeds the 10 MB size limit."); // 🔽 Validation

                        using var ms = new MemoryStream();
                        await item.UploadedFile.CopyToAsync(ms, cancellationToken);
                        newEmployeeDocument.UploadedFile = ms.ToArray();
                    }

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
                        SetDate = DateTime.Now
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

            foreach (var item in employee.FamilyInfos)
            {
                var existingEntry = existingEmployee.EmployeeFamilyInfos.FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id);
                if (existingEntry != null)
                {
                    existingEntry.Name = item.Name;
                    existingEntry.IdGender = item.IdGender;
                    existingEntry.IdRelationship = item.IdRelationship;
                    existingEntry.SetDate = DateTime.Now;


                }
                else
                {
                    var familyinfos = new EmployeeFamilyInfo 
                    {
                        IdClient = item.IdClient,
                        IdEmployee = existingEmployee.Id,
                        Name = item.Name,
                        IdGender = item.IdGender,
                        IdRelationship = item.IdRelationship,

                        SetDate = DateTime.Now
                    };
                    existingEmployee.EmployeeFamilyInfos.Add(familyinfos);
                }
            }








            var result = await _appDbContext.SaveChangesAsync(cancellationToken);

            return result;
        }







        [HttpDelete("{IdClient}/{id}")]
        public async Task<IActionResult> SoftDeleteEmployee([FromRoute] int IdClient, [FromRoute] int id, CancellationToken cancellationToken)
        {
            var employee = await _appDbContext.Employees
                .FirstOrDefaultAsync(e => e.IdClient == IdClient && e.Id == id);

            if (employee == null)
                return NotFound("Employee not found.");

            employee.IsActive = false;
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Ok(new { message = "Employee soft deleted (deactivated) successfully." });


        }


        private static string GetMimeType(string? extension)
        {
            return extension?.ToLower() switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".pdf" => "application/pdf",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls" => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".txt" => "text/plain",
                _ => "application/octet-stream" // fallback
            };
        }

        private static string? ConvertImageToBase64(byte[]? image)
        {
            return image != null
                ? $"data:image/jpeg;base64,{Convert.ToBase64String(image)}"
                : null;
        }



        private static string? ConvertFileToBase64(byte[]? fileBytes, string? fileExtension)
        {
            if (fileBytes == null || string.IsNullOrEmpty(fileExtension))
                return null;

            var mimeType = GetMimeType(fileExtension);
            return $"data:{mimeType};base64,{Convert.ToBase64String(fileBytes)}";
        }















    }
}
