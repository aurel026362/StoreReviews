import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shop } from '../models/shop.model';
import { STORE_REVIEW_API_URL } from '../app-injection-tokens';

@Injectable({
    providedIn: 'root',
})
export class StoreService {

    constructor(private http: HttpClient,
        @Inject(STORE_REVIEW_API_URL) private apiUrl: string,) { }

    getStoreById(id: number): Observable<Shop> {
        return this.http.get<Shop>(`${this.apiUrl}api/shops/` + id);
    }

    getStoresByCompanyId(companyId: number): Observable<Shop[]> {
        return this.http.get<Shop[]>(`${this.apiUrl}api/shops/by-companyId/` + companyId);
    }

    addShop(shop: Shop): Observable<number> {
        return this.http.post<number>(`${this.apiUrl}api/shops`,
        {
            address: shop.address,
            description: shop.description,
            phone: shop.phone,
            companyId: shop.companyId
        });
    }

    updateShop(id: number, shop: Shop): Observable<Shop> {
        return this.http.put<Shop>(`${this.apiUrl}api/shops/` + id, {
            address: shop.address,
            description: shop.description,
            phone: shop.phone,
            companyId: shop.companyId
        });
    }

    deleteShop(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}api/shops/` + id);
    }
}
