namespace HRM.WEB.ChildEntitiesDTO
{
    public class EmployeeProfessionalCertificationDTO
    {
        public int IdClient { get; set; }

        public int? Id { get; set; }
        public string CertificationTitle { get; set; } = null!;
        public string CertificationInstitute { get; set; } = null!;
        public string InstituteLocation { get; set; } = null!;
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
