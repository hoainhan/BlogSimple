import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { SelectivePreloadingStrategy } from "./components/selective-preloading-strategy";
import { AuthGuard } from './components/auth-guard.service';

const appRoutes: Routes = [
    { path: '', redirectTo: 'managercategory', pathMatch: 'full' },
    {
        path: 'managercategory',
        loadChildren: "../app/components/managercategory/managercategory.module#CategoryModule",
        data: { preload: true },
        canLoad: [AuthGuard]
    },
    {
        path: 'managerblogpost',
        loadChildren: '../app/components/managerblogpost/blogpost.module#BlogPostModule',
        data: {preload:true}
    },
  { path: '**', redirectTo: 'managercategory' }
]

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent
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
