import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { NgChartsModule } from 'ng2-charts';

import { ChartsRoutingModule } from './charts-routing.module';
import { HomeComponent } from './home/home.component';
import { BarChartComponent } from './bar-chart/bar-chart.component';
import { LineChartComponent } from './line-chart/line-chart.component';
import { LineChart2Component } from './line-chart2/line-chart2.component';
import { DataService } from './data.service';

@NgModule({
  imports: [
    CommonModule,
    ChartsRoutingModule,
    MatCardModule,
    MatGridListModule,
    FlexLayoutModule,
    NgChartsModule
  ],
  declarations: [
    HomeComponent,
    BarChartComponent,
    LineChartComponent,LineChart2Component

  ],
  providers: [DataService]
})
export class ChartsModule {}
