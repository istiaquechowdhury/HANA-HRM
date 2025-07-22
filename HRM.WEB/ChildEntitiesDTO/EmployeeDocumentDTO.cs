namespace HRM.WEB.ChildEntitiesDTO
{
    public class EmployeeDocumentDTO
    {
        public int IdClient { get; set; }

        public int Id { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;

        public DateTime UploadDate { get; set; }
        public string? UploadedFileExtention { get; set; }
        public byte[]? UploadedFile { get; set; }
    }
}
