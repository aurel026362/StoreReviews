import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ShopModel } from '../models/store';
import { ReviewModel } from '../models/review';
import { UserModel } from '../models/user';

@Injectable({
    providedIn: 'root',
})
export class StoreService {

    constructor(private http: HttpClient) { }

    //getStore(id: number): Observable<ShopModel> {
    // return this.http.get<ShopModel>('Controller/getStore_' + id);
    //}

    getStore(id) {
        return new ShopModel(1, 'Linela', `Most interceptors inspect the request on the way in and forward the (perhaps altered) 
            request to the handle() method of the next object which implements the HttpHandler interface.`,
            [new ReviewModel(1, 'nice dasdsa sad sadsa ', new Date(), 6.7, new UserModel(1, 'Aleona', 'SS', new Date(1996, 2, 6, 8, 56), 'aleona@ma.ru'),
                ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'],
                [new ReviewModel(1, ' asd asd sad shajdksah sajdhsa ksdadsa ', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru'),
                    ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'])]),
            new ReviewModel(1, 'nice dasdsa sad sadsa ', new Date(), 6.7, new UserModel(1, 'Aleona', 'SS', new Date(1996, 2, 6, 8, 56), 'aleona@ma.ru'),
                ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'],
                [new ReviewModel(1, ' asd asd sad shajdksah sajdhsa ksdadsa ', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru'),
                    ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'])]),
            new ReviewModel(1, 'nice dasdsa sad sadsa ', new Date(), 6.7, new UserModel(1, 'Aleona', 'SS', new Date(1996, 2, 6, 8, 56), 'aleona@ma.ru'),
                ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'],
                [new ReviewModel(1, ' asd asd sad shajdksah sajdhsa ksdadsa ', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru'),
                    ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'])]),
            new ReviewModel(1, 'nice dasdsa sad sadsa ', new Date(), 6.7, new UserModel(1, 'Aleona', 'SS', new Date(1996, 2, 6, 8, 56), 'aleona@ma.ru'),
                ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'],
                [new ReviewModel(1, ' asd asd sad shajdksah sajdhsa ksdadsa ', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru'),
                    ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'])]),
            new ReviewModel(1, 'nice dasdsa sad sadsa ', new Date(), 6.7, new UserModel(1, 'Aleona', 'SS', new Date(1996, 2, 6, 8, 56), 'aleona@ma.ru'),
                ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg'],
                [new ReviewModel(1, ' asd asd sad shajdksah sajdhsa ksdadsa ', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru')),
                new ReviewModel(1, ' dsadsadsadsa fgdgfd ', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru')),
                new ReviewModel(1, ' zxc gfd a fdsf sdkjfskdjf hsdkfh sdkjf hsdklfh sldkfh sdjfshdk sdfjshdg fjkshdgf shdgf jksd ghskdj gfgfsjkdfg jdshfg jsdfg jshdgfjksd gfjksgdf gdjsfg skdfgjsdh fgjhgsjkdf ghshkd fgjksdfgh kjsdh fgjkdgkfjshdgfkshdfkjshdgfjkfg kjghdsfkj hsd fhgss d re fddg ', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru')),
                new ReviewModel(1, ' owerpwe we rweoirpwe ', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru')),
                new ReviewModel(1, ' a5675 df w fds', new Date(), 6.7, new UserModel(1, 'Jora', 'TT', new Date(1996, 2, 6, 8, 56), 'jora@ma.ru'))])],
            6.7,
            ['assets/Dashboard/photo1.jpg', 'assets/Dashboard/photo2.jpg', 'assets/Dashboard/photo3.jpg', 'assets/Dashboard/photo4.jpg']
        );
    }
}
