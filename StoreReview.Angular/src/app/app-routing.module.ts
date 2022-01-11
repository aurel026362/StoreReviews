import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AboutComponent } from './about/about.component';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';
import { AuthGuard } from './guard/auth.guard';
import { AppComponent } from './app.component';
const routes: Routes = [
  {
    path: '',
    component: DashboardComponent
  },
  {
    path: 'store/:id',
    children: [{
      path: '',
      loadChildren: () => import('./store/store.module').then(m => m.StoreModule)
    }]
  },
  {
    path: 'company/:id',
    children: [{
      path: '',
      loadChildren: () => import('./company/company.module').then(m => m.CompanyModule)
    }]
  },
  {
    path: 'profile',
    children: [{
      path: '',
      loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule),
      canActivate: [AuthGuard]
    }]
  },
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: '',
    component: AppComponent
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
