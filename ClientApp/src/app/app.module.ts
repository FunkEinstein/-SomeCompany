import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { DepartmentsTableComponent } from './departments-table/departments-table.component'
import { EmployeesTableComponent } from './employees-table/employees-table.component';
import { PaginatorComponent } from './paginator/paginator.component';

import { FormsModule } from "@angular/forms"
import { MatTableModule, MatButtonModule, MatTabsModule, MatSelectModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { environment } from 'src/environments/environment.prod';
import { API_BASE_URL } from './services/BaseService';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentsTableComponent,
    EmployeesTableComponent,
    PaginatorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

    FormsModule,
    MatTableModule,
    MatButtonModule,
    MatTabsModule,
    MatSelectModule,
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
