import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AddEditShopDialogComponent } from './add-edit-shop-modal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';

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
        AddEditShopDialogComponent
    ],
    entryComponents: [
        AddEditShopDialogComponent
    ],
    exports: [
        AddEditShopDialogComponent
    ]
})
export class AddEditShopDialogModule { }
