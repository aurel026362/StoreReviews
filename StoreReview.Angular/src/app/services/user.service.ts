import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shop } from '../models/shop.model';
import { STORE_REVIEW_API_URL } from '../app-injection-tokens';
import { UserModel } from '../models/user.model';

@Injectable({
    providedIn: 'root',
})
export class UserService {

    constructor(private http: HttpClient,
        @Inject(STORE_REVIEW_API_URL) private apiUrl: string,) { }

    getCurrentUser(): Observable<UserModel> {
        return this.http.get<UserModel>(`${this.apiUrl}api/user`);
    }
}