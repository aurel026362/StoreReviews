import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SlideshowModule } from 'ng-simple-slideshow';
import { MatButtonModule } from '@angular/material/button';
import { RatingComponent } from './rating.component';
import { MatExpansionModule } from '@angular/material/expansion';

@NgModule({
  imports: [
    CommonModule,
    SlideshowModule,
    MatButtonModule,
    MatExpansionModule
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
