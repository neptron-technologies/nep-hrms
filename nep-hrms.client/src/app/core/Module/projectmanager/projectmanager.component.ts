import { Component, OnInit } from '@angular/core';
import { ProjectManagerService} from '../../services/projectmanager.service';
import { Projectmanager } from '../../Models/projectmanager';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-project',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './projectmanager.component.html',
  styleUrls: ['./projectmanager.component.css']
})
export class ProjectManagerComponent implements OnInit {
  projectId!: number;
  employeeId!: number;
  newProjectId!: number;
  newEmployeeId!: number;
  
  projects: Projectmanager[] = []; 
  employeesByProject: any[] = [];
  projectsByEmpId: any[] = [];

  project: Projectmanager = new Projectmanager();

  constructor(private projectManagerService: ProjectManagerService) {}

  ngOnInit() {
    this.getProjects(); 
  }

  formatDate(date: string | null): string {
    return date ? date.split('T')[0] : '';
  }

  fetchEmployeesByProject() {
    if (!this.projectId) {
      alert("Please enter a valid Project ID!");
      return;
    }

    this.projectManagerService.getEmployeesByProject(this.projectId).subscribe(
      (data: any[]) => this.employeesByProject = data,
      error => alert("Failed to fetch employees.")
    );
  }

  fetchProjectsByEmpId() {
    if (!this.employeeId) {
      alert("Please enter a valid Employee ID!");
      return;
    }

    this.projectManagerService.getProjectsByEmployee(this.employeeId).subscribe(
      (data: any[]) => this.projectsByEmpId = data,
      error => alert("Failed to fetch projects.")
    );
  }

  addEmployeeToProject() {
    if (!this.newProjectId || !this.newEmployeeId) {
      alert("Enter valid Project ID and Employee ID!");
      return;
    }

    this.projectManagerService.addEmployeeToProject(this.newProjectId, this.newEmployeeId).subscribe(
      response => alert(response.message),
      error => alert("Failed to add employee to project.")
    );
  }

 getProjects() {
  this.projectManagerService.getProjects().subscribe({
    next: (data: any[]) => {
      this.projects = data.map((proj: any) => ({
        ...proj,
        name: proj.name ?? '',
        createdBy: proj.createdBy ?? '',
        startDate: this.formatDate(proj.startDate),
        endDate: this.formatDate(proj.endDate)
      }));
    },
    error: (error) => console.error('Error fetching projects:', error)
  });
}

addProject() {
  this.project.startDate = this.formatDate(this.project.startDate);
  this.project.endDate = this.formatDate(this.project.endDate);

  this.projectManagerService.addProject(this.project).subscribe({
    next: () => {
      alert('Project added successfully!');
      this.getProjects(); 
      this.resetForm();
    },
    error: (error) => console.error('Error adding project:', error)
  });
}

updateProject() {
  if (!this.project.id) {
    alert('Please select a project to update');
    return;
  }

  this.project.startDate = this.formatDate(this.project.startDate);
  this.project.endDate = this.formatDate(this.project.endDate);

  this.projectManagerService.updateProject(this.project.id, this.project).subscribe({
    next: () => {
      alert('Project updated successfully!');
      this.getProjects(); 
      this.resetForm();
    },
    error: (error) => console.error('Error updating project:', error)
  });
}

deleteProject(id: number) {
  if (!id) {
    alert("Invalid Project ID!");
    return;
  }

  if (confirm('Are you sure you want to delete this project?')) {
    this.projectManagerService.deleteProject(id).subscribe({
      next: () => {
        alert('Project deleted successfully!');
        this.getProjects(); 
      },
      error: (error) => console.error('Error deleting project:', error)
    });
  }
}

selectProject(project: Projectmanager) {
  this.project = {
    ...project,
    startDate: this.formatDate(project.startDate),
    endDate: this.formatDate(project.endDate)
  };
}

resetForm() {
  this.project = new Projectmanager();
}
}