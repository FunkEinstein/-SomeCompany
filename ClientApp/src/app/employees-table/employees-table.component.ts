import { Component, ViewChild } from '@angular/core';
import { EmployeeInfoDto, GetAllEmployeesQuery, AllEmployeesDto } from '../services/dtos/EmployeeDtos';
import { EmployeesService } from '../services/EmployeesService';
import { PaginatorComponent } from '../paginator/paginator.component';
import { PaginatorState } from '../paginator/paginator-state';
import { EmployeeEditorComponent } from '../employee-editor/employee-editor.component';
import { FormControl } from '@angular/forms';

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

  nameControl: FormControl;
  emailControl: FormControl;
  salaryControl: FormControl;
  hiredControl: FormControl;

  @ViewChild(PaginatorComponent) paginator: PaginatorComponent;
  @ViewChild(EmployeeEditorComponent) editor: EmployeeEditorComponent;

  constructor(private service: EmployeesService) {
    this.nameControl = new FormControl;
    this.emailControl = new FormControl;
    this.salaryControl = new FormControl;
    this.hiredControl = new FormControl;
  }

  paginatorStateChanged(state: PaginatorState) {
    this.loadEmployees(state.page, state.pageSize);
  }

  initialize(departmentId: number) {
    this.departmentId = departmentId;
    this.paginator.resetState();
    this.reloadData();
  }

  reloadData() {
      this.loadEmployees(this.paginator.page, this.paginator.pageSize);
  }

  loadEmployees(page: number, pageSize: number) {
    if (this.departmentId == null)
      return;

    this.clearState();

    var query = new GetAllEmployeesQuery;
    query.departmentId = this.departmentId;
    query.page = page;
    query.rowsOnPage = pageSize;

    if (typeof this.nameControl.value != 'undefined' && this.nameControl.value)
      query.nameFilter = this.nameControl.value;
    if (typeof this.emailControl.value != 'undefined' && this.emailControl.value)
      query.emailFilter = this.emailControl.value;
    if (typeof this.salaryControl.value != 'undefined' && this.salaryControl.value)
      query.salaryFilter = Number.parseInt(this.salaryControl.value);
    if (typeof this.hiredControl.value != 'undefined' && this.hiredControl.value)
      query.hiredFilter = new Date(this.hiredControl.value);

    this.service.getAllEmployees(query)
      .subscribe(data => this.setData(data));
  }

  setData(data: AllEmployeesDto) {
    this.employees = data.employees;
    this.paginator.setLength(data.allEmployees);
  }

  isInitialized() {
    return this.departmentId != null;
  }

  activateAdding() {
    this.editor.prepareToAdd();
    this.editor.activateEditor();
  }

  activateEditing() {
    var employee = this.employees.find(e => e.id == this.selectedEmployeeId);
    this.editor.prepareToChange(employee);
    this.editor.activateEditor();
  }

  afterEditing() {
    this.reloadData();
  }

  deleteEmployee() {
    if (this.selectedEmployeeId == null)
      return;

    this.service.deleteEmployee(this.selectedEmployeeId)
      .subscribe(() => this.reloadData());
  }

  clearFilters() {
    this.nameControl.setValue(null);
    this.emailControl.setValue(null);
    this.salaryControl.setValue(null);
    this.hiredControl.setValue(null);

    this.reloadData();
  }

  activateFilter() {
    this.reloadData();
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

  clearState() {
    this.employees = null;
    this.selectedEmployeeId = null;
    this.editor.deactivateEditor();
  }
}
