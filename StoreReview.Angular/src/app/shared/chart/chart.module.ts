import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { MatButtonModule } from '@angular/material/button';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { CommonModule } from '@angular/common';
import { ChartComponent } from './chart.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    MatButtonModule,
    NgxChartsModule,
    MatButtonToggleModule,
    MatIconModule,
    FormsModule
  ],
  declarations: [
      ChartComponent
  ],
  exports:[
    ChartComponent
  ]
})
export class ChartModule { }
