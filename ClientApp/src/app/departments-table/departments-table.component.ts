import { Component, Output, EventEmitter, ViewChild } from '@angular/core';
import { DepartmentInfoDto, GetAllDepartmentsQuery, AllDepartmentsDto } from '../services/dtos/DepartmentDtos';
import { DepartmentsService } from '../services/DepartmentsService';
import { PaginatorComponent } from '../paginator/paginator.component';
import { PaginatorState } from '../paginator/paginator-state';

@Component({
  selector: 'app-departments-table',
  templateUrl: './departments-table.component.html',
  styleUrls: ['./departments-table.component.css']
})
export class DepartmentsTableComponent {
  columns: string[] = [ "id", "departmentName" ];
  departments: DepartmentInfoDto[];
  selectedDepartmentId: number;

  @Output() showEmployeesEvent = new EventEmitter<number>();

  @ViewChild(PaginatorComponent) paginator: PaginatorComponent;

  constructor(private service: DepartmentsService) {
  }

  paginatorStateChanged(state: PaginatorState) {
    this.loadDepartments(state.page, state.pageSize);
  }

  loadDepartments(page: number, pageSize: number) {
    var query = new GetAllDepartmentsQuery();
    query.page = page;
    query.rowsOnPage = pageSize;

    this.service.getAllDepartments(query)
      .subscribe(data => this.initDepartments(data));
  }

  initDepartments(data: AllDepartmentsDto) {
    this.departments = data.departments;
    this.paginator.setLength(data.allDepartments);
    this.resetSelection();
  }

  showEmployees() {
    this.showEmployeesEvent.emit(this.selectedDepartmentId);
  }

  selectRow(row) {
    this.selectedDepartmentId = row.id;
  }

  resetSelection() {
    return this.selectedDepartmentId = null;
  }

  isSelected(row) {
    return this.selectedDepartmentId === row.id;
  }

  hasSelected() {
    return this.selectedDepartmentId != null;
  }
}
