import { Component, OnInit } from '@angular/core';
import { DataService, IBarChartData } from '../data.service';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.scss'],
})
export class BarChartComponent implements OnInit {
  barChartLabels: string[] = [];
  barChartData: any[] = [];
  constructor(private readonly dataService: DataService) {}

  ngOnInit() {

    this.dataService.getmodelpricetrend().subscribe(x=>
      {
        console.log(x);
        for (var data of x) {        
     
     let ld: IBarChartData ={
     
          data: data.prices,
          label: data.model
        };
        this.barChartData.push(ld);
        
      }
      this.barChartLabels = x[0].contracts;
      });

    
  }

  chartClicked(e: any): void {
  
  }

  chartHovered(e: any): void {
   
  }
}
