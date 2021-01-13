import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MenuComponent } from './shared/menu/menu.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { SlideshowModule } from 'ng-simple-slideshow';
import { AboutComponent } from './about/about.component';
import { ContactsComponent } from './contacts/contacts.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { ImageDialogModule } from './shared/image-dialog/image-dialog.module';
import { RatingModule } from './rating/rating.module';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { LoginModule } from './login/login.module';
import { STORE_REVIEW_API_URL } from './app-injection-tokens';
import { environment } from 'src/environments/environment';
import { JwtModule } from "@auth0/angular-jwt";
import { ACCESS_TOKEN_KEY, AuthService } from './services/auth.service';
import { MatIconModule } from '@angular/material';

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

@NgModule({
  imports: [
    NgxMaterialTimepickerModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatDialogModule,
    MatInputModule,
    SlideshowModule,
    HttpClientModule,
    MatExpansionModule,
    MatButtonModule,
    ImageDialogModule,
    RatingModule,
    LoginModule,
    MatIconModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: environment.tokenAllowedDomains
      }
    })
  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    MenuComponent,
    AboutComponent,
    ContactsComponent,
    PageNotFoundComponent
  ],
  providers: [{
    provide: STORE_REVIEW_API_URL,
    useValue: environment.storeReviewApi
  },
  AuthService
  ],
  entryComponents: [
    MenuComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
