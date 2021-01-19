import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { delay } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';

declare var FB: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  errorMessage: string;
  isLoginSelected = true;
  loginForm: FormGroup;

  registerFormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    userName: new FormControl('', [Validators.required, Validators.minLength(5)]),
    password: new FormControl('', [Validators.required, Validators.minLength(5)]),
    confirmPassword: new FormControl('', [Validators.required]),
    dateOfBirth: new FormControl(''),
    phoneNumber: new FormControl('')
  });

  constructor(private authService: AuthService,
    private readonly httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private readonly router: Router) {

  }

  ngOnInit() {
    if (this.authService.isAuthemticated) {
      this.authService.logout();
    }
    this.loginForm = this.formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
    this.initializeFacebookRequest();
  }

  onSubmitLoginForm() {
    if (this.loginForm.invalid) {
      return;
    }
    const userName = this.loginForm?.get('userName').value;
    const password = this.loginForm?.get('password').value;
    this.authService.login(userName, password)
      .subscribe(() => {
        this.router.navigate(['/'])
      }, error => {
        this.errorMessage = 'Incorrect username or password!'
      })
  }

  onSubmitRegisterForm() {
    if (this.registerFormGroup.invalid) {
      return
    }
    const model = this.registerFormGroup.value;
    model.roles = ['User'];

    this.authService.register(model).subscribe(data => {
      this.router.navigate(['/']);
    }, () => alert("Something wrong!"));
  }

  //facebook request
  private initializeFacebookRequest(): void {
    (window as any).fbAsyncInit = function () {
      FB.init({
        appId: '',
        cookie: true,
        xfbml: true,
        version: 'v9.0'
      });

      FB.AppEvents.logPageView();
    };

    (function (d, s, id) {
      var js, fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) { return; }
      js = d.createElement(s); js.id = id;
      js.src = "https://connect.facebook.net/en_US/sdk.js";
      fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));
  }

  loginThroughFacebook(): void {
    FB.login((respone: any) => {
      console.log('response', respone);
      console.log('token ', respone.authResponse.accessToken);
      this.authService.loginWithFacebook(respone.authResponse.accessToken)
        .subscribe((data) => {
          console.log("succcessSssss", data);
          this.router.navigate(['/'])
          // window.location.href = window.location.href.replace("/login", "");
        }, error => {
          console.log("errorrrrr");
          this.errorMessage = 'Incorrect username or password!'
        })
    })
  }
}
