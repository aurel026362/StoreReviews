import { UserModel } from './user';

export class ReviewModel {
    id: number;
    description: string;
    date: Date;
    ratting: number;
    photoUrls: string[];
    user: UserModel;
    replies: ReviewModel[];


    constructor(id: number, description: string, date: Date, ratting: number, user: UserModel, photoUrls?: string[], replies?: ReviewModel[]) {
        this.id = id;
        this.description = description;
        this.date = date;
        this.ratting = ratting;
        this.photoUrls = photoUrls;
        this.user = user;
        this.replies = replies;
    }
}