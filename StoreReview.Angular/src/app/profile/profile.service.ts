import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';
import { UserService } from '../services/user.service';

@Injectable({
    providedIn: "any",
})
export class ProfileService {

    currentUser: UserModel;

    constructor(private readonly userService: UserService) {
        this.getCurrentUserData();
    }

    getCurrentUserData(): void {
        this.userService.getCurrentUser().subscribe(data => {
            this.currentUser = data;
        });
    }
}