import { Component, OnInit } from '@angular/core';
import { Project } from '../../shared/models/Project';
import { ProjectService } from '../../shared/services/project.service';
import { User } from '../../shared/models/User';
import { WorkerToProjectService } from '../../shared/services/worker-to-project.service';
import { ActualHours } from '../../shared/models/ActualHours';
import { HoursService } from '../../shared/services/hours.service';
import { WorkerToProject } from '../../shared/models/WorkerToProject';
import { HelpProjectsAndHours } from 'src/app/shared/models/HelpProjectsAndHours';

@Component({
  selector: 'app-projects-state',
  templateUrl: './projects-state.component.html',
  styleUrls: ['./projects-state.component.css']
})
export class ProjectsStateComponent implements OnInit {
  yourProjects:Project[]=[];
  selectetProject:Project;
  usrsForProject:User[]=[];
  actualHoursForProject:ActualHours[]=[];
 allWorkerToThisProject:WorkerToProject[]=[];


 workersAndHours:HelpProjectsAndHours[]=[];
  constructor(private projectservice:ProjectService,private workertoprojectservice:WorkerToProjectService,private hoursservice:HoursService) { 
    this.selectetProject=new Project();

  }

  ngOnInit() {
    this.projectservice.GetProjectsByTeamLeaderId(Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res=>{this.yourProjects=res});
  }

  selectProject(event){
   
   this.selectetProject=this.yourProjects.find(p=>p.ProjectName==event.target.value);
//    this.workertoprojectservice.GetWorkersByProjectId(this.selectetProject.ProjectId).subscribe(res=>{this.usrsForProject=res});//כל העובדים
//    this.hoursservice.GetHoursByProjectId(this.selectetProject.ProjectId).subscribe(res=>{this.actualHoursForProject=res});//כל השעות בפועל
//  this.workertoprojectservice.GetWorkersToProjectByProjectId(this.selectetProject.ProjectId).subscribe(res=>{this.allWorkerToThisProject=res});// כל הקשרים של עובדים לפרויקט בשביל לשלוף רת השעות שהוקצו לו
this.projectservice.GetWorkersAndHoursByProjectId(this.selectetProject.ProjectId).subscribe(res=>{this.workersAndHours=res;console.log("hours",this.workersAndHours)})
   
  }

}
