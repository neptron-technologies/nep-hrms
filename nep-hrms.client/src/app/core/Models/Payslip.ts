export class Payslip {
    id: number;
    empId: number;
    uanNo: string;
    pfNo: string;
    bankName: string;
    ifscCode: string;
    accountNo: string;
    esi: string;
    accountName: string;
  
    constructor(
      id: number,
      empId: number,
      uanNo: string,
      pfNo: string,
      bankName: string,
      ifscCode: string,
      accountNo: string,
      esi: string,
      accountName:string
    ) {
      this.id = id;
      this.empId = empId;
      this.uanNo = uanNo;
      this.pfNo = pfNo;
      this.bankName = bankName;
      this.ifscCode = ifscCode;
      this.accountNo = accountNo;
      this.esi = esi;
      this.accountName = accountName
    }
  }