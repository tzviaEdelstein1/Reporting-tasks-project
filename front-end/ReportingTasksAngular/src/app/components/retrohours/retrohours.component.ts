import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/User';
import { UserService } from 'src/app/shared/services/user.service';
import { Project } from 'src/app/shared/models/Project';
import { WorkerToProject } from 'src/app/shared/models/WorkerToProject';
import { WorkerToProjectService } from 'src/app/shared/services/worker-to-project.service';
import { FormGroup, FormControl } from '@angular/forms';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-retrohours',
  templateUrl: './retrohours.component.html',
  styleUrls: ['./retrohours.component.css']
})
export class RetrohoursComponent implements OnInit {

  workers: User[] = [];
  allWorkersToProject: WorkerToProject[] = [];
  selectedWorker: User;
  workerprojects: WorkerToProject[] = [];
  selectedProject: Project;
  selectedWorkerToProject: WorkerToProject;
  formGroup: FormGroup;
  obj: typeof Object = Object;
  sumAllActual: number = 0;
  flagHours: boolean;
  selectedWorkerName: string;
  workersName: WorkerToProject[] = [];
  selectedObj: any;
  constructor(private userservice: UserService, private workertoprojectService: WorkerToProjectService) {
    this.selectedWorkerToProject=new WorkerToProject();
   }

  ngOnInit() {
    this.workertoprojectService.Get(Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res => {
      debugger;
      this.allWorkersToProject = res;
      for (var i = 0; i < this.allWorkersToProject.length; i++) {
        for (var j = 0; j < this.workersName.length; j++) {
          if (this.allWorkersToProject[i].User.UserName== this.workersName[j].User.UserName) {
           break;
          }
        }
        if (j == this.workersName.length) {
          this.workersName.push(this.allWorkersToProject[i]);
        }
      }
    });
    let formGroupConfig = {
      hours: new FormControl(""),
      project:new FormControl(""),
      worker:new FormControl("")

    };

    this.formGroup = new FormGroup(formGroupConfig);
  }
  selectWorker(event) {
    this.formGroup.controls['hours'].setValue(" ");
    this.formGroup.controls['project'].setValue("select project");
this.selectedWorkerToProject.UserId=event.target.value;
    this.workerprojects = this.allWorkersToProject.filter(work => work.UserId == this.selectedWorkerToProject.UserId);
  }

  selectProject(event) {
 this.selectedWorkerToProject.ProjectId=event.target.value;
    var worker = this.allWorkersToProject.find(worker => worker.ProjectId == this.selectedWorkerToProject.ProjectId && worker.UserId == this.selectedWorkerToProject.UserId );
    this.formGroup.controls['hours'].setValue(worker.Hours);
  }

  onSubmit() {
    // this.sumAllActual = 0;
      // this.flagHours = false;
      // let kindId = this.selectedWorker.UserKindId;
      // this.allWorkersToProject = this.allWorkersToProject.filter(p => p.ProjectId == this.selectedProject.ProjectId);

      // this.allWorkersToProject.forEach(element => {

      //   this.userservice.GetUserById(element.UserId).subscribe(res => {

      //     if (res.UserKindId == kindId && res.UserId != this.selectedWorker.UserId)
      //       this.sumAllActual += element.Hours;
      //   })

      // });
      // this.selectedWorkerToProject.Hours = this.formGroup.value.hours;
      // switch (kindId) {
      //   case 3:
      //     debugger;
      //     if (this.selectedProject.DevelopersHours < this.sumAllActual + this.formGroup.value.hours) {
      //       alert("Exceeded the hours allotted for development for this project");
      //       this.flagHours = true;
      //     }
      //     break;
      //   case 4:
      //     if (this.selectedProject.QaHours < this.sumAllActual + this.formGroup.value.hours) {
      //       alert("Exceeded the hours allotted for QA for this project");
      //       this.flagHours = true;
      //     }
      //     break;
      //   case 5:
      //     if (this.selectedProject.UiUxHours < this.sumAllActual + this.formGroup.value.hours) {
      //       alert("Exceeded the hours allotted for Ui/Ux for this project");
      //       this.flagHours = true;
      //     }
      //     break;
      // }
      // if (this.flagHours == false)
      this.selectedWorkerToProject.Hours=this.formGroup.controls['hours'].value;
      this.selectedWorkerToProject.WorkerToProjectId=this.allWorkersToProject.find(worker=>worker.ProjectId==this.selectedWorkerToProject.ProjectId&&worker.UserId==this.selectedWorkerToProject.UserId).WorkerToProjectId
        this.workertoprojectService.EditWorkerToProject(this.selectedWorkerToProject).subscribe(res => { alert("Update succees!!") });
  }
}
