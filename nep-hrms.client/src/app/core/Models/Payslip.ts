export interface Payslip {
    id: number;
    empId: number;
    hra: number;
    conveyanceAllowance: number;
    medicalAllowance: number;
    otherAllowance: number;
    grossSalary: number;
    epf: number;
    esi: number;
    professionalTax: number;
    totalDeduction: number;
    netSalary: number;
    salaryMonth: string; // ISO string format for DateTime


    uanNo?: string;
    pfNo?: string;
    bankName?: string;
    ifscCode?: string;
    accountNo?: string;
    esiNo?: string;
    accountName:string;
}