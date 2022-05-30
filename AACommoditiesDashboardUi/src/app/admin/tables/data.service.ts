import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';


export interface historicaldata {
  Model: string;
  Commodity: string;
  ContractDate: string;
  Contract: string;
  Positon: string;
  NewTradeAction: string;
  Price: string;
  Pnl: string;
}

export interface commodityrunningtotal {
  
  Commodity: string;
  ContractDate: string;
  RunningTotal: string;
}
export interface modelrunningtotal {
  Model: string;  
  ContractDate: string;
  RunningTotal: string;
}

export interface modelpnltrend {
  Model: string;  
  Contract: string;
  Pnl: string;
}

export interface modelpricetrend {
  Model: string;  
  Contract: string;
  Price: string;
}

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(protected http: HttpClient) {}

  public gethistoricaldata(): Observable<historicaldata[]> {
    const url = `${environment.commoditiesApi}/Commodities/historicaldata`;
    return this.http
               .get<historicaldata[]>(url)
               .pipe(map((x) => {               
                 return x
                 }));
               
                 
  }

  public getmodelrunningtotal(): Observable<modelrunningtotal[]> {
    const url = `${environment.commoditiesApi}/Commodities/runningmodel`;
    return this.http
                .get<modelrunningtotal[]>(url)
                .pipe(map((x) => {               
                  return x
                  }));
                
                  
                }

                public getcommodityrunningtotal(): Observable<commodityrunningtotal[]> {
                  const url = `${environment.commoditiesApi}/Commodities/runningcommodity`;
                  return this.http
                              .get<commodityrunningtotal[]>(url)
                              .pipe(map((x) => {               
                                return x
                                }));
                              
                                
                              }

                              
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
                                                              
                              
                private getRandomArrayIndex(length: number): number {
    return Math.round(Math.random() * (length - 1));
  }
}

