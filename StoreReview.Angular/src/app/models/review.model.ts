export class Review {
    id: number;
    description: string;
    date: number;
    ratting: number;
    photoUrls: string[];
    hasReplies: boolean;
    ownerFullName: string;
    userId: number;

    constructor(id: number, description: string, date: number, ratting: number, ownerFullName: string, userId: number, photoUrls?: string[], hasReplies?: boolean) {
        this.id = id;
        this.description = description;
        this.date = date;
        this.ratting = ratting;
        this.photoUrls = photoUrls;
        this.ownerFullName = ownerFullName;
        this.userId  = userId;
        this.hasReplies = hasReplies;
    }
}