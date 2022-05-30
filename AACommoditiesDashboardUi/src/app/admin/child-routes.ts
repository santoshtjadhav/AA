export const childRoutes = [
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard.module').then(m => m.DashboardModule),
    data: { icon: 'dashboard', text: 'key metrics' }
  },
  {
    path: 'charts',
    loadChildren: () =>
      import('./charts/charts.module').then(m => m.ChartsModule),
    data: { icon: 'bar_chart', text: 'Historical trend ' }
   }  ,
   {
     path: 'tables',
     loadChildren: () =>
       import('./tables/tables.module').then(m => m.TablesModule),
     data: { icon: 'table_chart', text: 'Historical Data (Can use last 5 days)' }
   }
];
