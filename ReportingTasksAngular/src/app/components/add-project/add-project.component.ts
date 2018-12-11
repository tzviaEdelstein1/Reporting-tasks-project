import { Component, OnInit } from '@angular/core';

import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';
import { Project } from '../../shared/models/Project';
import { User } from '../../shared/models/User';
import { UserService } from '../../shared/services/user.service';
import { ProjectService } from '../../shared/services/project.service';
import { WorkerToProjectService } from '../../shared/services/worker-to-project.service';
import { WorkerToProject } from '../../shared/models/WorkerToProject';
import {MessageService} from 'primeng/api';
@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {

  newProject: Project;
  formGroup: FormGroup;
  obj: typeof Object = Object;

  allUsers: User[] = [];
  teamLeaders: User[] = [];
  usersToAdd: User[] = [];
  teamLeaderId: number;
  currentId: number;
  checkboxes: any[] = [];
  constructor(private userservice: UserService, private projectService: ProjectService, private workerToProjectService: WorkerToProjectService,private messageService: MessageService) {

    let formGroupConfig = {
      ProjectName: new FormControl("", this.createValidatorArr("ProjectName", 3, 15)),
      ClientName: new FormControl("", this.createValidatorArr("ClientName", 3, 15)),
      TeamLeader: new FormControl("", this.createValidatorArr("TeamLeader", 3, 15)),
      DevelopersHours: new FormControl("", this.createValidatorArr("DevelopersHours", 0, 1000)),
      QAhours: new FormControl("", this.createValidatorArr("QAhours", 0, 1000)),
      UiUxHours: new FormControl("", this.createValidatorArr("UiUxHours", 0, 1000)),
      BeginingDate: new FormControl("", this.createValidatorArr("BeginingDate", 0, 1000)),
      FinishDate: new FormControl("", this.createValidatorArr("FinishDate", 0, 1000)),
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    this.userservice.GetAllUsers().subscribe(res => { this.allUsers = res; console.warn("all", this.allUsers) });
    this.userservice.GetTeamLeaders().subscribe(res => {
      this.teamLeaders = res;
      console.warn("leaders", this.teamLeaders);

    });

  }
  createValidatorArr(cntName: string, min: number, max: number): Array<ValidatorFn> {
    return [
      f => !f.value ? { "val": `${cntName} is required` } : null,
      f => f.value && f.value.length > max ? { "val": `${cntName} is max ${max} chars` } : null,
      f => f.value && f.value.length < min ? { "val": `${cntName} is min ${min} chars` } : null
    ];
  }

  FillUsersToAdd() {
    debugger;
    this.teamLeaderId = this.allUsers.find(t => t.UserName == this.formGroup.value["TeamLeader"]).UserId;
    console.log("team", this.teamLeaderId);
    this.usersToAdd = this.allUsers.filter(u => u.UserId != this.teamLeaderId && u.TeamLeaderId != this.teamLeaderId && u.UserKindId != 1);
  }



  addCheckedWorker(event) {
    debugger;
    console.warn("event", event);

    if (event.target.checked == true)
      this.checkboxes.push(event.target.value);

  }
  starterror: any = { isError: false, errorMessage: '' };
  error: any = { isError: false, errorMessage: '' };
  ValidateStartDate() {
    debugger;
    const today=new Date();
    if (new Date(this.formGroup.controls['BeginingDate'].value) < new Date(today.setDate(today.getDate()-1))) {
      this.starterror = {
        isError: true, errorMessage: 'Start Date cant before today'
      }
    }
    else {
      this.starterror = {
        isError: false, errorMessage: ''

      }
    }
  }
  ValidateDates() {
    debugger;
    if (new Date(this.formGroup.controls['BeginingDate'].value) > new Date(this.formGroup.controls['FinishDate'].value)) {
      this.error = {
        isError: true, errorMessage: 'End Date cant before start date'
      };
    }
    else {
      this.error = {
        isError: false, errorMessage: ''

      }
    }
  }
  workerToProject: WorkerToProject;
  Submit() {
    debugger;
    
    this.currentId = Number.parseInt(localStorage.getItem("currentUser"));
    console.log("currentId", this.currentId);
    console.log("this.formGroup.value.ProjectName", this.formGroup.value.ProjectName);
    this.newProject = new Project();
    this.newProject.ProjectName = this.formGroup.value.ProjectName;
    this.newProject.ClientName = this.formGroup.value.ClientName;
    if (this.formGroup.value.TeamLeader)
      this.newProject.TeamLeaderId = this.allUsers.find(u => u.UserName == this.formGroup.value.TeamLeader).UserId;
    else
      this.newProject.TeamLeaderId = 0;
    this.newProject.DevelopersHours = this.formGroup.value.DevelopersHours;
    this.newProject.QaHours = this.formGroup.value.QAhours;
    this.newProject.UiUxHours = this.formGroup.value.UiUxHours;
    this.newProject.StartDate = this.formGroup.value.BeginingDate;
    this.newProject.FinishDate = this.formGroup.value.FinishDate;

    console.log("newproj", this.newProject);

    this.projectService.AddProject(this.newProject, this.currentId).subscribe(res => {
      console.log("res", res);
      this.showSuccess();
      if (this.checkboxes) {
        this.checkboxes.forEach(ch => {
          this.workerToProject = new WorkerToProject();
          this.workerToProject.ProjectId = res.ProjectId;
          this.workerToProject.UserId = Number.parseInt(ch);
          this.workerToProject.Hours = 0;
          this.workerToProjectService.AddWorkerToProject(this.workerToProject, Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res => console.log("res2", res))
        });
      }
    });

  }
  showSuccess() {
    this.messageService.add({severity:'success', summary: 'Success Message', detail:'Project successfully added'});
}
}
