import { UserModel } from "./user.model";

export class Review {
    id: number;
    description: string;
    date: Date;
    ratting: number;
    photoUrls: string[];
    hasReplies: boolean;
    owner: UserModel;
    userId: number;
    isReply: boolean;
    replies: Review[];
    reviewId: boolean;
}