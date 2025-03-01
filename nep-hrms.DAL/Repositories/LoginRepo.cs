using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.Server.nep_hrms.DAL;
using nep_hrms.DAL.Interfaces;

namespace nep_hrms.DAL.Repositories
{
    public class LoginRepo :BaseRepo<User> ,ILoginRepo
    {
        public LoginRepo(HrmsDBContext context) : base(context)
        {

        }


    }
}
