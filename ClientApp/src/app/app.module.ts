import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { API_BASE_URL } from './app.model'
import { environment } from 'src/environments/environment.prod';

import { HttpClientModule } from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: environment.apiBaseUrl
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
