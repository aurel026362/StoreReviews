import { Component, OnInit } from '@angular/core';
import { Shop } from 'src/app/Models/store';
import { StoreService } from './store.service';
import { MatDialog } from '@angular/material/dialog';
import { ImageDialogComponent } from '../shared/image-dialog/image-dialog.component';
import { ReviewModel } from '../models/review';
@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.scss']
})
export class StoreComponent implements OnInit {

  currentStore: Shop;
  reviews: ReviewModel[] = [];

  constructor(private storeService: StoreService,
    private dialog: MatDialog) { }

  async ngOnInit(): Promise<void> {
    this.currentStore = await this.storeService.getStoreById(1).toPromise();
  }

  openImage(imageUrls, selectedImageUrl) {
    const dialogRef = this.dialog.open(ImageDialogComponent, {
      width: '80%',
      height: '80%'
    });
    dialogRef.componentInstance.imageUrls = imageUrls;
    dialogRef.componentInstance.selectedImageUrl = selectedImageUrl;


    dialogRef.afterClosed().subscribe(result => {
    });
  }

  loadMoreReplies(commentId: number) {

  }

  loadMoreComments() {
    const storeId = this.currentStore.id;
  }

}
