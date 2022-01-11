import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { STORE_REVIEW_API_URL } from '../app-injection-tokens';
import { ReviewType } from '../models/review-type.enum';
import { Review } from '../models/review.model';
import { PagedResultModel } from '../models/paged-result.model';

@Injectable({
    providedIn: 'root',
})
export class ReviewService {

    constructor(private http: HttpClient,
        @Inject(STORE_REVIEW_API_URL) private apiUrl: string) { }

    getReviews(page: number, pageSize: number, reviewType: ReviewType, entityId: number, reviewId: number = undefined): Observable<PagedResultModel<Review>> {
        return this.http.post<PagedResultModel<Review>>(`${this.apiUrl}api/reviews/${reviewType}/get`, {
            inputPage: {
                page: page,
                pageSize: pageSize
            },
            shopId: reviewType == ReviewType.Shop ? entityId : null,
            companyId: reviewType == ReviewType.Company ? entityId : null,
            reviewId: reviewId
        });
    }

    addReview(reviewType: ReviewType, review: Review, entityId): Observable<number> {
        return this.http.post<number>(`${this.apiUrl}api/reviews/${reviewType}/add`, {
            description: review.description,
            ratting: review.ratting,
            shopId: reviewType == ReviewType.Shop ? entityId : null,
            companyId: reviewType == ReviewType.Company ? entityId : null,
            reviewId: review.reviewId
        });
    }
}
