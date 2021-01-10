import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SlideshowModule } from 'ng-simple-slideshow';
import { MatButtonModule } from '@angular/material/button';
import { ImageDialogComponent } from './image-dialog.component';


@NgModule({
  imports: [
    CommonModule,
    SlideshowModule,
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
