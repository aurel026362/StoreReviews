import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  imageUrlArray = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get(`WeatherForecast`).subscribe(data => {
      console.log('data ', data);
    });

    this.imageUrlArray = [
      'assets/Dashboard/photo1.jpg',
      'assets/Dashboard/photo2.jpg',
      'assets/Dashboard/photo3.jpg',
      'assets/Dashboard/photo4.jpg',
    ];
  }

}