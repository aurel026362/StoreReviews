import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public title = 'appTest';
  isOpenMenu = false;

  get currentUserIsAuthenticated(): boolean {
    return this.authService.isAuthemticated;
  }

  constructor(public dialog: MatDialog,
    private readonly httpService: HttpClient,
    private authService: AuthService,
    private readonly router: Router) {
    this.httpService.get('https://localhost:5001/api/home').subscribe(data => {
      console.log('data ', data);
    });
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['./login']);
  }

  menuToggle() {
    this.isOpenMenu = !this.isOpenMenu;
  }
}
