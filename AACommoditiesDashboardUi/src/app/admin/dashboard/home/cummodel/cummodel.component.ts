import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { modelrunningtotal, DataService } from '../../../tables/data.service';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-cummodel',
  templateUrl: './cummodel.component.html',
  styleUrls: ['./cummodel.component.scss']
})
export class ModelSumByComComponent implements OnInit, AfterViewInit {
  displayedColumns = [ 
    
    
    'Model',
    'ContractDate',    
     'RunningTotal'
  
  ];
  dataSource!: MatTableDataSource<modelrunningtotal>;
  selection!: SelectionModel<modelrunningtotal>;
  historicaldata: modelrunningtotal[]=[];

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  constructor(private readonly dataService: DataService) {}

  ngOnInit() {    
    this.dataService.getmodelrunningtotal().subscribe(x=>
      {
        this.historicaldata=x;
        console.log(x);
        this.dataSource = new MatTableDataSource(this.historicaldata);    
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    
      });
      
    
    this.selection = new SelectionModel<modelrunningtotal>(true, []);
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
