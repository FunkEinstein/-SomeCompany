import { Component, Output, EventEmitter } from '@angular/core';
import { FieldErrorMatcher } from '../FieldErrorMatcher';
import { FormControl, Validators } from '@angular/forms';
import { AddDepartmentCommand, UpdateDepartmentCommand, DepartmentInfoDto } from '../services/dtos/DepartmentDtos';
import { DepartmentsService } from '../services/DepartmentsService';
import { RequestException } from '../services/Exceptions';

@Component({
  selector: 'app-department-editor',
  templateUrl: './department-editor.component.html',
  styleUrls: ['./department-editor.component.css']
})
export class DepartmentEditorComponent {
  matcher: FieldErrorMatcher;

  nameControl: FormControl;

  isEditorActive: boolean;
  editDepartmentId: number;
  serverErrors: string;

  @Output() successEditEvent = new EventEmitter();

  constructor(private service: DepartmentsService) { 
    this.nameControl = new FormControl('', [Validators.required]);
  }

  activateEditor() {
    this.isEditorActive = true;
  }

  deactivateEditor() {
    this.isEditorActive = false;
  }

  isEditInChangeMode() {
    return this.editDepartmentId != null;
  }

  isEditInAddMode() {
    return this.editDepartmentId == null; 
  }
  
  prepareToChange(department: DepartmentInfoDto) {
    this.editDepartmentId = department.id;
    this.nameControl.setValue(department.departmentName);
  }

  prepareToAdd() {
    this.editDepartmentId = null;
    this.nameControl.setValue(null);
  }

  isValid() {
    return this.nameControl.valid;
  }

  sendChanged() {
    if (!this.isValid())
      return;

    this.resetServerErrors();

    var command = new UpdateDepartmentCommand;
    command.id = this.editDepartmentId;
    command.departmentName = this.nameControl.value;

    this.service.updateDepartment(command)
      .subscribe(() => this.onSuccess(), error => this.onError(error));
  }

  sendNew() {
    if (!this.isValid())
      return;
    
    this.resetServerErrors();
    
    var command = new AddDepartmentCommand;
    command.departmentName = this.nameControl.value;
    
    this.service.addDepartment(command)
      .subscribe(() => this.onSuccess(), error => this.onError(error));
  }

  onSuccess() {
    this.successEditEvent.emit();
    this.deactivateEditor();
  }

  onError(error: RequestException) {
    this.setServerErrors(error.response);  
  }

  isHasServerErrors() {
    return this.serverErrors != null;
  }

  setServerErrors(error: string) {
    if(typeof error == 'undefined' || !error)
      return;

    var obj = JSON.parse(error);
    var properties = Object.getOwnPropertyNames(obj);
    var errorBuilder: string[] = new Array();
    properties.forEach(property => {
      errorBuilder.push(obj[property]);
    });

    this.serverErrors = errorBuilder.join("\n");
  }

  resetServerErrors() {
    this.serverErrors = null;
  }
}
