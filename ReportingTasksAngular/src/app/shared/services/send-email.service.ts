import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SendEmailService {

  constructor(private http:HttpClient) { }


  SendEmail(body:string)  {
   
    return this.http.get("http://localhost:8080/ReportingTasksPhp/Controllers/index.php/SendEmail/SendEmail/"+body);
 

  }
  
}
