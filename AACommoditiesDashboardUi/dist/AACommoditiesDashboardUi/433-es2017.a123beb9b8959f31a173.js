"use strict";(self.webpackChunkaacommodities_dashboard_ui=self.webpackChunkaacommodities_dashboard_ui||[]).push([[433],{7433:function(t,e,i){i.r(e),i.d(e,{TablesModule:function(){return j}});var o=i(8583),n=i(81),a=i(3762),c=i(4847),r=i(7322),s=i(4361),l=i(7446),u=i(4655),d=i(449),m=i(7716),f=i(3432);function h(t,e){1&t&&(m.TgZ(0,"th",15),m._uU(1," Model "),m.qZA())}function p(t,e){if(1&t&&(m.TgZ(0,"td",16),m._uU(1),m.qZA()),2&t){const t=e.$implicit;m.xp6(1),m.hij(" ",t.model," ")}}function g(t,e){1&t&&(m.TgZ(0,"th",15),m._uU(1," Commodity "),m.qZA())}function Z(t,e){if(1&t&&(m.TgZ(0,"td",16),m._uU(1),m.qZA()),2&t){const t=e.$implicit;m.xp6(1),m.hij(" ",t.commodity," ")}}function C(t,e){1&t&&(m.TgZ(0,"th",15),m._uU(1," ContractDate "),m.qZA())}function w(t,e){if(1&t&&(m.TgZ(0,"td",16),m._uU(1),m.qZA()),2&t){const t=e.$implicit;m.xp6(1),m.hij(" ",t.contractDate," ")}}function A(t,e){1&t&&(m.TgZ(0,"th",15),m._uU(1," Contract "),m.qZA())}function T(t,e){if(1&t&&(m.TgZ(0,"td",16),m._uU(1),m.qZA()),2&t){const t=e.$implicit;m.xp6(1),m.hij(" ",t.contract," ")}}function D(t,e){1&t&&(m.TgZ(0,"th",15),m._uU(1," Positon "),m.qZA())}function N(t,e){if(1&t&&(m.TgZ(0,"td",16),m._uU(1),m.qZA()),2&t){const t=e.$implicit;m.xp6(1),m.hij(" ",t.positon," ")}}function y(t,e){1&t&&(m.TgZ(0,"th",15),m._uU(1," NewTradeAction "),m.qZA())}function S(t,e){if(1&t&&(m.TgZ(0,"td",16),m._uU(1),m.qZA()),2&t){const t=e.$implicit;m.xp6(1),m.hij(" ",t.newTradeAction," ")}}function x(t,e){1&t&&(m.TgZ(0,"th",15),m._uU(1," Price "),m.qZA())}function _(t,e){if(1&t&&(m.TgZ(0,"td",16),m._uU(1),m.qZA()),2&t){const t=e.$implicit;m.xp6(1),m.hij(" ",t.price," ")}}function Y(t,e){1&t&&(m.TgZ(0,"th",15),m._uU(1," Pnl "),m.qZA())}function U(t,e){if(1&t&&(m.TgZ(0,"td",16),m._uU(1),m.qZA()),2&t){const t=e.$implicit;m.xp6(1),m.hij(" ",t.pnl," ")}}function q(t,e){1&t&&m._UZ(0,"tr",17)}function k(t,e){if(1&t){const t=m.EpF();m.TgZ(0,"tr",18),m.NdJ("click",function(){const e=m.CHM(t).$implicit;return m.oxw().selection.toggle(e)}),m.qZA()}}const Q=function(){return[5,10,25,100]},b=[{path:"",component:(()=>{class t{constructor(t){this.dataService=t,this.displayedColumns=["Model","Commodity","ContractDate","Contract","Positon","NewTradeAction","Price","Pnl"],this.historicaldata=[]}ngOnInit(){this.dataService.gethistoricaldata().subscribe(t=>{this.historicaldata=t,this.dataSource=new n.by(this.historicaldata),this.dataSource.paginator=this.paginator,this.dataSource.sort=this.sort}),this.selection=new d.Ov(!0,[])}ngAfterViewInit(){}applyFilter(t){this.dataSource.filter=t.trim().toLowerCase(),this.dataSource.paginator&&this.dataSource.paginator.firstPage()}isAllSelected(){return this.selection.selected.length===this.dataSource.data.length}masterToggle(){this.isAllSelected()?this.selection.clear():this.dataSource.data.forEach(t=>this.selection.select(t))}}return t.\u0275fac=function(e){return new(e||t)(m.Y36(f.D))},t.\u0275cmp=m.Xpm({type:t,selectors:[["app-tables"]],viewQuery:function(t,e){if(1&t&&(m.Gf(a.NW,7),m.Gf(c.YE,7)),2&t){let t;m.iGM(t=m.CRH())&&(e.paginator=t.first),m.iGM(t=m.CRH())&&(e.sort=t.first)}},decls:29,vars:7,consts:[["id","sample-table",1,"mat-elevation-z8","bg-white"],["mat-table","","matSort","",1,"w-100",3,"dataSource"],["matColumnDef","Model"],["mat-header-cell","","mat-sort-header","",4,"matHeaderCellDef"],["mat-cell","",4,"matCellDef"],["matColumnDef","Commodity"],["matColumnDef","ContractDate"],["matColumnDef","Contract"],["matColumnDef","Positon"],["matColumnDef","NewTradeAction"],["matColumnDef","Price"],["matColumnDef","Pnl"],["mat-header-row","",4,"matHeaderRowDef","matHeaderRowDefSticky"],["mat-row","",3,"click",4,"matRowDef","matRowDefColumns"],[3,"pageSize","pageSizeOptions"],["mat-header-cell","","mat-sort-header",""],["mat-cell",""],["mat-header-row",""],["mat-row","",3,"click"]],template:function(t,e){1&t&&(m.TgZ(0,"section",0),m.TgZ(1,"table",1),m.ynx(2,2),m.YNc(3,h,2,0,"th",3),m.YNc(4,p,2,1,"td",4),m.BQk(),m.ynx(5,5),m.YNc(6,g,2,0,"th",3),m.YNc(7,Z,2,1,"td",4),m.BQk(),m.ynx(8,6),m.YNc(9,C,2,0,"th",3),m.YNc(10,w,2,1,"td",4),m.BQk(),m.ynx(11,7),m.YNc(12,A,2,0,"th",3),m.YNc(13,T,2,1,"td",4),m.BQk(),m.ynx(14,8),m.YNc(15,D,2,0,"th",3),m.YNc(16,N,2,1,"td",4),m.BQk(),m.ynx(17,9),m.YNc(18,y,2,0,"th",3),m.YNc(19,S,2,1,"td",4),m.BQk(),m.ynx(20,10),m.YNc(21,x,2,0,"th",3),m.YNc(22,_,2,1,"td",4),m.BQk(),m.ynx(23,11),m.YNc(24,Y,2,0,"th",3),m.YNc(25,U,2,1,"td",4),m.BQk(),m.YNc(26,q,1,0,"tr",12),m.YNc(27,k,1,0,"tr",13),m.qZA(),m._UZ(28,"mat-paginator",14),m.qZA()),2&t&&(m.xp6(1),m.Q6J("dataSource",e.dataSource),m.xp6(25),m.Q6J("matHeaderRowDef",e.displayedColumns)("matHeaderRowDefSticky",!0),m.xp6(1),m.Q6J("matRowDefColumns",e.displayedColumns),m.xp6(1),m.Q6J("pageSize",10)("pageSizeOptions",m.DdM(6,Q)))},directives:[n.BZ,c.YE,n.w1,n.fO,n.Dz,n.as,n.nj,a.NW,n.ge,c.nU,n.ev,n.XQ,n.Gk],styles:[".mat-column-progress[_ngcontent-%COMP%]{max-width:40px}"]}),t})()}];let B=(()=>{class t{}return t.\u0275fac=function(e){return new(e||t)},t.\u0275mod=m.oAB({type:t}),t.\u0275inj=m.cJS({imports:[[u.Bz.forChild(b)],u.Bz]}),t})(),j=(()=>{class t{}return t.\u0275fac=function(e){return new(e||t)},t.\u0275mod=m.oAB({type:t}),t.\u0275inj=m.cJS({providers:[f.D],imports:[[o.ez,B,n.p0,r.lN,a.TU,c.JX,s.c,l.p9]]}),t})()}}]);