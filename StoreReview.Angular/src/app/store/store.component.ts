import { Component, OnInit } from '@angular/core';
import { Shop } from 'src/app/models/shop.model';
import { StoreService } from '../services/store.service';
import { MatDialog } from '@angular/material/dialog';
import { ImageDialogComponent } from '../shared/image-dialog/image-dialog.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewType } from '../models/review-type.enum';
@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.scss']
})
export class StoreComponent implements OnInit {

  readonly reviewTypeShop = ReviewType.Shop;
  currentStoreId: number;
  currentStore: Shop;
  isStore = true;

  constructor(
    private readonly storeService: StoreService,
    private readonly router: Router,
    private dialog: MatDialog,
    private route: ActivatedRoute) { 
      console.log('current route ',this.router.url);
      if (this.router.url.includes('company')){
        this.isStore = false
      }
      const id = this.route.snapshot.paramMap.get('id');
    }

  async ngOnInit(): Promise<void> {
      this.currentStoreId = +this.route.snapshot.paramMap.get('id');
      this.currentStore = await this.storeService.getStoreById(this.currentStoreId).toPromise();
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
