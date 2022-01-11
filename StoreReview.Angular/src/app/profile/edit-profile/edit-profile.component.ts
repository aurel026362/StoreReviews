import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserModel } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {

  editUserForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    dateOfBirth: new FormControl(''),
    phoneNumber: new FormControl('')
  });


  get currentUser(): UserModel {
    return this.authService.currentUser;
  }

  constructor(private readonly authService: AuthService,
    private readonly profileService: ProfileService) {
    this.editUserForm.patchValue(this.profileService.currentUser);
    this.editUserForm.valueChanges.subscribe(data=>{
      this.profileService.currentUser = data as UserModel;
    })
  }


  ngOnInit(): void {
  }

  onSumbitEditForm(): void {

  }

}
