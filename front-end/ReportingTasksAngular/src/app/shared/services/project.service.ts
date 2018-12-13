import { Injectable } from '@angular/core';
import { Project } from '../models/Project';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HelpProjectsAndHours } from '../models/HelpProjectsAndHours';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http:HttpClient,private globalService:GlobalService) { }

  GetAllProjects():Observable<Project[]>{
   
   return this.http.get(this.globalService.path+"Projects/GetAllProjects")
    .map((res:Project[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));
  }

  GetActiveProjects(){

    return this.http.get(this.globalService.path+"Projects/GetActiveProjects")
    .map((res:Project[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

    
  }
  GetProjectsByTeamLeaderId(teamLeaderId:number):Observable<Project[]>  {
   debugger;
  
    return this.http.get(this.globalService.path+"Projects/GetProjectsByTeamId/"+teamLeaderId)
    .map((res:Project[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

  GetWorkersAndHoursByProjectId(projectId:number):Observable<HelpProjectsAndHours[]> {
   
 
    return this.http.get(this.globalService.path+"Projects/GetProjectsAndHoursByProjectId/"+projectId)
    .map((res:HelpProjectsAndHours[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }
  GetProjectsAndHoursByUserId(userId:number):Observable<HelpProjectsAndHours[]>{

    return this.http.get(this.globalService.path+"Projects/GetProjectsAndHoursByUserId/"+userId)
    .map((res:HelpProjectsAndHours[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));
   
  }

  GetProjectsAndHoursByTeamLeaderId(teamLeaderId:number):Observable<HelpProjectsAndHours[]>{
    return this.http.get(this.globalService.path+"Projects/GetProjectsAndHoursByTeamLeaderId/"+teamLeaderId)
    .map((res:HelpProjectsAndHours[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));   
  }
  GetProjectsAndHoursByUserIdAccordingTheMonth(userId:number):Observable<HelpProjectsAndHours[]>{
    return this.http.get(this.globalService.path+"Projects/GetProjectsAndHoursByUserIdAccordingTheMonth/"+userId)
    .map((res:HelpProjectsAndHours[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));   
  }
UpdateProject(project:Project,id:number)
{
  return this.http.put(this.globalService.path+"Projects/UpdateProject/"+id,project);
}


AddProject(project:Project,userId:number):Observable<any>{
  debugger;

  return this.http.post(this.globalService.path+"Projects/AddProject/"+userId,project).map((res:Project)=>res)
  .catch((r:any)=>"e");
}
  

}