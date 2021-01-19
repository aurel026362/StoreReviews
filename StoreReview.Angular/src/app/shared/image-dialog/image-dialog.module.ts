import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { ImageDialogComponent } from './image-dialog.component';


@NgModule({
  imports: [
    CommonModule,
    MatButtonModule
  ],
  declarations: [
    ImageDialogComponent
  ],
  providers: [
    ImageDialogComponent
  ],
  entryComponents: [
    ImageDialogComponent
  ],
  exports:[
    ImageDialogComponent
  ]
})
export class ImageDialogModule { }
