import { formatDate } from '@angular/common';
 import { Component, OnInit } from '@angular/core';
 import { FormBuilder, FormGroup, Validators } from '@angular/forms';
 import { ApplyleaveService } from '../../services/applyleave.service';
 import { Applyleave } from '../../Models/ApplyLeave';
import Swal from 'sweetalert2';
import { DataTransferService } from '../../services/data-transfer.service';
@Component({
  selector: 'app-applyleave',
  standalone: false,
  templateUrl: './applyleave.component.html',
  styleUrl: './applyleave.component.css'
})
export class ApplyleaveComponent implements OnInit {
  leaveForm: FormGroup;
  leaveTypes = ['EL', 'Optional'];
  holidays: string[] = [];
  isStartDateHoliday: boolean = false;
  isEndDateHoliday: boolean = false;
  Leavelist: Applyleave[] = [];
  Empid: number | null = null;
  //Empid: number = Number(localStorage.getItem('empId')) || 0;
  PanelOpen: boolean = false;

  constructor(private fb: FormBuilder, private applyleaveService: ApplyleaveService, private dataTransferService: DataTransferService) {
    this.leaveForm = this.fb.group({
      empId: [null, Validators.required],
      leaveType: ['', Validators.required],
      startDate: [null, Validators.required],
      endDate: [null, Validators.required],
      appliedOn: [formatDate(new Date(), 'yyyy-MM-dd', 'en')],
      noOfDays: [{ value: 0, disabled: true }],
      approvedStatus: [{ value: 'Pending', disabled: true }],
      approvedBy: [''],
      leaveDesc: ['', Validators.maxLength(200)],
      approvedDesc: [''],
      canceledStatus: ['Not Cancelled'],
      canceledOn: null
    });
    this.leaveForm.get('startDate')?.valueChanges.subscribe(() => this.checkHolidays());
    this.leaveForm.get('endDate')?.valueChanges.subscribe(() => this.checkHolidays());
  }
  ngOnInit(): void {
     this.Empid = this.dataTransferService.getEmpId();
    
      if (this.Empid !== null) {
      this.leaveForm.patchValue({ empId: this.Empid });
      this.getLeaves(this.Empid);
      this.getHolidays()
    } else {
      console.error('Employee ID is null. Unable to fetch leaves.');
    }

    
    

  }


  checkHolidays() {
    const startDate = this.leaveForm.get('startDate')?.value;
    const endDate = this.leaveForm.get('endDate')?.value;

    this.isStartDateHoliday = this.holidays.includes(startDate);
    this.isEndDateHoliday = this.holidays.includes(endDate);

    this.calculateDays();
  }

  calculateDays() {
    const start = this.leaveForm.get('startDate')?.value;
    const end = this.leaveForm.get('endDate')?.value;

    if (start && end) {
      const startDate = new Date(start);
      const endDate = new Date(end);

      if (endDate >= startDate) {
        const diffTime = Math.abs(endDate.getTime() - startDate.getTime());
        const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)) + 1;

        this.leaveForm.patchValue({ noOfDays: diffDays });
      } else {
        this.leaveForm.patchValue({ noOfDays: 0 });
      }
    }
  }
  getHolidays() {
    this.applyleaveService.getHoliday().subscribe((res: any) => {

      this.holidays = res.map((holiday: any) => holiday.holidayDate);

    });
  }
  getLeaves(id: number) {
    this.applyleaveService.getLeave(id).subscribe((res: any) => {
      this.Leavelist = res as Applyleave[];

    });
  }
  onCancel(id: number) {
    this.applyleaveService.cancelLeave(id).subscribe((res: any) => {
    });
    
    if (this.Empid !== null) {
   
      this.getLeaves(this.Empid);
   
    } else {
      console.error('Employee ID is null. Unable to fetch leaves.');
    }
    
  }

  openPanel() {
    this.resetForm();
    this.PanelOpen = true;
  }
  closePanel() {
    this.PanelOpen = false;
  }
  submitForm() {
    if (this.leaveForm.valid) {
      const leaveData = this.leaveForm.getRawValue();
      leaveData.empId = this.Empid;
      leaveData.appliedOn = formatDate(new Date(), 'yyyy-MM-dd', 'en');
      console.log(leaveData);
      this.calculateDays();
      leaveData.noOfDays = this.leaveForm.get('noOfDays')?.value || 0;
      this.applyleaveService.applyLeave(leaveData).subscribe(
        (response: any) => {
          console.log('Leave Applied:', response);
          Swal.fire('Success!', 'Leave Applied successfully.', 'success');
         
          this.resetForm();
          this.PanelOpen = false;
          
      if (this.Empid !== null) {
       
        this.getLeaves(this.Empid);
       
      } else {
        console.error('Employee ID is null. Unable to fetch leaves.');
      }
        },
        (error: any) => {
          console.error('Error while Applying Leave:', error);
          Swal.fire('Error!', 'There was an error applying leave.', 'error');
        }
      );
    } else {
      console.log('Form Invalid!');
    }
  }



  resetForm() {
    this.leaveForm.reset({
      empId: '',
      leaveType: '',
      startDate: '',
      endDate: '',
      appliedOn: '',
      noOfDays: '',
      leaveDesc: '',
      approvedStatus: 'Pending',
      approvedBy: '',
      canceledStatus: '',
      canceledOn: ''

    });
  }
}
