import { Component, OnInit } from '@angular/core';
import { DataService, modelpnltrend,IlineChartData } from '../data.service';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.scss'],
})
export class LineChartComponent implements OnInit {
  lineChartData: Array<any> =[];
  
  /*= [
    {
      data: [65, 59, 80, 81, 56, 55, 40],
      label: 'Series A',
      fill: true,
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)',
      tension: 0.3,
    },
    {
      data: [28, 48, 40, 19, 86, 27, 90],
      label: 'Series B',
      fill: true,
      backgroundColor: 'rgba(77,83,96,0.2)',
      borderColor: 'rgba(77,83,96,1)',
      pointBackgroundColor: 'rgba(77,83,96,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(77,83,96,1)',
      tension: 0.3,
    },
    {
      data: [18, 48, 77, 9, 100, 27, 40],
      label: 'Series C',
      fill: true,
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)',
      tension: 0.3,
    },
  ];*/
  data: modelpnltrend[]=[];
  lineChartLabels: string[] = [];

  

  constructor(private readonly dataService: DataService) {}

  ngOnInit() {
    this.dataService.getmodelpnltrend().subscribe(x=>
      {
        console.log(x);
        for (var data of x) {        
     
     let ld: IlineChartData ={
     
          data: data.pnls,
          label: data.model,
          fill: true,
          backgroundColor: 'rgba(148,159,177,0.2)',
          borderColor: this.random_rgba(),
          pointBackgroundColor: this.random_rgba(),
          pointBorderColor: '#fff',
          pointHoverBackgroundColor: '#fff',
          pointHoverBorderColor: 'rgba(148,159,177,0.8)',
          tension: 0.3,
        };
        this.lineChartData.push(ld);
        
      }
      this.lineChartLabels = x[0].contracts;
      });

  }
  random_rgba() {
    var o = Math.round, r = Math.random, s = 255;
    return 'rgba(' + o(r()*s) + ',' + o(r()*s) + ',' + o(r()*s) + ',' + r().toFixed(1) + ')';
}
  chartClicked(e: any): void {
    
  }


  chartHovered(e: any): void {
  
  }
}
