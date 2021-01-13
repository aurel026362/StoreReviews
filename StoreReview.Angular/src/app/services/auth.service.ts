import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";
import { STORE_REVIEW_API_URL } from "../app-injection-tokens";
import { Token } from "../models/token";
import { tap } from 'rxjs/operators';

export const ACCESS_TOKEN_KEY = "TOKEN";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(
        private httpClient: HttpClient,
        @Inject(STORE_REVIEW_API_URL) private apiUrl: string,
        private jwtHelper: JwtHelperService,
        private router: Router
    ) {
    }

    login(userName: string, password: string): Observable<Token>{
        console.log('apiUrl ',this.apiUrl);
        return this.httpClient.post<Token>(`${this.apiUrl}api/account/login`,
        {userName, password})
        .pipe(
            tap(token=>{
                localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token)
            })
        );
    }

    get isAuthemticated(): boolean{
        var token = localStorage.getItem(ACCESS_TOKEN_KEY);
        return token && !this.jwtHelper.isTokenExpired(token);
    }

    logout():void{
        localStorage.removeItem(ACCESS_TOKEN_KEY);
        this.router.navigate(['']);
    }
}