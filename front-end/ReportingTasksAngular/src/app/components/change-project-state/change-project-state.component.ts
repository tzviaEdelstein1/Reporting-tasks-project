import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/shared/models/Project';
import { ProjectService } from 'src/app/shared/services/project.service';

@Component({
  selector: 'app-change-project-state',
  templateUrl: './change-project-state.component.html',
  styleUrls: ['./change-project-state.component.css']
})
export class ChangeProjectStateComponent implements OnInit {
  projects: Project[] = [];
  projectsToUpdate: number[] = [];
  valuesToUpdate:string[]=[];
  flag: boolean;
  constructor(private projectservice: ProjectService) { }

  ngOnInit() {
    this.projectservice.GetAllProjects().subscribe(res => { this.projects = res });
    this.flag = true;
  }
  state: any;

  changeState(itemId: number) {
debugger;
    let project = this.projects.find(p => p.ProjectId == itemId);
    console.log("project", project);
    this.state = project.IsActive;
   this.projectsToUpdate.push(project.ProjectId);
   let state=this.state==0?"1":"0";
   this.valuesToUpdate.push(state);
   
  }


  Update() {

for(var i=0;i<this.projectsToUpdate.length;i++)
{
debugger;
 var p=new Project();
  p=this.projects.find(r=>r.ProjectId==this.projectsToUpdate[i]);
  p.IsActive=this.valuesToUpdate[i];
  p.User=null;
  this.projectservice.UpdateProject(p,Number.parseInt(localStorage.getItem("currentUser")))
  .subscribe(res=>{debugger;alert("Changes were saved successfully ")});
}
  }
}
