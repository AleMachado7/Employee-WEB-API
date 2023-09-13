import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/Employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  employees: Employee[] = []
  employeeDefault : Employee[] = []

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe(employeeData => {
      const data = employeeData.data;

      data.map((item) => {
        item.creationDate = new Date(item.creationDate!).toLocaleDateString("pt-br")
        item.updateDate = new Date(item.updateDate!).toLocaleDateString("pt-br")
      })
    
      this.employees = employeeData.data
      this.employeeDefault = employeeData.data
    
    });
  }

  search(event: Event) {
    const target = event.target as HTMLInputElement
    const value = target.value.toLowerCase()

    this.employees = this.employeeDefault.filter(employee => {
      return employee.name.toLowerCase().includes(value)
    })
  }
}
