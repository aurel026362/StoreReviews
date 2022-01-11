import { Component, HostListener, Input, OnInit } from '@angular/core';
import { ImageDialogComponent } from '../image-dialog/image-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Review } from 'src/app/models/review.model';
import { ReviewService } from 'src/app/services/review.service';
import { ReviewType } from 'src/app/models/review-type.enum';
import { AuthService } from 'src/app/services/auth.service';
import { InputPageResultModel, PagedResultModel } from 'src/app/models/paged-result.model';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {

  @HostListener("window:scroll", ["$event"])
  onWindowScroll(event) {
    console.log('event ', event);
    //In chrome and some browser scroll is given to body tag
    let pos = (document.documentElement.scrollTop || document.body.scrollTop) + document.documentElement.offsetHeight;
    // pos/max will give you the distance between scroll bottom and and bottom of screen in percentage.
    if (pos >= document.documentElement.scrollHeight) {
      this.loadComments();
    }
  }

  @Input()
  reviewType: ReviewType;
  @Input()
  entityId: number;
  @Input()
  isReply = false;

  replyTo: Review;

  reviews: Review[] = [];


  imageUrlArray = [];

  inputPageResultModel: InputPageResultModel = {
    page: 0,
    pageSize: 10
  } as InputPageResultModel;

  pageResultModel: PagedResultModel<Review>;
  commentFormGroup = new FormGroup({
    description: new FormControl('', [Validators.required]),
    reviewId: new FormControl(),
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
    if (!this.currentUserIsAuthenticated) {
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
    this.inputPageResultModel.page += 1;
    this.reviewService.getReviews(this.inputPageResultModel.page, this.inputPageResultModel.pageSize, this.reviewType, this.entityId).subscribe(data => {
      this.pageResultModel = data;
      data.results.forEach(element => {
        this.reviews.push(element);
      });
    });
  }

  addComment(): void {
    if (this.commentFormGroup.invalid) {
      return;
    }
    const review = this.commentFormGroup.value;
    console.log('review ', review);
    this.reviewService.addReview(this.reviewType, review, this.entityId).subscribe(data => {
      this.resetReviews();
      this.loadComments();
    });
  }

  reply(review: Review): void {
    if (!this.currentUserIsAuthenticated) {
      return;
    }
    this.commentFormGroup.get('reviewId').patchValue(review.id);
    this.replyTo = review;
    console.log('comment form group', this.commentFormGroup);
  }

  removeReply(): void {
    this.replyTo = null;
    this.commentFormGroup.get('reviewId').patchValue(null);
  }

  private resetReviews(): void {
    this.commentFormGroup.reset();
    this.reviews = [];
    this.replyTo = null;
    this.inputPageResultModel.page = 0;
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

  loadReplies(review: Review) {
    this.reviewService.getReviews(this.inputPageResultModel.page, this.inputPageResultModel.pageSize, this.reviewType, this.entityId, review.id).subscribe(data => {
      // this.pageResultModel = data;
      review.replies = data.results;
    });
  }

}
