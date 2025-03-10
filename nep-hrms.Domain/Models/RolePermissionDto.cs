using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class RolePermissionDto
    {
        public string RoleName { get; set; }
        public List<PermissionDto> Permissions { get; set; }
    }
}
