﻿import 'rxjs/add/observable/of';
import { Injectable } from '@angular/core';
import { PreloadingStrategy, Route } from '@angular/router';
import { Observable } from "rxjs/Observable";

export class SelectivePreloadingStrategy implements PreloadingStrategy {
   preloadedModules: string[] = [];
  preload(route: Route, fn: () => Observable<any>): Observable<any> {
    if (route.data && route.data["preload"])
    {
      this.preloadedModules.push(JSON.stringify(route.path));
      return fn();
    }
    else
    {
      return Observable.of(null);
    }
  }

}