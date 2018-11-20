import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';
import { User } from '../../shared/models/User';
import { UserService } from '../../shared/services/user.service';
import { UserKind } from '../../shared/models/UserKind';
import { UserKindService } from '../../shared/services/user-kind.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  formGroup: FormGroup;
  obj: typeof Object = Object;
  allUsers: User[] = [];


  teamLeaders: User[] = [];
  userKinds: UserKind[] = [];
  editUser:User;
  constructor(private userservice: UserService,private userkindservice:UserKindService) { }

  ngOnInit() {

    let formGroupConfig = {
      EditUser: new FormControl(""),
      UserName: new FormControl("", this.createValidatorArr("UserName", 3, 15)),
      UserEmail: new FormControl("", this.createValidatorArr("UserEmail", 4, 1000)),

      TeamLeaderId: new FormControl("", this.createValidatorArr("TeamLeaderId", 0, 1000)),
      UserKindId: new FormControl("", this.createValidatorArr("UserKindId", 0, 1000)),
    };


    this.formGroup = new FormGroup(formGroupConfig);

    this.userservice.GetAllUsers().subscribe(res => { this.allUsers = res; console.log("this.allUsers", this.allUsers) });
    this.userservice.GetTeamLeaders().subscribe(res=>{this.teamLeaders=res;});
    this.userkindservice.GetAllKinds().subscribe(res=>{this.userKinds=res;});
  }


  createValidatorArr(cntName: string, min: number, max: number): Array<ValidatorFn> {
    return [
      f => !f.value ? { "val": `${cntName} is required` } : null,
      f => f.value && f.value.length > max ? { "val": `${cntName} is max ${max} chars` } : null,
      f => f.value && f.value.length < min ? { "val": `${cntName} is min ${min} chars` } : null
    ];
  }

  FillFields(event) {
    console.log("event", event);
    this.editUser = this.allUsers.find(u=>u.UserName==event.target.value);
    
    this.formGroup.controls['UserName'].setValue(this.editUser.UserName);
    this.formGroup.controls['UserEmail'].setValue(this.editUser.UserName);
    this.formGroup.controls['TeamLeaderId'].setValue(this.teamLeaders.find(t=>t.UserId==this.editUser.TeamLeaderId).UserName);
   
    this.formGroup.controls['UserKindId'].setValue(this.userKinds.find(u => u.KindUserId==this.editUser.UserKindId).KindUserName);




  }


  submitEdit(){

    this.editUser.UserName=this.formGroup.value.UserName;
    this.editUser.UserEmail=this.formGroup.value.UserEmail;
   
    this.editUser.TeamLeaderId=this.teamLeaders.find(t=>t.UserName==this.formGroup.value.TeamLeaderId).UserId;
    this.editUser.UserKindId=this.userKinds.find(k=>k.KindUserName==this.formGroup.value.UserKindId).KindUserId;

this.userservice.EditUser(this.editUser,Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res=>{console.log("edit-res",res)});


  }

}
