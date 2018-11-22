import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeInfoDto, GetAllEmployeesQuery, AllEmployeesDto } from '../services/dtos/EmployeeDtos';
import { EmployeesService } from '../services/EmployeesService';
import { PaginatorComponent } from '../paginator/paginator.component';
import { PaginatorState } from '../paginator/paginator-state';

@Component({
  selector: 'app-employees-table',
  templateUrl: './employees-table.component.html',
  styleUrls: ['./employees-table.component.css']
})
export class EmployeesTableComponent {
  columns: string[] = [ "id", "name", "email", "salary", "hired", "departmentName" ];
  departmentId: number;
  employees: EmployeeInfoDto[];
  selectedEmployeeId: number;

  @ViewChild(PaginatorComponent) paginator: PaginatorComponent;

  constructor(private service: EmployeesService) {
  }

  paginatorStateChanged(state: PaginatorState) {
    this.loadEmployees(state.page, state.pageSize);
  }

  initialize(departmentId: number) {
    this.departmentId = departmentId;

    if (this.paginator != null) {
      this.paginator.resetState();
      this.loadEmployees(this.paginator.page, this.paginator.pageSize);
    }
  }

  loadEmployees(page: number, pageSize: number) {
    if (this.departmentId == null)
      return;

    this.clearState();

    var query = new GetAllEmployeesQuery;
    query.departmentId = this.departmentId;
    query.page = page;
    query.rowsOnPage = pageSize;
    
    this.service.getAllEmployees(query)
      .subscribe(data => this.setData(data));
  }

  setData(data: AllEmployeesDto) {
    this.employees = data.employees;
    this.paginator.setLength(data.allEmployees);
  }

  clearState() {
    this.employees = null;
    this.selectedEmployeeId = null;
  }

  isInitialized() {
    return this.departmentId != null;
  }

  selectRow(row) {
    this.selectedEmployeeId = row.id;
  }

  isSelected(row) {
    return this.selectedEmployeeId === row.id;
  }

  hasSelected() {
    return this.selectedEmployeeId != null;
  }
}
