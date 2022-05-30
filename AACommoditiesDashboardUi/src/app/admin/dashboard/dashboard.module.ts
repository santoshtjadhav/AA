import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

import { MatGridListModule } from '@angular/material/grid-list';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { HomeComponent } from './home/home.component';
import { StatComponent } from './stat/stat.component';

import { CummalativeSumByComComponent } from './home/cumcom/cumcom.component';
import { ModelSumByComComponent } from './home/cummodel/cummodel.component'

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MatGridListModule,
    FlexLayoutModule,
    MatCardModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,    
    MatTableModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatCheckboxModule
  ],
  declarations: [HomeComponent, StatComponent,CummalativeSumByComComponent,ModelSumByComComponent]
})
export class DashboardModule {}
