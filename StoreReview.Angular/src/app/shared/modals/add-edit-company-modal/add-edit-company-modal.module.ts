import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { AddEditCompanyDialogComponent } from './add-edit-company-modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@NgModule({
    imports: [
        CommonModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatDialogModule,
        MatInputModule,
        MatIconModule
    ],
    declarations: [
        AddEditCompanyDialogComponent
    ],
    entryComponents: [
        AddEditCompanyDialogComponent
    ],
    exports: [
        AddEditCompanyDialogComponent
    ]
})
export class AddEditCompanyDialogModule { }
