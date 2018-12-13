import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root'
})
export class SendEmailService {

  constructor(private http:HttpClient,private globalService:GlobalService) { }


  SendEmail(body:string)  {
   
    return this.http.get(this.globalService.path+"SendEmail/SendEmail/"+body);
 

  }
  
}
