export class Attendance {
    id?: number;
    emp_id: number;
    attendanceDate: Date;
    hoursFilled: number;
    remarks: string;

    constructor(
        id: number,
        emp_id: number,
        attendanceDate: Date,
        hoursFilled: number,
        remarks: string) {
        this.id = id;
        this.emp_id = emp_id;
        this.attendanceDate = attendanceDate;
        this.hoursFilled = hoursFilled;
        this.remarks = remarks;
    }
}