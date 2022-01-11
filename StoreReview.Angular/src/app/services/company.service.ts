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

    addCompany(company: Company): Observable<number> {
        return this.http.post<number>(`${this.apiUrl}api/companies`,
            {
                name: company.name,
                description: company.description,
                phone: company.phone,
                logoUrl: company.logoUrl,
                webSite: company.webSite,
                photoUrls: company.photoUrls
            });
    }

    updateCompany(id: number, company: Company): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}api/companies/${id}`, {
            name: company.name,
            description: company.description,
            phone: company.phone,
            logoUrl: company.logoUrl,
            webSite: company.webSite,
            photoUrls: company.photoUrls
        });
    }

    deleteCompany(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}api/companies/${id}`);
    }
}
