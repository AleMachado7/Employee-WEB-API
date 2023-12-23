import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { RegisterComponent } from './pages/register/register.component';
import { EmployeeCreateComponent } from './pages/employee-create/employee-create.component';
import { EmployeeEditComponent } from './pages/employee-edit/employee-edit.component';
import { EmployeeDetailsComponent } from './pages/employee-details/employee-details.component';
import { LoginComponent } from './pages/login/login.component';
import { authGuard } from './guard/auth.guard';
import { EmployeesComponent } from './pages/employees/employees.component';
import { UsersComponent } from './pages/users/users.component';

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent }, 
  { path: "home", component: HomeComponent, canActivate: [authGuard] },
  { path: "employees", component: EmployeesComponent,canActivate: [authGuard]},
  { path: "employees/create", component: EmployeeCreateComponent,canActivate: [authGuard]},
  { path: "employees/edit/:id", component: EmployeeEditComponent, canActivate: [authGuard]},
  { path: "employees/details/:id", component: EmployeeDetailsComponent, canActivate: [authGuard]},
  { path: "users", component: UsersComponent, canActivate: [authGuard]},
  { path: "", redirectTo: "/login", pathMatch: "full" },  
  { path: "**", component: NotFoundComponent },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
