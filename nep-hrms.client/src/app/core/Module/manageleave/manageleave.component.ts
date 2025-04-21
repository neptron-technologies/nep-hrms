import { Component, OnInit } from '@angular/core';
import { Applyleave } from '../../Models/ApplyLeave';
import { FormBuilder } from '@angular/forms';
import { ManageleaveService } from '../../services/manageleave.service';

@Component({
  selector: 'app-manageleave',
  standalone: false,
  templateUrl: './manageleave.component.html',
  styleUrl: './manageleave.component.css',
})
export class ManageleaveComponent implements OnInit {
  Leavelist: Applyleave[] = [];

  constructor(private manageLeaveService: ManageleaveService) {}
  ngOnInit(): void {
    this.getPendingLeaves();
  }

  getPendingLeaves() {
    this.manageLeaveService.getPendingLeave().subscribe((res: any) => {
      this.Leavelist = res as Applyleave[];
      console.log(res);
    });
  }

  onApprove(id: number) {
    this.manageLeaveService.approveLeave(id).subscribe((res: any) => {});
    this.getPendingLeaves();
  }

  onReject(id: number) {
    this.manageLeaveService.rejectLeave(id).subscribe((res: any) => {});
    this.getPendingLeaves();
  }
}
