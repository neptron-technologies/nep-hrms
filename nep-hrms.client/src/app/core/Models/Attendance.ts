export class Attendance {
    id: number;
    emp_id:number;
    attendance_date: Date;
    hours_filled: number;
    remarks: Text;
    status_id : number;
    project_id: number;

    constructor(
        id: number,
        emp_id:number,
        attendance_date: Date,
        hours_filled: number,
        remarks: Text,
        status_id: number,
        project_id:number
    )
    
    
    {
        this.id = id;
        this.emp_id = emp_id;
        this.attendance_date = attendance_date;
        this.hours_filled = hours_filled;
        this.remarks = remarks;
        this.status_id = status_id;
        this.project_id = project_id;
    }
}