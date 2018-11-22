import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FieldErrorMatcher } from '../FieldErrorMatcher';
import { FormControl, Validators } from '@angular/forms';
import { EmployeeInfoDto, UpdateEmployeeCommand, AddEmployeeCommand } from '../services/dtos/EmployeeDtos';
import { EmployeesService } from '../services/EmployeesService';

@Component({
  selector: 'app-employee-editor',
  templateUrl: './employee-editor.component.html',
  styleUrls: ['./employee-editor.component.css']
})
export class EmployeeEditorComponent implements OnInit {
  matcher: FieldErrorMatcher;

  nameControl: FormControl;
  emailControl: FormControl;
  salaryControl: FormControl;
  hiredControl: FormControl;
  departmentControl: FormControl;

  maxDate: Date;

  isEditorActive: boolean;
  editEmployeeId: number;
  serverErrors: string;

  @Output() successEditEvent = new EventEmitter();

  constructor(private service: EmployeesService) { 
    this.nameControl = new FormControl('', [Validators.required]);
    this.emailControl = new FormControl('', [Validators.required, Validators.email]);
    this.salaryControl = new FormControl('', [Validators.required, Validators.min(1)]);
    this.maxDate = new Date();
    this.hiredControl = new FormControl(this.maxDate, [Validators.required]);
    this.departmentControl = new FormControl('', [Validators.required, Validators.min(1)]);
  }

  ngOnInit() {
  }

  activateEditor() {
    this.isEditorActive = true;
  }

  deactivateEditor() {
    this.isEditorActive = false;
  }

  isEditInChangeMode() {
    return this.editEmployeeId != null;
  }

  isEditInAddMode() {
    return this.editEmployeeId == null; 
  }

  prepareToChange(employee: EmployeeInfoDto) {
    this.editEmployeeId = employee.id;
    this.nameControl.setValue(employee.name);
    this.emailControl.setValue(employee.email);
    this.salaryControl.setValue(employee.salary);
    this.hiredControl.setValue(employee.hired);
    this.departmentControl.setValue(employee.departmentId);
  }

  prepareToAdd() {
    this.editEmployeeId = null;
    this.nameControl.setValue(null);
    this.emailControl.setValue(null);
    this.salaryControl.setValue(null);
    this.hiredControl.setValue(this.maxDate);
    this.nameControl.setValue(null);
    this.departmentControl.setValue(null);
  }

  isValid() {
    return this.nameControl.valid &&
      this.emailControl.valid &&
      this.salaryControl.valid &&
      this.hiredControl.valid &&
      this.nameControl.valid;
  }

  sendChanged() {
    if (!this.isValid())
      return;

    this.resetServerErrors();

    var command = new UpdateEmployeeCommand;
    command.id = this.editEmployeeId;
    command.name = this.nameControl.value;
    command.email = this.emailControl.value;
    command.salary = Number.parseInt(this.salaryControl.value);
    command.hired = new Date(Date.parse(this.hiredControl.value));
    command.departmentId = Number.parseInt(this.departmentControl.value);

    this.service.updateEmployee(command)
      .subscribe(() => this.onSuccess(), error => this.onError(error));
  }

  sendNew() {
    if (!this.isValid())
      return;
    
    this.resetServerErrors();
    
    var command = new AddEmployeeCommand;
    command.name = this.nameControl.value;
    command.email = this.emailControl.value;
    command.salary = Number.parseInt(this.salaryControl.value);
    command.hired = new Date(Date.parse(this.hiredControl.value));
    command.departmentId = Number.parseInt(this.departmentControl.value);
    
    this.service.addEmployee(command)
      .subscribe(() => this.onSuccess(), error => this.onError(error));
  }

  onSuccess() {
    this.successEditEvent.emit();
    this.deactivateEditor();
  }

  onError(error) {
    this.setServerErrors(error);
  }

  isHasServerErrors() {
    return this.serverErrors != null;
  }

  setServerErrors(errors: string) {
    this.serverErrors = errors;
  }

  resetServerErrors() {
    this.serverErrors = null;
  }
}
