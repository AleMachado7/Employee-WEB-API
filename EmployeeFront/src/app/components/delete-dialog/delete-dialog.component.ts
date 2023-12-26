import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/services/employee/employee.service';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css'],
})
export class DeleteDialogComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  delete(): void {
    if (this.data.id != null) {
      this.employeeService.deleteEmployee(this.data.id).subscribe(() => {
        this.router.navigate(['employees']);
      });
    }
  }
}
