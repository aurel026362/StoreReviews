import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from '../models/user.model';
import { AuthService } from '../services/auth.service';
import { UserService } from '../services/user.service';
import { ProfileService } from './profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  get currentUser(): UserModel {
    return this.profileService.currentUser;
  }

  get currentRouteIsEditProfile(): boolean {
    return this.router.url.includes('profile/edit');
  }

  get getEditButtonName(): string {
    return this.currentRouteIsEditProfile ? "Actions" : "Edit";
  }

  constructor(private readonly authService: AuthService,
    private readonly router: Router,
    private readonly profileService: ProfileService) {
  }


  ngOnInit(): void {
  }

  refreshCurrentUserData(): void {
    if (this.currentRouteIsEditProfile) {
      this.profileService.getCurrentUserData();
    }
  }
}
