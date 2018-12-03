import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActualHours } from '../models/ActualHours';
import { Observable, Subject } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HoursService {

  constructor(private http: HttpClient) { }
  subject = new Subject();
  GetHoursByProjectId(projectId: number): Observable<ActualHours[]> {

    return this.http.get("http://localhost:56028/api/GetActualHoursByProjectId/" + projectId)
      .map((res: ActualHours[]) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));

  }

  AddActualHours(actual: ActualHours): Observable<ActualHours> {
    return this.http.post("http://localhost:56028/api/Hours/"+Number.parseInt(localStorage.getItem("currentUser")), actual).map((res: ActualHours) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));;;
  }

}
