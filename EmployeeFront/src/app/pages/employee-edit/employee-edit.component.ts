import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/Employee/Employee';
import { EmployeeParams } from 'src/app/models/Employee/EmployeeParams';
import { EmployeeService } from 'src/app/services/employee/employee.service';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css'],
})
export class EmployeeEditComponent implements OnInit {
  formTitle: string = 'Edit Employee';
  btnAction: string = 'Save Changes';
  employee!: Employee;

  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id != null) {
      this.employeeService.getEmployee(id).subscribe((response) => {
        this.employee = response.data;
      });
    }
  }

  editEmployee(employeeParams: EmployeeParams) {
    this.employeeService.editEmployee(this.employee.id!, employeeParams).subscribe(() => {
      this.router.navigate(['home']);
    });
  }
}
