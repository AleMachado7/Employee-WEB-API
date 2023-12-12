import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/Employee/Employee';
import { EmployeeService } from 'src/app/services/employee/employee.service';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from 'src/app/components/delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css'],
})
export class EmployeeDetailsComponent implements OnInit {
  employeeData?: Employee;

  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private route: ActivatedRoute,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id != null) {
      this.employeeService.getEmployee(id).subscribe((response) => {
        response.data.creationDate = new Date(
          response.data.creationDate!
        ).toLocaleDateString('pt-BR');

        if (response.data.updateDate != null) {
          response.data.updateDate = new Date(
            response.data.updateDate
          ).toLocaleDateString('pt-BR');
        }

        this.employeeData = response.data;
      });
    }
  }

  inactivateEmployee(): void {
    if (this.employeeData?.id != null) {
      this.employeeService
        .inactivateEmployee(this.employeeData.id)
        .subscribe(() => {
          this.router.navigate(['home']);
        });
    }
  }

  openDeleteDialog(): void {
    this.dialog.open(DeleteDialogComponent, {
      width: '350px',
      height: '350px',
      data: this.employeeData
    });
  }
}
