import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ImageDialogComponent } from '../image-dialog/image-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Review } from 'src/app/models/review.model';
import { ReviewService } from 'src/app/services/review.service';
import { ReviewType } from 'src/app/models/review-type.enum';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {

  @Input()
  reviewType: ReviewType;
  @Input()
  entityId: number;
  @Input()
  isReply = false;
  
  reviews: Review[] = [];

  imageUrlArray = [];

  commentFormGroup = new FormGroup({
    description: new FormControl('', [Validators.required]),
    ratting: new FormControl(null, [Validators.min(0), Validators.max(10)])
  });

  get currentUserIsAuthenticated(): boolean {
    return this.authService.isAuthemticated;
  }

  constructor(
    private readonly authService: AuthService,
    private readonly reviewService: ReviewService,
    private dialog: MatDialog) {
  }

  ngOnInit() {
    if (!this.currentUserIsAuthenticated){
      this.commentFormGroup.disable();
    }
    if (!this.reviewType || !this.entityId) {
      console.log('!!!!!!!!!!! Send review type and entityId !!!!!!!!');
    } else {
      this.loadComments();
    }
    this.imageUrlArray = [
      'assets/Dashboard/photo1.jpg',
      'assets/Dashboard/photo2.jpg',
      'assets/Dashboard/photo3.jpg',
      'assets/Dashboard/photo4.jpg',
    ];
  }

  loadComments(): void {
    this.reviewService.getReviews(1, 10, this.reviewType, this.entityId).subscribe(data => {
      this.reviews = data.results;
    });
  }

  addComment(): void {
    if (this.commentFormGroup.invalid) {
      return;
    }
    const review = this.commentFormGroup.value;
    this.reviewService.addReview(this.reviewType, review, this.entityId).subscribe(data => {
      this.commentFormGroup.reset();
      this.loadComments();
    });
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

  loadMoreReplies() {

  }

  loadMoreComments() {
  }

}
