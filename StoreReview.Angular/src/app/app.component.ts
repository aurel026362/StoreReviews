import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public title = 'appTest';
  isOpenMenu = false;

  constructor(public dialog: MatDialog,
    private readonly httpService: HttpClient) {
    this.httpService.get('https://localhost:44359/WeatherForecast').subscribe(data => {
      console.log('data ', data);
    });
  }

  menuToggle() {
    this.isOpenMenu = !this.isOpenMenu;
  }
}
