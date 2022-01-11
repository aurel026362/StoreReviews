import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-actions',
  templateUrl: './user-actions.component.html',
  styleUrls: ['./user-actions.component.scss']
})
export class UserActionsComponent implements OnInit {

  get currentUser(): UserModel {
    return this.authService.currentUser;
  }

  constructor(private readonly authService: AuthService) {
  }


  ngOnInit(): void {
  }

}
