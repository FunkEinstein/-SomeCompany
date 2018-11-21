import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DepartmentInfoDto, GetAllDepartmentsQuery } from '../services/dtos/DepartmentDtos';
import { DepartmentsService } from '../services/DepartmentsService';

@Component({
  selector: 'app-departments-table',
  templateUrl: './departments-table.component.html',
  styleUrls: ['./departments-table.component.css']
})
export class DepartmentsTableComponent implements OnInit {
  columns: string[] = [ "id", "departmentName" ];
  departments: DepartmentInfoDto[];
  selectedDepartmentId: number;

  @Output() showEmployeesEvent = new EventEmitter<number>();

  constructor(private service: DepartmentsService) {
  }
  
  ngOnInit() {
    this.loadDepartments();
  }

  loadDepartments() {
    var query = new GetAllDepartmentsQuery();
    query.page = 1;
    query.rowsOnPage = 10;

    this.service.getAllDepartments(query)
      .subscribe(departmentsDto => this.departments = departmentsDto.departments);
  }

  showEmployees() {
    this.showEmployeesEvent.emit(this.selectedDepartmentId);
  }

  selectRow(row) {
    this.selectedDepartmentId = row.id;
  }

  isSelected(row) {
    return this.selectedDepartmentId === row.id;
  }

  hasSelected() {
    return this.selectedDepartmentId != null;
  }
}
