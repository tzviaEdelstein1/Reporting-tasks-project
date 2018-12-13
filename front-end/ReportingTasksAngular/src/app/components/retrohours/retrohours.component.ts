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
  allWorkersToProject: WorkerToProject[] = [];
  selectedWorker: User;
  projects: Project[] = [];
  selectedProject: Project;
  selectedWorkerToProject: WorkerToProject;
  formGroup: FormGroup;
  obj: typeof Object = Object;
  sumAllActual: number = 0;
  flagHours: boolean;

  constructor(private userservice: UserService, private workertoprojectService: WorkerToProjectService) { }

  ngOnInit() {
    this.workertoprojectService.Get().subscribe(res => { this.allWorkersToProject = res; });
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
    this.sumAllActual = 0;

    try {
      this.flagHours = false;
      let kindId =this.selectedWorker.UserKindId;
      this.allWorkersToProject = this.allWorkersToProject.filter(p => p.ProjectId == this.selectedProject.ProjectId);

      this.allWorkersToProject.forEach(element => {

        this.userservice.GetUserById(element.UserId).subscribe(res => {

          if (res.UserKindId == kindId && res.UserId != this.selectedWorker.UserId)
            this.sumAllActual += element.Hours;
        })

      });
      this.selectedWorkerToProject.Hours = this.formGroup.value.hours;
      switch (kindId) {
        case 3:
        debugger;
          if (this.selectedProject.DevelopersHours < this.sumAllActual + this.formGroup.value.hours) {
            alert("Exceeded the hours allotted for development for this project");
            this.flagHours = true;
          }
          break;
        case 4:
          if (this.selectedProject.QaHours < this.sumAllActual + this.formGroup.value.hours) {
            alert("Exceeded the hours allotted for QA for this project");
            this.flagHours = true;
          }
          break;
        case 5:
          if (this.selectedProject.UiUxHours < this.sumAllActual + this.formGroup.value.hours) {
            alert("Exceeded the hours allotted for Ui/Ux for this project");
            this.flagHours = true;
          }
          break;
      }
      if (this.flagHours == false)
        this.workertoprojectService.EditWorkerToProject(this.selectedWorkerToProject).subscribe(res => { alert("Update succees!!") });
    }
    catch{
      alert("Update suucessed")
    }
  }
}
