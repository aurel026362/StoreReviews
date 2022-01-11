import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";
import { STORE_REVIEW_API_URL } from "../app-injection-tokens";
import { tap } from 'rxjs/operators';
import { RegisterModel } from "../models/register.model";
import { UserModel } from "../models/user.model";

export const ACCESS_TOKEN_KEY = "TOKEN";
export const CURRENT_USER_FIRST_NAME = "CURRENT_USER_FIRST_NAME";
export const CURRENT_USER_LAST_NAME = "CURRENT_USER_LAST_NAME";
export const CURRENT_USER_USERNAME = "CURRENT_USER_USERNAME";
export const CURRENT_USER_ID = "CURRENT_USER_ID";
export const CURRENT_USER_ROLES = "CURRENT_USER_ROLES";
export const CURRENT_USER_PICTUREURL = "CURRENT_USER_PICTUREURL";

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private _currentUser: UserModel;

    get currentUser(): UserModel {
        if (!this.isAuthemticated) {
            return null;
        }
        const user: any = {
            firstName: localStorage.getItem(CURRENT_USER_FIRST_NAME),
            lastName: localStorage.getItem(CURRENT_USER_LAST_NAME),
            username: localStorage.getItem(CURRENT_USER_USERNAME),
            userId: Number(localStorage.getItem(CURRENT_USER_ID)),
            roles: localStorage.getItem(CURRENT_USER_ROLES)?.split(','),
            pictureUrl: localStorage.getItem(CURRENT_USER_PICTUREURL)
        };
        return user as UserModel;
    }
    constructor(
        private httpClient: HttpClient,
        @Inject(STORE_REVIEW_API_URL) private apiUrl: string,
        private jwtHelper: JwtHelperService,
        private router: Router
    ) {
    }

    register(model: RegisterModel): Observable<UserModel> {
        return this.httpClient.post<UserModel>(`${this.apiUrl}api/account/register`,
            model)
            .pipe(
                tap(data => {
                    localStorage.setItem(ACCESS_TOKEN_KEY, data.accessToken);
                    this.setCurrentUser(data);
                })
            );
    }

    login(userName: string, password: string): Observable<UserModel> {
        return this.httpClient.post<UserModel>(`${this.apiUrl}api/account/login`,
            { userName, password })
            .pipe(
                tap(data => {
                    localStorage.setItem(ACCESS_TOKEN_KEY, data.accessToken);
                    this.setCurrentUser(data);
                })
            );
    }


    loginWithFacebook(accessToken: string): Observable<UserModel> {
        return this.httpClient.post<UserModel>(`${this.apiUrl}api/account/login-with-facebook`,
            { accessToken })
            .pipe(
                tap(data => {
                    localStorage.setItem(ACCESS_TOKEN_KEY, data.accessToken);
                    this.setCurrentUser(data);
                })
            );
    }

    private setCurrentUser(data: UserModel): void {
        localStorage.setItem(ACCESS_TOKEN_KEY, data.accessToken);
        localStorage.setItem(CURRENT_USER_ID, data.userId.toString());
        localStorage.setItem(CURRENT_USER_USERNAME, data.userName);
        localStorage.setItem(CURRENT_USER_FIRST_NAME, data.firstName);
        localStorage.setItem(CURRENT_USER_LAST_NAME, data.lastName);
        if (data.pictureUrl) {
            localStorage.setItem(CURRENT_USER_PICTUREURL, data.pictureUrl);
        }
        localStorage.setItem(CURRENT_USER_ROLES, data.roles?.join(','));
    }

    get isAuthemticated(): boolean {
        var token = localStorage.getItem(ACCESS_TOKEN_KEY);
        return token && !this.jwtHelper.isTokenExpired(token);
    }

    logout(): void {
        localStorage.clear();
    }
}