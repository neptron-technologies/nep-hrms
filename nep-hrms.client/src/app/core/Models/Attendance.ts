export class Attendance {
    id?: number;
    empId: number;
    attendanceDate: Date;
    hoursFilled: number;
    remarks: string;
    //status_id: number;
    status?: { id: number; status: string };
    projectId: number;
    constructor(
 
        id: number,
        empId: number,
        attendanceDate: Date,
        hoursFilled: number,
        remarks: string,
        projectId:number
       // status_id: number
    )  
   
        {
        this.id = id;
        this.empId = empId;
        this.attendanceDate = attendanceDate;
        this.hoursFilled = hoursFilled;
        this.remarks = remarks;
        this.projectId = projectId;
      //  this.status_id = status_id;
    }
}
