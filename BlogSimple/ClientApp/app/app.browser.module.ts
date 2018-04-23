import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TestService } from "./services/test.service";
import { AuthGuard } from '../app/components/auth-guard.service'
import { AuthService } from '../app/components/auth.service'
import { SelectivePreloadingStrategy } from '../app/components/selective-preloading-strategy'
import { httpInterceptorProviders } from '../app/components/httpinterceptors/index'

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
      AppModuleShared,
      BrowserAnimationsModule
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
      TestService,
      AuthGuard,
      AuthService,
      SelectivePreloadingStrategy,
      httpInterceptorProviders
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
