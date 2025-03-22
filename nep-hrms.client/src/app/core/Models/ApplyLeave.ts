export class Applyleave {
    id: number;
    empId: number;
    leaveType: string;
    startDate:Date;
    endDate:Date;
    appliedOn:Date;
    noOfDays:number;
    approvedStatus:string;
    approvedBy:string;
    leaveDesc: Text;
    approvedDesc:Text;
    canceledStatus:string;
    canceledOn:Date;
    
    constructor(
        id: number,
        empId: number,
        leaveType: string,
        startDate:Date,
        endDate:Date,
        appliedOn:Date,
        noOfDays:number,
        approvedStatus:string,
        approvedBy:string,
        leaveDesc: Text,
        approvedDesc:Text,
        canceledStatus:string,
        canceledOn:Date
    ) {
        this.id = id;
        this.empId=empId;
        this.leaveType=leaveType;
        this.startDate=startDate;
        this.endDate=endDate;
        this.appliedOn=appliedOn;
        this.noOfDays=noOfDays;
        this.approvedStatus=approvedStatus;
        this.approvedBy=approvedBy;
        this.leaveDesc=leaveDesc;
        this.approvedDesc=approvedDesc;
        this.canceledStatus=canceledStatus;
        this.canceledOn=canceledOn;
    }
}