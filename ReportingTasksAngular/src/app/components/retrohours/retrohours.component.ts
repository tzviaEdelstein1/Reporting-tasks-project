import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/User';
import { UserService } from 'src/app/shared/services/user.service';
import { Project } from 'src/app/shared/models/Project';
import { WorkerToProject } from 'src/app/shared/models/WorkerToProject';
import { WorkerToProjectService } from 'src/app/shared/services/worker-to-project.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-retrohours',
  templateUrl: './retrohours.component.html',
  styleUrls: ['./retrohours.component.css']
})
export class RetrohoursComponent implements OnInit {

  workers: User[] = [];
  selectedWorker: User;
  projects: Project[] = [];
  selectedProject: Project;
  selectedWorkerToProject: WorkerToProject;
  formGroup: FormGroup;
  obj: typeof Object = Object;
  constructor(private userservice: UserService, private workertoprojectService: WorkerToProjectService) { }

  ngOnInit() {
    this.userservice.GetUsersByTeamLeaderId(Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res => { this.workers = res });
    let formGroupConfig = {
      hours: new FormControl(""),

    };

    this.formGroup = new FormGroup(formGroupConfig);
  }
  selectWorker(event) {

    this.selectedWorker = this.workers.find(p => p.UserName == event.target.value);
    this.workertoprojectService.GetProjectsByWorkerName(this.selectedWorker.UserName).subscribe(res => { this.projects = res });

  }

  selectProject(event) {
    this.selectedProject = this.projects.find(p => p.ProjectName = event.target.value);
    this.workertoprojectService.GetWorkerToProjectByPidAndUid(this.selectedWorker.UserId, this.selectedProject.ProjectId).subscribe(res => {
      console.log("hours", res);
      this.selectedWorkerToProject = res;
      console.warn(this.selectedWorkerToProject.Hours);
      this.formGroup.controls['hours'].setValue(this.selectedWorkerToProject.Hours);

    })
  }

  onSubmit() {
debugger;
try {
this.selectedWorkerToProject.Hours=this.formGroup.value.hours;
this.workertoprojectService.EditWorkerToProject(this.selectedWorkerToProject).subscribe(res=>{alert("Update succees!!")});
}
catch{
  alert("Update Failed")
}
  }
}
