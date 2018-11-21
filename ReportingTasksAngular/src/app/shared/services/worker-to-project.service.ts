import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { WorkerToProject } from '../models/WorkerToProject';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { Project } from '../models/Project';
@Injectable({
  providedIn: 'root'
})
export class WorkerToProjectService {
  constructor(private http: HttpClient) { }

  AddWorkerToProject(workerToProject: WorkerToProject, userId: number) {
    return this.http.post("http://localhost:56028/api/WorkerToProject/" + userId, workerToProject);
  }
  GetWorkersByProjectId(projectId: number): Observable<User[]> {

    return this.http.get("http://localhost:56028/api/WorkerToProject/GetWorkerbyProjectName/" + projectId)
      .map((res: User[]) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));

  }

  GetProjectsByWorkerName(userName: string): Observable<Project[]> {

    return this.http.get("http://localhost:56028/api/WorkerToProject/GetProjectsbyUserName/" + userName)
      .map((res: Project[]) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));

  }

  GetWorkersToProjectByProjectId(projectId: number): Observable<WorkerToProject[]> {

    return this.http.get("http://localhost:56028/api/WorkerToProject/GetWorkersToProjectByProjectId/" + projectId)
      .map((res: WorkerToProject[]) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));
  }

  GetWorkerToProjectByPidAndUid(userId: number, projectId: number): Observable<WorkerToProject> {
    return this.http.get("http://localhost:56028/api/WorkerToProject/GetWorkerToProjectByPidAndUid/" + userId + "/" + projectId)
      .map((res: WorkerToProject) => res)
      .catch((r: HttpErrorResponse) => Observable.throw(r));

  }
  EditWorkerToProject(workerToProject: WorkerToProject) {

    return this.http.put("http://localhost:56028/api/WorkerToProject", workerToProject);

  }
}
