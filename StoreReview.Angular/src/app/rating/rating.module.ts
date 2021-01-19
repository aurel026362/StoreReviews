import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { RatingComponent } from './rating.component';
import { RouterModule } from '@angular/router';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCardModule } from '@angular/material/card';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { ChartModule } from '../shared/chart/chart.module';
import { AddEditShopDialogModule } from '../shared/modals/add-edit-shop-modal/add-edit-shop-modal.module';
import { AddEditCompanyDialogModule } from '../shared/modals/add-edit-company-modal/add-edit-company-modal.module';
import { ConfirmationDialogModule } from '../shared/modals/confirmation-dialog/confirmation-dialog.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
@NgModule({
  imports: [
    CommonModule,
    MatButtonModule,
    MatExpansionModule,
    MatCardModule,
    RouterModule,
    MatButtonToggleModule,
    MatIconModule,
    MatTableModule,
    ChartModule,
    AddEditShopDialogModule,
    AddEditCompanyDialogModule,
    ConfirmationDialogModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule
  ],
  declarations: [
    RatingComponent
  ],
  providers: [
    RatingComponent
  ],
  entryComponents: [
    RatingComponent
  ],
  exports: [
    RatingComponent
  ]
})
export class RatingModule { }
