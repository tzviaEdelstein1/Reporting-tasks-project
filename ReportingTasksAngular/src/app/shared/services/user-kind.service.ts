import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserKind } from '../models/UserKind';

@Injectable({
  providedIn: 'root'
})
export class UserKindService {

  constructor(private http:HttpClient) { }

  GetAllKinds():Observable<UserKind[]>  {
   
    return this.http.get("http://localhost:56028/api/UserKinds")
    .map((res:UserKind[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }
}
