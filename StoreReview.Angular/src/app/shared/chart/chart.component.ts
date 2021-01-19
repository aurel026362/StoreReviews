import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

export enum CharType {
  VerticalBar,
  Circle,
  Square,
  Guage
}

@Component({
  selector: 'app-tt-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {

  @Input()
  charType: CharType = CharType.Square;
  @Input()
  result = [];
  @Input()
  view: [number, number] = [1000, 400];
  @Input()
  showXAxis = true;
  @Input()
  showYAxis = true;
  @Input()
  gradient = true;
  @Input()
  showLegend = true;
  @Input()
  legendTitle: string = "legend";
  @Input()
  showXAxisLabel = true;
  @Input()
  xAxisLabel = 'xAxisLabel';
  @Input()
  showYAxisLabel = true;
  @Input()
  yAxisLabel = 'yAxisLabel';
  @Input()
  timeline = true;
  @Input()
  colorScheme = {
    domain: ['#004777', '#A30000', '#FF7700', '#EFD28D', '#109648', '#8AF3FF', '#484349', '#A5668B', '#F2D7EE', '#0E103D', '#0D1F22', '#2F394D']
  };

  //square
  cardColor: string = '#232837';

  @Output()
  onSelectItem = new EventEmitter<number>();

  constructor(private readonly router: Router) {
  }
  ngOnInit() {

  }

  onSelect(data): void {
    const companyId: number = JSON.parse(JSON.stringify(data)).extra;
    if (companyId > 0) {
      this.router.navigate(['./company/' + companyId]);
    }
  }

  onActivate(data): void {
    // console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data): void {
    // console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }

  async bubbleSort() {
    const n = this.result.length;

    for(let i=0; i < n -1 ; i++) {
      for(let x=0; x < n - 1; x++) {
        if(this.result[x] > this.result[x+1]) {
          let temp = this.result[x];
          this.result[x] = this.result[x + 1]; 
          this.result[x+1] = temp;
        }
      }
    }
  }
}
