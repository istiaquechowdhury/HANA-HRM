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

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public IFormFile? UploadedFile { get; set; }

        public byte[]? UploadedFileBytes { get; set; }

        // public string? UploadedFileBase64 { get; set; }

        public string? UploadedFileBase64 { get; set; }

    }
}
