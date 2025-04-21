import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PayslipService } from '../../services/payslip.service';
import { CommonModule } from '@angular/common';
import { DataTransferService } from '../../services/data-transfer.service';
import { jsPDF } from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-payslip',
  standalone: false,
  templateUrl: './payslip.component.html',
  styleUrl: './payslip.component.css',
})
export class PayslipComponent implements OnInit {
  payslipData: any;
  @Input() empId: number | null = null;

  @ViewChild('payslip', { static: false }) payslip!: ElementRef;

  constructor(
    private payslipService: PayslipService,
    private dataTransferService: DataTransferService
  ) {}

  ngOnInit(): void {
    this.updatePayslip();
  }

  updatePayslip(): void {
    this.empId = this.dataTransferService.getEmpId();

    if (this.empId) {
      this.payslipService.getPayslip(this.empId).subscribe(
        (data) => {
          this.payslipData = data;
        },
        (error) => {
          console.error('Error fetching payslip:', error);
        }
      );
    } else {
      console.error('Employee Id not found');
    }
  }
  downloadPDF() {
    const element = this.payslip.nativeElement;

    html2canvas(element, { scale: 2 }).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
      const pdf = new jsPDF('p', 'mm', 'a4');
      const imgWidth = 210; // A4 width in mm
      const pageHeight = 297; // A4 height in mm
      const imgHeight = (canvas.height * imgWidth) / canvas.width;

      let heightLeft = imgHeight;
      let position = 0;

      pdf.addImage(imgData, 'PNG', 0, position, imgWidth, imgHeight);
      heightLeft -= pageHeight;

      while (heightLeft > 0) {
        position = heightLeft - imgHeight;
        pdf.addPage();
        pdf.addImage(imgData, 'PNG', 0, position, imgWidth, imgHeight);
        heightLeft -= pageHeight;
      }

      pdf.save('Payslip.pdf');
    });
  }
}
