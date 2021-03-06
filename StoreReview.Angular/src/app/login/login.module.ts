import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login.component';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
@NgModule({
  imports: [
    BrowserModule,
    MatInputModule,
    MatButtonModule,
    CommonModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatIconModule
  ],
  declarations: [
    LoginComponent
  ]
})
export class LoginModule { }
