import { Component, Input, OnInit } from '@angular/core';
import { PayslipService } from '../../services/payslip.service';
import { Payslip } from '../../Models/Payslip';

@Component({
  selector: 'app-payslip',
  standalone: false,
  templateUrl: './payslip.component.html',
  styleUrls: ['./payslip.component.css'] 
})
export class PayslipComponent implements OnInit {
  currentDate: Date = new Date();
  payslipData: Payslip | null = null;
  @Input() empId: number = 2; 

  constructor(private payslipService: PayslipService) {}
  
  ngOnInit(): void {
    this.fetchPayslip();
  }

  fetchPayslip(): void {
    this.payslipService.getPayslip(this.empId).subscribe(
      (data) => {
        this.payslipData = data;
        console.log(data);
      },
      (error) => {
        console.error('Error fetching payslip:', error);
      }
    );
  }
}

