import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserKind } from '../models/UserKind';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root'
})
export class UserKindService {

  constructor(private http:HttpClient,private globalService:GlobalService) { }

  GetAllKinds():Observable<UserKind[]>  {
    return this.http.get(this.globalService.path+"UserKinds/Get")
    .map((res:UserKind[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }
}
