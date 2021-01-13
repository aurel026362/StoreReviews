import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shop } from '../models/store';

@Injectable({
    providedIn: 'root',
})
export class StoreService {

    constructor(private http: HttpClient) { }

    //getStore(id: number): Observable<ShopModel> {
    // return this.http.get<ShopModel>('Controller/getStore_' + id);
    //}

    getStoreById(id:number): Observable<Shop> {
        return null;
    }
}
