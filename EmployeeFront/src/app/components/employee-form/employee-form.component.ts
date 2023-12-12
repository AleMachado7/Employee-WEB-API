import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Employee } from 'src/app/models/Employee/Employee';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css'],
})
export class  EmployeeFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Employee>();
  @Input() formTitle!: string;
  @Input() btnAction!: string;
  @Input() employeeData: Employee | null = null;

  employeeForm!: FormGroup;

  constructor() {}

  ngOnInit(): void {
    this.employeeForm = new FormGroup({
      name: new FormControl(this.employeeData ? this.employeeData.name : '', [
        Validators.required,
      ]),
      surname: new FormControl(
        this.employeeData ? this.employeeData.surname : '',
        [Validators.required]
      ),
      department: new FormControl(
        this.employeeData ? this.employeeData.department : '',
        [Validators.required]
      ),
      workShift: new FormControl(
        this.employeeData ? this.employeeData.workShift : '',
        [Validators.required]
      ),
    });
  }

  submit() {
    if (this.employeeForm.valid) {
      this.onSubmit.emit(this.employeeForm.value);
    }
  }
}
