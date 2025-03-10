namespace nep_hrms.Domain.Models
{
    public class UserRoleDto
    {
        public long Id { get; set; }

        public long RoleId { get; set; }

        public long UserId { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? CreatedDt { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        //public List<PermissionDto> Permissions { get; set; } //Added this line

    }
}
