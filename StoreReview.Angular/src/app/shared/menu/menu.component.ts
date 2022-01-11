import { Component, Input, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from 'src/app/login/login.component';
import { UserModel } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {

  @Output() onListItemClick = new EventEmitter();

  get currentUser(): UserModel {
    return this.authService.currentUser;
  }

  get currentUserIsAuthenticated(): boolean {
    return this.authService.isAuthemticated;
  }
  constructor(
    private readonly authService: AuthService,
    public dialog: MatDialog) {
  }

  emitClickEvent(): void {
    this.onListItemClick.emit();
  }

  openLoginModal(): void {
    this.dialog.open(LoginComponent,
      {
        width: '50%',
        minWidth: '400px',
        maxWidth: '620px'
      });
  }

  logout(): void {
    this.authService.logout();
    this.emitClickEvent();
  }
}
