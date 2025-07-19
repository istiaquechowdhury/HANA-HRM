namespace HRM.WEB.ChildEntitiesDTO
{
    public class EmployeeDocumentDTO
    {
        public string DocumentName { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string? UploadedFileExtention { get; set; }
        public byte[]? UploadedFile { get; set; }
    }
}
