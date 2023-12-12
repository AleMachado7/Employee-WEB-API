import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { UserFormComponent } from './components/user-form/user-form.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { RegisterComponent } from './pages/register/register.component';
import { EmployeeCreateComponent } from './pages/employee-create/employee-create.component';
import { EmployeeEditComponent } from './pages/employee-edit/employee-edit.component';
import { EmployeeDetailsComponent } from './pages/employee-details/employee-details.component';
import { LoginComponent } from './pages/login/login.component';

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent }, 
  { path: "home", component: HomeComponent },
  { path: "employee/create", component: EmployeeCreateComponent},
  { path: "employee/edit/:id", component: EmployeeEditComponent},
  { path: "employee/details/:id", component: EmployeeDetailsComponent},
  { path: "", redirectTo: "/login", pathMatch: "full" },  
  { path: "**", component: NotFoundComponent },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
