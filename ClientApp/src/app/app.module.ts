import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { DepartmentsTableComponent } from './departments-table/departments-table.component'
import { EmployeesTableComponent } from './employees-table/employees-table.component';
import { PaginatorComponent } from './paginator/paginator.component';

import { FormsModule, ReactiveFormsModule } from "@angular/forms"
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { 
  MatTableModule, 
  MatButtonModule, 
  MatTabsModule, 
  MatSelectModule, 
  MatInputModule, 
  MatDatepickerModule,
  MatNativeDateModule } 
  from '@angular/material';

import { environment } from 'src/environments/environment.prod';
import { API_BASE_URL } from './services/BaseService';
import { DepartmentEditorComponent } from './department-editor/department-editor.component';
import { EmployeeEditorComponent } from './employee-editor/employee-editor.component';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentsTableComponent,
    EmployeesTableComponent,
    PaginatorComponent,
    DepartmentEditorComponent,
    EmployeeEditorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatButtonModule,
    MatTabsModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    BrowserAnimationsModule
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: environment.apiBaseUrl
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
