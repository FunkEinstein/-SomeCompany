import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { API_BASE_URL } from './app.model'
import { environment } from 'src/environments/environment.prod';

import { HttpClientModule } from '@angular/common/http';
import { DepartmentsTableComponent } from './departments-table/departments-table.component'

import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentsTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule
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
