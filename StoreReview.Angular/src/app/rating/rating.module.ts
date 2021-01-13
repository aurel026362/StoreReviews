import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SlideshowModule } from 'ng-simple-slideshow';
import { MatButtonModule } from '@angular/material/button';
import { RatingComponent } from './rating.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCardModule } from '@angular/material';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    SlideshowModule,
    MatButtonModule,
    MatExpansionModule,
    MatCardModule,
    RouterModule
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
