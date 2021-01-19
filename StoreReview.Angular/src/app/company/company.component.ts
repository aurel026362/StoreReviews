import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ImageDialogComponent } from '../shared/image-dialog/image-dialog.component';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyService } from '../services/company.service';
import { Company } from '../models/company.model';
import { Review } from '../models/review.model';
import { ReviewType } from '../models/review-type.enum';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss']
})
export class CompanyComponent implements OnInit {

  readonly reviewTypeCompany = ReviewType.Company;
  currentCompanyId: number;
  currentCompany: Company;
  reviews: Review[] = [];
  isLoading = true;
  constructor(
    private readonly companyService: CompanyService,
    private readonly router: Router,
    private dialog: MatDialog,
    private route: ActivatedRoute) {
  }

  async ngOnInit(): Promise<void> {
    this.currentCompanyId = +this.route.snapshot.paramMap.get('id');
    this.currentCompany = await this.companyService.getCompanyById(this.currentCompanyId).toPromise();
    this.isLoading = false;
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
  }

}
