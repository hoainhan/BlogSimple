import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { SelectivePreloadingStrategy } from "./components/selective-preloading-strategy";
import { CategoryComponent } from "./components/category/category.component"


const appRoutes: Routes = [
  { path: '', redirectTo: 'category', pathMatch: 'full' },
  { path: 'category', component: CategoryComponent },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  {
    path: 'test-child', 
    loadChildren: "../app/components/admin/admin.module#AdminModule",
    data: { preload: true }
  },
  { path: '**', redirectTo: 'category' }
]

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
      HomeComponent,
      CategoryComponent
    ],
    imports: [
      CommonModule,
        HttpModule,
      FormsModule,
      HttpClientModule,
      RouterModule.forRoot(
        appRoutes,
        {
          enableTracing:true,
          preloadingStrategy: SelectivePreloadingStrategy
        }
        )
        
    ],
    exports: [RouterModule]
})
export class AppModuleShared {
}
