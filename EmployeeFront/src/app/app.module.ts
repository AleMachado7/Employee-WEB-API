import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { UserFormComponent } from './components/user-form/user-form.component';
import { EmployeeFormComponent } from './components/employee-form/employee-form.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RegisterComponent } from './pages/register/register.component';
import { EmployeeCreateComponent } from './pages/employee-create/employee-create.component';
import { EmployeeEditComponent } from './pages/employee-edit/employee-edit.component';
import { EmployeeDetailsComponent } from './pages/employee-details/employee-details.component';
import { DeleteDialogComponent } from './components/delete-dialog/delete-dialog.component';

/* Angular Material */
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { LoginComponent } from './pages/login/login.component';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserFormComponent,
    EmployeeFormComponent,
    NotFoundComponent,
    RegisterComponent,
    EmployeeCreateComponent,
    EmployeeEditComponent,
    EmployeeDetailsComponent,
    LoginComponent,
    DeleteDialogComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    NgbModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatSelectModule,
    MatTableModule,
    MatDialogModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
