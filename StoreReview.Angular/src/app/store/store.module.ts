import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreComponent } from './store.component';
import { StoreService } from './store.service';
import { MatInputModule } from '@angular/material/input';
import { SlideshowModule } from 'ng-simple-slideshow';
import { MatExpansionModule } from '@angular/material/expansion';
import { Routes, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
const routes: Routes = [
  {
    path: '',
    component: StoreComponent
  }
];

@NgModule({
  imports: [
    MatInputModule,
    SlideshowModule,
    MatExpansionModule,
    CommonModule,
    MatButtonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [
    StoreComponent
  ],
  providers: [
    StoreService
  ]
})
export class StoreModule { }
