import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { commodityrunningtotal, DataService } from '../../../tables/data.service';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-cumcom',
  templateUrl: './cumcom.component.html',
  styleUrls: ['./cumcom.component.scss']
})
export class CummalativeSumByComComponent implements OnInit, AfterViewInit {
  displayedColumns = [ 
    
    
    'Commodity',
    'ContractDate',    
     'RunningTotal'
  
  ];
  dataSource!: MatTableDataSource<commodityrunningtotal>;
  selection!: SelectionModel<commodityrunningtotal>;
  historicaldata: commodityrunningtotal[]=[];

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  constructor(private readonly dataService: DataService) {}

  ngOnInit() {    
    this.dataService.getcommodityrunningtotal().subscribe(x=>
      {
        this.historicaldata=x;
        this.dataSource = new MatTableDataSource(this.historicaldata);    
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    
      });
      
    
    this.selection = new SelectionModel<commodityrunningtotal>(true, []);
  }

  ngAfterViewInit() {
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
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
