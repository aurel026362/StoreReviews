import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  errorMessage: string;
  isLoginSelected = true;
  loginForm: FormGroup;

  registerForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
    userName: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  constructor(private authService: AuthService,
    private formBuilder: FormBuilder,
    private readonly router: Router){

  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  onSubmitLoginForm(){
    const userName = this.loginForm.get('userName').value;
    const password = this.loginForm.get('password').value;
    this.authService.login(userName, password)
    .subscribe(()=>{
      this.router.navigate(['/'])
    }, error=>{
        this.errorMessage = 'Incorrect username or password!'
    })
  }

  onSubmitRegisterForm(){
    
  }

  checkIsLogedIn():void{
    const tr = this.authService.isAuthemticated;
    console.log('isAuth ',tr);
  }

}
