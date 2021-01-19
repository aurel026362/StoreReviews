import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';
import { UserModel } from './models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public title = 'myApp';
  isOpenMenu = false;

  get currentUser(): UserModel {
    return this.authService.currentUser;
  }

  get currentUserIsAuthenticated(): boolean {
    return this.authService.isAuthemticated;
  }

  constructor(public dialog: MatDialog,
    private readonly authService: AuthService,
    private readonly router: Router) {
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['./login']);
  }

  menuToggle() {
    this.isOpenMenu = !this.isOpenMenu;
  }
}
