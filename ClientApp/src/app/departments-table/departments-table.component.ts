import { Component, OnInit } from '@angular/core';
import { DepartmentsService, DepartmentInfoDto, GetAllDepartmentsQuery } from '../app.model';

@Component({
  selector: 'app-departments-table',
  templateUrl: './departments-table.component.html',
  styleUrls: ['./departments-table.component.css']
})
export class DepartmentsTableComponent implements OnInit {
  columns: string[] = [ "id", "departmentName" ];
  departments: DepartmentInfoDto[];

  selectedDepartmentId: number;

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

  selectRow(row) {
    this.selectedDepartmentId = row.id;
  }

  isSelected(row) {
    return this.selectedDepartmentId === row.id;
  }
}
