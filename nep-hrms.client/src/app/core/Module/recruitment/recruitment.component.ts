import { Component, OnInit } from '@angular/core';
import { RecruitmentService } from '../../services/recruitment.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-recruitment',
  standalone: false,
  templateUrl: './recruitment.component.html',
  styleUrls: ['./recruitment.component.css']
})
export class RecruitmentComponent implements OnInit {
  recruitments: any[] = [];
  recruitmentForm: FormGroup;
  isEditMode = false;
  editId: number | null = null;

  constructor(private fb: FormBuilder, private recruitmentService: RecruitmentService) {
    this.recruitmentForm = this.fb.group({
      candidateName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
      positionApplied: ['', Validators.required],
      status: ['', Validators.required],
      interviewLevel: ['', Validators.required],
      interviewDate: ['', Validators.required],
      feedback: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.fetchRecruitments();
  }

  fetchRecruitments() {
    this.recruitmentService.getRecruitments().subscribe({
      next: (data) => {
        this.recruitments = data;
      },
      error: (err) => console.error('Error fetching recruitments:', err)
    });
  }

  addRecruitment() {
    if (this.recruitmentForm.valid) {
      let recruitmentData = this.recruitmentForm.value;

      recruitmentData.interviewDate = this.formatDate(recruitmentData.interviewDate);

      this.recruitmentService.addRecruitment(recruitmentData).subscribe({
        next: (response) => {
          console.log('Recruitment added:', response);
          this.fetchRecruitments(); // Refresh table
          this.recruitmentForm.reset();
        },
        error: (error) => console.error('Error adding recruitment:', error)
      });
    }
  }

  editRecruitment(recruitment: any) {
    this.isEditMode = true;
    this.editId = recruitment.id;

    const formattedRecruitment = { ...recruitment, interviewDate: this.formatDate(recruitment.interviewDate) };
    this.recruitmentForm.patchValue(formattedRecruitment);
  }

  updateRecruitment() {
    if (this.editId && this.recruitmentForm.valid) {
      let updatedData = { ...this.recruitmentForm.value, id: this.editId };

      updatedData.interviewDate = this.formatDate(updatedData.interviewDate);

      this.recruitmentService.updateRecruitment(this.editId, updatedData).subscribe({
        next: (response) => {
          console.log('Recruitment updated:', response);
          this.fetchRecruitments(); // Refresh table
          this.isEditMode = false;
          this.editId = null;
          this.recruitmentForm.reset();
        },
        error: (error) => console.error('Error updating recruitment:', error)
      });
    }
  }

  deleteRecruitment(id: number) {
    if (confirm('Are you sure you want to delete this candidate?')) {
      this.recruitmentService.deleteRecruitment(id).subscribe({
        next: () => {
          console.log('Recruitment deleted');
          this.fetchRecruitments(); // Refresh table
        },
        error: (error) => console.error('Error deleting recruitment:', error)
      });
    }
  }

  //date in "yyyy-MM-dd"
  private formatDate(date: string | Date): string {
    if (!date) return '';

    let formattedDate = new Date(date).toISOString().split('T')[0]; // Extract "yyyy-MM-dd"
    return formattedDate;
  }
}
