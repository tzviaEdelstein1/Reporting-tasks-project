import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TreeTable } from '../models/TreeTable';

@Injectable({
  providedIn: 'root'
})
export class TreeTableService {
  constructor(private http: HttpClient) { }
  GetTreeTable():Observable<TreeTable[]>  { 

  // return this.http.get("http://localhost:56028/api/TreeTable")
  return this.http.get("http://localhost:8080/ReportingTasksPhp/Controllers/index.php/treeTable/GetTreeTable")
    .map((res:TreeTable[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));
  }
}
