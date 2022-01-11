import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreComponent } from './store.component';
import { StoreService } from '../services/store.service';
import { MatInputModule } from '@angular/material/input';
import { MatExpansionModule } from '@angular/material/expansion';
import { Routes, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { ReviewsModule } from '../shared/reviews/reviews.module';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
const routes: Routes = [
  {
    path: '',
    component: StoreComponent
  }
];

@NgModule({
  imports: [
    MatInputModule,
    MatExpansionModule,
    ReviewsModule,
    CommonModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule,
    MatProgressSpinnerModule,
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
