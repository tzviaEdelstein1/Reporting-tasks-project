import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { WorkerToProject } from '../models/WorkerToProject';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { Project } from '../models/Project';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root'
})
export class WorkerToProjectService {

  
  constructor(private http: HttpClient,private globalService:GlobalService) { }

  AddWorkerToProject(workerToProject: WorkerToProject, userId: number) {
    return this.http.post(this.globalService.path+"WorkerToProject/AddWorkerToProject/" + userId, workerToProject);
  }


  GetProjectsByWorkerName(userName: string): Observable<Project[]> {

    return this.http.get(this.globalService.path+"WorkerToProject/GetProjectsbyUserName/" + userName)
      .map((res: Project[]) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));

  }


  GetWorkerToProjectByPidAndUid(userId: number, projectId: number): Observable<WorkerToProject> {
    return this.http.get(this.globalService.path+"WorkerToProject/GetWorkerToProjectByPidAndUid/"+projectId +"/"+userId)
      .map((res: WorkerToProject) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));

  }

  EditWorkerToProject(workerToProject: WorkerToProject) {
    return this.http.put(this.globalService.path+"WorkerToProject/UpdateWorkerToProject", workerToProject);
  }
  Get( teamId:number): Observable<WorkerToProject[]>{
    debugger;
    return this.http.get(this.globalService.path+"WorkerToProject/GetWorkersHoursByTeam/"+teamId)
    .map((res: WorkerToProject[]) => res)
    .catch((r: HttpErrorResponse) => Observable.throw(r));
  
  }
  



}