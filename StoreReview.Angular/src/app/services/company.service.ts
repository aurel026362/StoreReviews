import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { STORE_REVIEW_API_URL } from '../app-injection-tokens';
import { Company } from '../models/company.model';

@Injectable({
    providedIn: 'root',
})
export class CompanyService {

    constructor(private http: HttpClient,
        @Inject(STORE_REVIEW_API_URL) private apiUrl: string) { }

    getCompaies(): Observable<Company[]> {
        return this.http.get<Company[]>(`${this.apiUrl}api/companies`);
    }

    getCompanyById(id: number): Observable<Company> {
        return this.http.get<Company>(`${this.apiUrl}api/companies/` + id);
    }
}
