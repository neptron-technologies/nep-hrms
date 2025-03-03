using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class UserDto
    {
     
       
        
        public string Username { get; set; }
        public List<string> RoleNames { get; set; } 
        public List<string> Permissions { get; set; }

         
        
    }
}