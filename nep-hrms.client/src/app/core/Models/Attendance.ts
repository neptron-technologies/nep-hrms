// export class Attendance {
//     id?: number;
//     emp_id: number;
//     attendanceDate: Date;
//     hoursFilled: number;
//     remarks: string;
//     //status_id: number;
//     status?: { id: number; status: string };
//     project_id: number;


//     constructor(
 
//         id: number,
//         emp_id: number,
//         attendanceDate: Date,
//         hoursFilled: number,
//         remarks: string,
//         project_id:number
//        //status_id: number
//     )  
   
//         {
//         this.id = id;
//         this.emp_id = emp_id;
//         this.attendanceDate = attendanceDate;
//         this.hoursFilled = hoursFilled;
//         this.remarks = remarks;
//         this.project_id = project_id;
//         //this.status_id = status_id;
//     }
// }
 
export class Attendance {
    id?: number;
    emp_id: number;
    attendanceDate: Date;
    hoursFilled: number;
    remarks: string;
    //status_id: number;
    status?: { id: number; status: string };
    project_id: number;
    constructor(
 
        id: number,
        emp_id: number,
        attendanceDate: Date,
        hoursFilled: number,
        remarks: string,
        project_id:number
       // status_id: number
    )  
   
        {
        this.id = id;
        this.emp_id = emp_id;
        this.attendanceDate = attendanceDate;
        this.hoursFilled = hoursFilled;
        this.remarks = remarks;
        this.project_id = project_id;
      //  this.status_id = status_id;
    }
}