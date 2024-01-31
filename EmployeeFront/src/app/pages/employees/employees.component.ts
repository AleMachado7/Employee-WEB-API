import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/Employee/Employee';
import { EmployeeService } from 'src/app/services/employee/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
})
export class EmployeesComponent implements OnInit {
  employees: Employee[] = [];
  employeeDefault: Employee[] = [];
  tableColumns: string[] = [
    'Status',
    'Name',
    'Surname',
    'Department',
    'Work Shift',
    'Edit / Details',
  ];
  currentPage: number = 1;
  totalPages!: number;

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.getEmployees(this.currentPage);
  }

  search(event: Event) {
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.employees = this.employeeDefault.filter((employee) => {
      return employee.name.toLowerCase().includes(value);
    });
  }

  getEmployees(page: number) {
    this.employeeService.getEmployees(page).subscribe((employeeData) => {
      const data = employeeData.data;

      data.map((item) => {
        item.creationDate = new Date(item.creationDate!).toLocaleDateString(
          'pt-br'
        );
        item.updateDate = new Date(item.updateDate!).toLocaleDateString(
          'pt-br'
        );
        if (item.department.length > 3) {
          item.department = item.department.split(/(?=[A-Z])/).join(' ');
        }
      });

      this.employees = employeeData.data;
      this.employeeDefault = employeeData.data;
      this.totalPages = employeeData.totalPages;
    });
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage += 1;
      this.getEmployees(this.currentPage);
    }
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage -= 1;
      this.getEmployees(this.currentPage);
    }
  }
}
