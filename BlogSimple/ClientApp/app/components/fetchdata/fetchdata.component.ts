import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { TestService } from "../../services/test.service";
import { OnInit } from '@angular/core';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent implements OnInit {
  
   // public forecasts: WeatherForecast[];

    constructor(private testService: TestService) {
      
    }
    ngOnInit(): void {
     this.testService.testFunction();
    }

}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
