import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  path:string;
  constructor() {
     this.path="http://localhost:56028/api/";
   //this.path="http://localhost:8080/ReportingTasksPhp/Controllers/index.php/";
   }
}
