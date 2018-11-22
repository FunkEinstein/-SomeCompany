import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PaginatorState } from './paginator-state';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.css']
})
export class PaginatorComponent implements OnInit {
  page: number;
  pageSize: number;
  pageSizes = [5, 10, 20, 50];
  length: number;

  @Output() paginatorStateChangedEvent = new EventEmitter<PaginatorState>();

  constructor() { }

  ngOnInit() {
    this.resetState();
    this.emitStateChangedEvent();
  }

  firstPage() {
    this.page = 1;
  }

  isHasNextPage() {
    var nextRow = this.page * this.pageSize + 1;
    return this.length >= nextRow;
  }

  nextPage() {
    if (!this.isHasNextPage())
      return;

    this.changePage(this.page + 1);
  }

  isHasPreviousPage() {
    return this.page > 1;
  }

  previousPage() {
    if (!this.isHasPreviousPage())
      return;

    this.changePage(this.page - 1);
  }

  changePage(page: number) {
    this.page = page;
    this.emitStateChangedEvent();
  }

  changePageSize(pageSize: number) {
    this.firstPage();
    this.pageSize = pageSize;
    this.emitStateChangedEvent();
  }

  resetState() {
    this.firstPage();
    this.pageSize = this.pageSizes[0];
  }

  emitStateChangedEvent() {
    var state = new PaginatorState(this.page, this.pageSize);
    this.paginatorStateChangedEvent.emit(state);
  }

  setLength(length: number) {
    this.length = length;
  }
}
