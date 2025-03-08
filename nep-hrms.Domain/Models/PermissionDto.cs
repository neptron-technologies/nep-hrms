namespace nep_hrms.Domain.Models
{
    public class PermissionDto
    {
        public long Id { get; set; }

        public string PermissionType { get; set; } = null!;

        public DateTime? CreatedDt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        public string? UpdatedBy { get; set; }

    }
}
