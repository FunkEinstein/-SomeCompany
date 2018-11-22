import { Component, ViewChild } from '@angular/core';
import { EmployeesTableComponent } from './employees-table/employees-table.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'ClientApp';
  selectedTab: number;
  
  EmployeesTabIndex = 2;
  @ViewChild(EmployeesTableComponent) employeesComponent: EmployeesTableComponent;

  constructor() { }

  onShowEmployees(id: number) {
    this.employeesComponent.initialize(id);
    this.selectedTab = this.EmployeesTabIndex;
  }
}
