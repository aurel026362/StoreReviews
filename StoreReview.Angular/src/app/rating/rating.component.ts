import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { delay } from 'rxjs/operators';
import { Company } from '../models/company.model';
import { Shop } from '../models/shop.model';
import { StoreService } from '../services/store.service';
import { AddEditCompanyDialogComponent } from '../shared/modals/add-edit-company-modal/add-edit-company-modal.component';
import { AddEditShopDialogComponent } from '../shared/modals/add-edit-shop-modal/add-edit-shop-modal.component';
import { ConfirmationDialogComponent } from '../shared/modals/confirmation-dialog/confirmation-dialog.component';

export enum ShowingType {
  Table,
  Cards
}
@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent implements OnInit {
  readonly showingTypeCards: ShowingType = ShowingType.Cards;
  selectedShowingType = ShowingType.Cards;
  companies: Company[] = [];
  initialCompanies: Company[] = [];
  selectedCompanyId: number;
  shopsForSelectedCompany: Shop[] = [];
  companySearch = new FormControl();

  displayedColumns: string[] = ['address', 'description', 'phone', 'ratting', 'actions'];

  companiesForChart = [];
  isLoading = true;

  constructor(private readonly httpClient: HttpClient,
    private readonly shopService: StoreService,
    private dialog: MatDialog) {
    this.httpClient.get<Company[]>('https://localhost:5001/api/companies').subscribe(data => {
      this.isLoading = false;
      this.companies = data;
      this.initialCompanies = [...data];
      this.companiesForChart = data.slice(0, 15).map(x => ({ extra: x.id, name: x.name, value: Math.floor(Math.random() * 10) + 1 }));
    })
  }

  ngOnInit() {
    this.companySearch.valueChanges.pipe(delay(800)).subscribe(data => {
      if (data) {
        this.companies = this.initialCompanies.filter(x =>
          x.name.toLocaleLowerCase().includes(data.toLocaleLowerCase())
          || x.phone.toLocaleLowerCase().includes(data.toLocaleLowerCase())
        );
      } else {
        this.companies = [...this.initialCompanies];
      }
    });
  }

  loadShops(companyId: number): void {
    this.shopsForSelectedCompany = [];
    this.selectedCompanyId = companyId;
    this.shopService.getStoresByCompanyId(companyId).subscribe(data => {
      this.shopsForSelectedCompany = data;
    });
  }
  addCompany(): void {

    const dialogRef = this.dialog.open(AddEditCompanyDialogComponent,
      {
        width: '400px'
      });
    dialogRef.afterClosed().subscribe(result => {
    });
  }

  editCompany(companyId: number): void {
    const dialogRef = this.dialog.open(AddEditCompanyDialogComponent,
      {
        width: '400px',
        data: {
          companyId: companyId
        }
      });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  addShop(): void {
    const dialogRef = this.dialog.open(AddEditShopDialogComponent,
      {
        width: '400px',
        data: {
          companyId: this.selectedCompanyId
        }
      });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadShops(this.selectedCompanyId);
      }
    });
  }

  editShop(shopId: number): void {
    const dialogRef = this.dialog.open(AddEditShopDialogComponent,
      {
        width: '400px',
        data: {
          companyId: this.selectedCompanyId,
          shopId: shopId
        }
      });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadShops(this.selectedCompanyId);
      }
    });
  }

  deleteShop(shopId: number): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent,
      {
        width: '400px',
        data: {
          title: 'Warning',
          message: 'Are you sure you want to delete this store?'
        }
      });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.shopService.deleteShop(shopId).subscribe();
      }
    });
  }
}
