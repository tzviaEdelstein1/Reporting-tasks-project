import { Injectable } from '@angular/core';
import { Project } from '../models/Project';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HelpProjectsAndHours } from '../models/HelpProjectsAndHours';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http:HttpClient) { }

  AddProject(project:Project,userId:number):Observable<Project>{
    debugger;
    return this.http.post("http://localhost:56028/api/Projects/"+userId,project) .map((res:Project)=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));;
  }
  GetAllProjects():Observable<Project[]>{
    return this.http.get("http://localhost:56028/api/Projects")
    .map((res:Project[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));
  }
  GetProjectsByTeamLeaderId(teamLeaderId:number):Observable<Project[]>  {
   
    return this.http.get("http://localhost:56028/api/Projects/"+teamLeaderId)
    .map((res:Project[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

  GetWorkersAndHoursByProjectId(projectId:number):Observable<HelpProjectsAndHours[]> {
   
    return this.http.get("http://localhost:56028/api/Projects/GetProjectsAndHoursByProjectId/"+projectId)
    .map((res:HelpProjectsAndHours[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }
  GetProjectsAndHoursByUserId(userId:number):Observable<HelpProjectsAndHours[]>{
    return this.http.get("http://localhost:56028/api/Projects/GetProjectsAndHoursByUserId/"+userId)
    .map((res:HelpProjectsAndHours[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));
   
  }


  //api/Projects/GetProjectsAndHoursByTeamLeaderId/{teamLeaderId}

  GetProjectsAndHoursByTeamLeaderId(teamLeaderId:number):Observable<HelpProjectsAndHours[]>{

    return this.http.get("http://localhost:56028/api/Projects/GetProjectsAndHoursByTeamLeaderId/"+teamLeaderId)
    .map((res:HelpProjectsAndHours[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));   
  }
  GetProjectsAndHoursByUserIdAccordingTheMonth(userId:number):Observable<HelpProjectsAndHours[]>{

    return this.http.get("http://localhost:56028/api/Projects/GetProjectsAndHoursByUserIdAccordingTheMonth/"+userId)
    .map((res:HelpProjectsAndHours[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));   
  }
 


}





