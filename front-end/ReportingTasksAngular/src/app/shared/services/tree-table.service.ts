import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TreeTable } from '../models/TreeTable';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root'
})
export class TreeTableService {

  constructor(private http: HttpClient,private globalService:GlobalService) { }


  GetTreeTable():Observable<TreeTable[]>  { 
    debugger;
  // return this.http.get("http://localhost:56028/api/TreeTable")
  return this.http.get(this.globalService.path+"TreeTable/GetTreeTable")
    .map((res:TreeTable[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

}
