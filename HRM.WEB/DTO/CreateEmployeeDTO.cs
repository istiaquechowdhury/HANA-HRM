﻿using HRM.WEB.ChildEntitiesDTO;

namespace HRM.WEB.DTO
{
    public class CreateEmployeeDTO
    {
       
        public int IdClient { get; set; }   
        public string? EmployeeName { get; set; }
        public string? EmployeeNameBangla { get; set; }
        public IFormFile? EmployeeImage { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public int? IdReportingManager { get; set; }
        public int? IdJobType { get; set; }
        public int? IdEmployeeType { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? IdGender { get; set; }
        public int? IdReligion { get; set; }
        public int IdDepartment { get; set; }
        public int IdSection { get; set; }
        public int? IdDesignation { get; set; }
        public bool? HasOvertime { get; set; }
        public bool? HasAttendenceBonus { get; set; }
        public int? IdWeekOff { get; set; }
        public string? Address { get; set; }
        public string? PresentAddress { get; set; }
        public string? NationalIdentificationNumber { get; set; }
        public string? ContactNo { get; set; }
        public int? IdMaritalStatus { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }

        public List<EmployeeDocumentDTO> Documents { get; set; } = new();

        public List<EmployeeEducationInfosDTO> EducationInfos { get; set;} = new();

        public List<EmployeeProfessionalCertificationDTO> ProfessionalCertification { get; set; } = new();


        public List<EmployeeFamilyInfoDTO> EmployeeFamilyInfos { get; set; } = new();










    }
}
