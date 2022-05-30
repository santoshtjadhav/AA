import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

export interface IlineChartData{
  data: string[];
  label: string;
  fill: boolean;
  backgroundColor: string;
  borderColor: string;
  pointBackgroundColor: string;
  pointBorderColor: string;
  pointHoverBackgroundColor: string;
  pointHoverBorderColor: string;
  tension: number;

}
export interface IBarChartData{
  data: string[];
  label: string;
}

export interface modelpnltrend {
  model: string;  
  contracts: string[];
  pnls: string[];
}

export interface modelpricetrend {
  model: string;  
  contracts: string[];
  prices: string[];
}

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(protected http: HttpClient) {}


                              
                              public getmodelpnltrend(): Observable<modelpnltrend[]> {
                                const url = `${environment.commoditiesApi}/Commodities/modelpnltrend`;
                                return this.http
                                            .get<modelpnltrend[]>(url)
                                            .pipe(map((x) => {               
                                              return x
                                              }));
                              }
                                              

                                              
                                              public getmodelpricetrend(): Observable<modelpricetrend[]> {
                                                const url = `${environment.commoditiesApi}/Commodities/modelpricetrend`;
                                                return this.http
                                                            .get<modelpricetrend[]>(url)
                                                            .pipe(map((x) => {               
                                                              return x
                                                              }));
                                                            
                                                            }                             
                                                              
                              
}

