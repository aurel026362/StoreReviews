import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public title = 'myApp';

  get currentUserIsAuthenticated(): boolean {
    return this.authService.isAuthemticated;
  }

  constructor(public dialog: MatDialog,
    private readonly authService: AuthService) {
  }



}
