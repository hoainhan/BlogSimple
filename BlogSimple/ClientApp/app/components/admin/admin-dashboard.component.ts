import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { Observable } from 'rxjs/Observable'
import { SelectivePreloadingStrategy } from '../selective-preloading-strategy'
import 'rxjs/add/operator/map';
@Component({
  template: `
    <p>Dashboard</p>

    <p>Session ID: {{ sessionId | async }}</p>
    <a id="anchor"></a>
    <p>Token: {{ token | async }}</p>

    Preloaded Modules
    <ul>
      <li *ngFor="let module of modules">{{ module }}</li>
    </ul>
  `
})
export class AdminDashboardComponent implements OnInit {
  private sessionId: Observable<string> = Observable.of("");
  private token: Observable<string> = Observable.of("");
  modules: string[];
  constructor(private route: ActivatedRoute, private preloadStrategy: SelectivePreloadingStrategy) {
    this.modules = this.preloadStrategy.preloadedModules;
  }
  ngOnInit(): void {
    // Capture the session ID if available
    this.sessionId = this.route
      .queryParamMap
      .map(params => params.get('session_id') || 'None');

    // Capture the fragment if available
    this.token = this.route
      .fragment
      .map(fragment => fragment || 'None');
  }
}

