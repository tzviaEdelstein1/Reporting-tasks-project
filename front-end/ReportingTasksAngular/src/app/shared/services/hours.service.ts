import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActualHours } from '../models/ActualHours';
import { Observable, Subject } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root'
})
export class HoursService {

  constructor(private http: HttpClient, private globalService: GlobalService) { }
  subject = new Subject();

  AddActualHours(actual: ActualHours): Observable<any> {
    debugger;

    return this.http.post(this.globalService.path+"ActualHours/AddActualHours/" + Number.parseInt(localStorage.getItem("currentUser")), actual)
    .map((res: any) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));;;
  }

}
