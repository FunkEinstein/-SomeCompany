import { Component, OnInit } from '@angular/core';
import { DepartmentsService, GetAllDepartmentsQuery, DepartmentInfoDto, AllDepartmentsDto } from './app.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'ClientApp';
  departments: DepartmentInfoDto[];

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
      .subscribe(departmentsDto => this.setDepartments(departmentsDto));
  }

  setDepartments(departmentsDto: AllDepartmentsDto) {
    this.departments = departmentsDto.departments;
  }
}
