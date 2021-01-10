import {ReviewModel } from './review';
export class ShopModel {
    id: number;
    title: string;
    description: string;
    reviews: ReviewModel[];
    rating: number;
    photoUrls: string[];

    constructor(id: number, title: string, description: string, reviews: ReviewModel[], rating: number, photoUrls: string[]) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.reviews = reviews;
        this.rating = rating;
        this.photoUrls = photoUrls;
    }
}
