export class Attendance {
    id: number;
    attendance_date: Date;
    hours_filled: number;
    remarks: Text;

    constructor(
        id: number,
        attendance_date: Date,
        hours_filled: number,
        remarks: Text) {
        this.id = id;
        this.attendance_date = attendance_date;
        this.hours_filled = hours_filled;
        this.remarks = remarks;
    }
}