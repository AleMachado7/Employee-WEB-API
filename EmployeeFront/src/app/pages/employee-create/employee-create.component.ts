import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeParams } from 'src/app/models/Employee/EmployeeParams';
import { EmployeeService } from 'src/app/services/employee/employee.service';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css'],
})
export class EmployeeCreateComponent {
  formTitle: string = 'Register Employee';
  btnAction: string = 'Create';

  constructor(
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  createEmployee(employee: EmployeeParams) {
    this.employeeService.createEmployee(employee).subscribe(() => {
      this.router.navigate(['home']);
    });
  }
}
