﻿using HRM.WEB.ChildEntitiesDTO;

namespace HRM.WEB.DTO
{
    public class GetEmployeeDTO
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeNameBangla { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? ContactNo { get; set; }
        public string? NationalIdentificationNumber { get; set; }
        public string? Address { get; set; }
        public string? PresentAddress { get; set; }
        public bool? HasOvertime { get; set; }
        public bool? HasAttendenceBonus { get; set; }
        public bool? IsActive { get; set; }

        public string? EmployeeImageExtension { get; set; }

        // Foreign key lookups
        public int IdDepartment { get; set; }
        public string? DepartmentName { get; set; }

        public int IdSection { get; set; }
        public string? SectionName { get; set; }
       

        public int? IdDesignation { get; set; }
        public string? DesignationName { get; set; }

        public int? IdEmployeeType { get; set; }
        public string? EmployeeTypeName { get; set; }

        public int? IdJobType { get; set; }
        public string? JobTypeName { get; set; }

        public int? IdGender { get; set; }
        public string? GenderName { get; set; }

        public int? IdReligion { get; set; }
        public string? ReligionName { get; set; }

        public int? IdMaritalStatus { get; set; }
        public string? MaritalStatusName { get; set; }

        public int? IdWeekOff { get; set; }
        public string? WeekOffDay { get; set; }

        public int? IdReportingManager { get; set; }
        public string? ReportingManagerName { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? SetDate { get; set; }

        public string? EmployeeImageBase64 { get; set; }



        public List<EmployeeDocumentDTO> EmployeeDocuments { get; set; } = new();
        public List<EmployeeEducationInfosDTO> EmployeeEducationInfos { get; set; } = new();
        public List<EmployeeProfessionalCertificationDTO> EmployeeProfessionalCertifications { get; set; } = new();

        public List<EmployeeFamilyInfoDTO> EmployeefamilyInfos { get; set; } = new();

    }
}
