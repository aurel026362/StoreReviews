import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatExpansionModule } from '@angular/material/expansion';
import { Routes, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { CompanyComponent } from './company.component';
import { CompanyService } from '../services/company.service';
import { ReviewsModule } from '../shared/reviews/reviews.module';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
const routes: Routes = [
  {
    path: '',
    component: CompanyComponent
  }
];

@NgModule({
  imports: [
    MatInputModule,
    MatExpansionModule,
    CommonModule,
    MatButtonModule,
    ReviewsModule,
    MatDividerModule,
    MatIconModule,
    RouterModule.forChild(routes),
    MatProgressSpinnerModule
  ],
  declarations: [
    CompanyComponent
  ],
  providers: [
    CompanyService
  ]
})
export class CompanyModule { }
