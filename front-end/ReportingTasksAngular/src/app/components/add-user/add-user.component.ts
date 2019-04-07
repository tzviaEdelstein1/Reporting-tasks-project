import { Component, OnInit } from '@angular/core';
import { User } from '../../shared/models/User';
import { UserService } from '../../shared/services/user.service';
import { UserKind } from '../../shared/models/UserKind';
import { UserKindService } from '../../shared/services/user-kind.service';
import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';
import sha256 from 'async-sha256';
import { WorkerToProjectService } from 'src/app/shared/services/worker-to-project.service';
import { MessageService } from 'primeng/api';
@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  teamLeaders: User[] = [];
  userKinds: UserKind[] = [];


  formGroup: FormGroup;
  obj: typeof Object = Object;
  newUser: User;

  constructor(private userservice: UserService, private userkindservice: UserKindService, private workerToProjectService: WorkerToProjectService, private messageService: MessageService) {


    let formGroupConfig = {

      UserName: new FormControl("", this.createValidatorArr("UserName", 3, 15)),
      UserEmail: new FormControl("", this.createValidatorArr("UserEmail", 4, 1000)),
      Password: new FormControl("", this.createValidatorArr("Password", 6, 10)),
      TeamLeaderId: new FormControl(""),
      UserKindId: new FormControl("", this.createValidatorArr("UserKindId", 0, 1000)),
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }
  emptyTeam: User;
  ngOnInit() {


    // this.emptyTeam = new User();
    // this.emptyTeam.TeamLeaderId = 0;
    // this.emptyTeam.UserName = "";
    // this.teamLeaders.push(this.emptyTeam);
    this.userservice.GetTeamLeaders().subscribe(res => {
      res.forEach(element => {
        this.teamLeaders.push(element);
      });


    });
    this.userkindservice.GetAllKinds().subscribe(res => {
 this.userKinds = res;
    
      // this.userKinds= this.userKinds.filter(res=>res.KindUserName!="manager"); 
    });

  }


  createValidatorArr(cntName: string, min: number, max: number): Array<ValidatorFn> {
    var EMAIL_REGEXP = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return [
      f => cntName == "UserEmail" && !EMAIL_REGEXP.test(f.value) ? { "val": `${cntName} is not valid` } : null,
      f => !f.value ? { "val": `${cntName} is required` } : null,
      f => f.value && f.value.length > max ? { "val": `${cntName} is max ${max} chars` } : null,
      f => f.value && f.value.length < min ? { "val": `${cntName} is min ${min} chars` } : null
    ];


  }

  async submitAdd() {

    this.newUser = new User();
    this.newUser.UserName = this.formGroup.value.UserName;
    this.newUser.UserEmail = this.formGroup.value.UserEmail;
    this.newUser.Password = await sha256(this.formGroup.value.Password);
        this.newUser.UserKindId = this.userKinds.find(k => k.KindUserName == this.formGroup.controls["UserKindId"].value).KindUserId;
if(this.newUser.UserKindId!=2)
// if(this.teamLeaders.find(t => t.UserName == this.formGroup.value.TeamLeaderId).UserId)
    this.newUser.TeamLeaderId =this.teamLeaders.find(t => t.UserName == this.formGroup.controls["TeamLeaderId"].value).UserId;
    else
    this.newUser.TeamLeaderId =0;

    this.userservice.AddNewUser(this.newUser, Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res => { console.log("new", res);console.log("headers",res.headers); this.showSuccess() });
  }

  showSuccess() {
    this.messageService.add({ severity: 'success', summary: 'Success Message', detail: '"The user was added successfuly!!"' });
  }
  onChange(value:any)
  {
  
    if(value=="teamLeader")
  this.formGroup.controls["TeamLeaderId"].disable();
  else
  this.formGroup.controls["TeamLeaderId"].enable();
  }
}
