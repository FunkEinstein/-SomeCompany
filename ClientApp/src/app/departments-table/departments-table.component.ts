import { Component, Output, EventEmitter, ViewChild } from '@angular/core';
import { DepartmentInfoDto, GetAllDepartmentsQuery, AllDepartmentsDto } from '../services/dtos/DepartmentDtos';
import { DepartmentsService } from '../services/DepartmentsService';
import { PaginatorComponent } from '../paginator/paginator.component';
import { PaginatorState } from '../paginator/paginator-state';
import { DepartmentEditorComponent } from '../department-editor/department-editor.component';

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
  @ViewChild(DepartmentEditorComponent) editor: DepartmentEditorComponent;

  constructor(private service: DepartmentsService) {
  }

  paginatorStateChanged(state: PaginatorState) {
    this.loadDepartments(state.page, state.pageSize);
  }

  reloadData() {
    this.loadDepartments(this.paginator.page, this.paginator.pageSize);
  }

  loadDepartments(page: number, pageSize: number) {
    this.resetSelection();

    var query = new GetAllDepartmentsQuery();
    query.page = page;
    query.rowsOnPage = pageSize;

    this.service.getAllDepartments(query)
      .subscribe(data => this.setData(data));
  }

  setData(data: AllDepartmentsDto) {
    this.departments = data.departments;
    this.paginator.setLength(data.allDepartments);
  }

  activateAdding() {
    this.editor.prepareToAdd();
    this.editor.activateEditor();
  }

  activateEditing() {
    var department = this.departments.find(e => e.id == this.selectedDepartmentId);
    this.editor.prepareToChange(department);
    this.editor.activateEditor();
  }

  afterEditing() {
    this.reloadData();
  }
  
  deleteDepartment() {
    if (this.selectedDepartmentId == null)
      return;

    this.service.deleteDepartment(this.selectedDepartmentId)
      .subscribe(() => this.reloadData());
  }

  showEmployees() {
    this.showEmployeesEvent.emit(this.selectedDepartmentId);
  }

  selectRow(row) {
    this.selectedDepartmentId = row.id;
  }

  resetSelection() {
    this.selectedDepartmentId = null;
  }

  isSelected(row) {
    return this.selectedDepartmentId === row.id;
  }

  hasSelected() {
    return this.selectedDepartmentId != null;
  }
}
