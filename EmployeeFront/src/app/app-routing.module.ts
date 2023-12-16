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

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent }, 
  { path: "home", component: HomeComponent, canActivate: [authGuard] },
  { path: "employee/create", component: EmployeeCreateComponent,canActivate: [authGuard]},
  { path: "employee/edit/:id", component: EmployeeEditComponent, canActivate: [authGuard]},
  { path: "employee/details/:id", component: EmployeeDetailsComponent, canActivate: [authGuard]},
  { path: "", redirectTo: "/login", pathMatch: "full" },  
  { path: "**", component: NotFoundComponent },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
