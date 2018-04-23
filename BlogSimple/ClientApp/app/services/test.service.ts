import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable()
export class TestService {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
    //  console.log(result);
    //}, error => console.error(error));
    alert(456);
  }
  public testFunction() {
    alert(623);
  }

}