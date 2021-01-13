import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Company } from '../models/company';
import { Shop } from '../Models/store';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent implements OnInit {

  companies: Company[] = [];
  selectedCompanyId: number;
  shopsForSelectedCompany: Shop[] = [];

  constructor(private readonly httpClient: HttpClient) {
    this.httpClient.get<Company[]>('https://localhost:5001/api/companies').subscribe(data => {
        this.companies = data;
    });
  }

  ngOnInit() {
  }

  loadShops(companyId: number):void{
    this.selectedCompanyId = companyId; 
    this.httpClient.get<Shop[]>('https://localhost:5001/api/shops').subscribe(data => {
        this.shopsForSelectedCompany = data;
    });
  }

}
