import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../../Models/Employee';
import { SuperAdminService } from '../../services/superadmin.service';
import { ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-superadmin',
  standalone: false,
  templateUrl: './superadmin.component.html',
  styleUrl: './superadmin.component.css'
  
})
export class SuperadminComponent {
  employeeList: Employee[] = [];
  attendanceDetails: any = [];
  attendanceInfo: number[]=[];
  isOpen = false;
  employeeForm: FormGroup;
  private apiUrl = 'https://your-api-url.com/employees'; 

  // constructor(private http: HttpClient,
  //   private superadminService: SuperAdminService,
  //   private cdRef: ChangeDetectorRef 
  // ) {}
  
  ngOnInit(): void {
    this.getEmployees(); // Fetch data when component loads
  }
  constructor(private fb: FormBuilder,private http: HttpClient,
    private superadminService: SuperAdminService,
    private cdRef: ChangeDetectorRef ) {
    this.employeeForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      jobTitle: ['', Validators.required],
      department: ['', Validators.required]
    });
  }

  openModal(empId: number) {
    this.isOpen = true;
    this.getAttendance(empId);  
  }

  closeModal() {
    this.isOpen = false;
    this.attendanceDetails = null;
  }

  openPayment() {
    this.isOpen = true;  
  }

  closePayment() {
    this.isOpen = false;
  }
  
  getEmployees(){
    this.superadminService.getEmployees().subscribe((res: any) => {
      this.employeeList = res as Employee[];
    });
  }

  getAttendance(empId: number) {
    this.superadminService.getAttendanceSummary(empId).subscribe(
      (res: any) => {
        console.log("Attendance Data:", res); // Debugging
        this.attendanceDetails = Object.entries(res).map(([key, value]) => ({
          type: key,
          days: value
        }))
        if (this.attendanceDetails.length === 0) {
          console.log("No attendance data found.");
        }
      },
      (error) => {
        console.error("Error fetching attendance:", error);
      }
    );
  }
}
