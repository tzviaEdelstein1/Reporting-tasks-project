import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { User } from '../../shared/models/User';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.css']
})
export class DeleteUserComponent implements OnInit {

  formGroup: FormGroup;
  obj: typeof Object = Object;
  allUsers: User[] = [];
deleteUserId:number;

  constructor(private userservice:UserService) {

    let formGroupConfig = {
      DeleteUser: new FormControl(""),
     
    };


    this.formGroup = new FormGroup(formGroupConfig);
    this.userservice.GetAllUsers().subscribe(res => { this.allUsers = res; console.log("this.allUsers", this.allUsers) });
   }

  ngOnInit() {

  }

  submitDelete(){
this.deleteUserId=this.allUsers.find(u=>u.UserName==this.formGroup.value.DeleteUser).UserId;
var isOkToDelete=confirm("Are you sure you want to delete "+this.formGroup.value.DeleteUser+"?");
if(isOkToDelete)
this.userservice.DeleteUser(this.deleteUserId,Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res=>{console.log("dell",res);alert("delete success!!!")});

  }
}
