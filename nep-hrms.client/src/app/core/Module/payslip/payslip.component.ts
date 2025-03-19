import { Component, OnInit } from '@angular/core';
import { PayslipService } from '../../services/payslip.service';
@Component({
  selector: 'app-payslip',
  standalone: false,
  templateUrl: './payslip.component.html',
  styleUrl: './payslip.component.css'
})
export class PayslipComponent implements OnInit {
  payslipData: any;

  constructor(private payslipService: PayslipService) {}

  ngOnInit(): void {
    const empId = '1233';
    this.payslipService.getPayslip(empId).subscribe(
      (data) => {
        this.payslipData = data;
      },
      (error) => {
        console.error('Error fetching payslip:', error);
      }
    );
  }
}
