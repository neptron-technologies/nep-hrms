using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Server.nep_hrms.DAL;

public class PaySlipReq
{
    public string EmployeeEmail { get; set; }  
    public string EmployeeName { get; set; }   
    public string Salary { get; set; }    
    public string Date { get; set; }
}
