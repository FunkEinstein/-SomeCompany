import { Component, OnInit, Input } from '@angular/core';
import { EmployeeInfoDto, GetAllEmployeesQuery } from '../services/dtos/EmployeeDtos';
import { EmployeesService } from '../services/EmployeesService';

@Component({
  selector: 'app-employees-table',
  templateUrl: './employees-table.component.html',
  styleUrls: ['./employees-table.component.css']
})
export class EmployeesTableComponent implements OnInit {
  columns: string[] = [ "id", "name", "email", "salary", "hired", "departmentName" ];
  employees: EmployeeInfoDto[];
  selectedEmployeeId: number;

  constructor(private service: EmployeesService) {
  }

  ngOnInit() {
  }

  loadDepartmentEmployees(departmentId: number) {
    this.clearState();

    var query = new GetAllEmployeesQuery;
    query.departmentId = departmentId;
    query.page = 1;
    query.rowsOnPage = 10;
    
    this.service.getAllEmployees(query)
      .subscribe(employesDto => this.employees = employesDto.employees);
  }

  clearState() {
    this.employees = null;
    this.selectedEmployeeId = null;
  }

  isHasEmployees() {
    return this.employees != null && this.employees.length > 0;
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
