import { Injectable } from '@angular/core';
import {
  CanActivate, Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  CanActivateChild,
  NavigationExtras,
  CanLoad, Route
} from '@angular/router';
import { AuthService } from './auth.service';
import { Observable } from "rxjs/Observable";

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad
{
  constructor(private authService: AuthService, private route: Router) {

  }
  canLoad(route: Route): boolean | Observable<boolean> | Promise<boolean> {
      var url = `/${route.path}`;
    return this.checkLogin(url);
  }
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
    return this.canActivate(childRoute, state);
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
    let url: string = state.url;
    return this.checkLogin(url);
  }
  checkLogin(url: string): boolean {
    //if (this.authService.isLoggedIn) { return true; }

    //// Store the attempted URL for redirecting
    //this.authService.redirectUrl = url;

    //// Create a dummy session id
    //let sessionId = 123456789;

    //// Set our navigation extras object
    //// that contains our global query params and fragment
    //let navigationExtras: NavigationExtras = {
    //  queryParams: { 'session_id': sessionId },
    //  fragment: 'anchor'
    //};

    //// Navigate to the login page with extras
    //this.route.navigate(['/login'], navigationExtras);
    return true;
  }


}