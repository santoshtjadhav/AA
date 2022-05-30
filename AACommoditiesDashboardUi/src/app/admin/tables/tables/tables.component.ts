import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { historicaldata, DataService } from '../data.service';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss']
})
export class TablesComponent implements OnInit, AfterViewInit {
  displayedColumns = [ 
    
    'Model',
    'Commodity',
    'ContractDate',
    'Contract',
    'Positon',
     'NewTradeAction',
     'Price',
     'Pnl'
  
  ];
  dataSource!: MatTableDataSource<historicaldata>;
  selection!: SelectionModel<historicaldata>;
  historicaldata: historicaldata[]=[];

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  constructor(private readonly dataService: DataService) {}

  ngOnInit() {    
    this.dataService.gethistoricaldata().subscribe(x=>
      {
        this.historicaldata=x;
        this.dataSource = new MatTableDataSource(this.historicaldata);    
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    
      });
      
    
    this.selection = new SelectionModel<historicaldata>(true, []);
  }

  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: any) {
    this.dataSource.filter = filterValue.target.value.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.data.forEach(row => this.selection.select(row));
  }
}
