import { Component, OnInit } from '@angular/core';
import { DataService, modelpnltrend,IlineChartData } from '../data.service';

@Component({
  selector: 'app-line2-chart',
  templateUrl: './line-chart2.component.html',
  styleUrls: ['./line-chart2.component.scss'],
})
export class LineChart2Component implements OnInit {
  lineChartData: Array<any> =[];
  data: modelpnltrend[]=[];
  lineChartLabels: string[] = [];  

  constructor(private readonly dataService: DataService) {}

  ngOnInit() {
    this.dataService.getmodelpricetrend().subscribe(x=>
      {
        console.log(x);
        for (var data of x) {        
     
     let ld: IlineChartData ={
     
          data: data.prices,
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
