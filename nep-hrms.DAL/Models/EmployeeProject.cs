using System.ComponentModel.DataAnnotations.Schema;
using nep_hrms.DAL.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Models
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        //fk
        public virtual Employee Employee { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;


    }
}
