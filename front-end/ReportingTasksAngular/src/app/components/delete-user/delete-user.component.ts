import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { User } from '../../shared/models/User';
import { UserService } from '../../shared/services/user.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.css']
})
export class DeleteUserComponent implements OnInit {
  isOpen:boolean=false;
  formGroup: FormGroup;
  obj: typeof Object = Object;
  allUsers: User[] = [];
deleteUserId:number;
 opened: boolean = false;
 isOkToDelete:boolean=false;
  constructor(private userservice:UserService,private messageService: MessageService) {

    let formGroupConfig = {
      DeleteUser: new FormControl(""),
     
    };



    this.formGroup = new FormGroup(formGroupConfig);
    this.userservice.GetAllUsers().subscribe(res => { this.allUsers = res; console.log("this.allUsers", this.allUsers);
   this.allUsers=this.allUsers.filter(u=>u.UserKindId!=1);
  });
   
   }

   public close(status) {
    this.opened = false;
    if(status=="yes")
    {
      this.submitDelete();
      debugger;
      }
  }

  public open() {
    this.opened = true;
  }
  ngOnInit() {

  }

  submitDelete()
  { 
debugger;
this.deleteUserId=this.allUsers.find(u=>u.UserName==this.formGroup.value.DeleteUser).UserId;
 var bool;
 this.userservice.CheckIfTeamIsAbleToDelete(this.deleteUserId).subscribe(res=>{
   bool=res;
 if(!bool)
{
  debugger;
this.userservice.DeleteUser(this.deleteUserId,Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res=>{console.log("dell",res);this.showSuccess();});
this.userservice.GetAllUsers().subscribe(res => { this.allUsers = res; console.log("this.allUsers", this.allUsers);
this.allUsers=this.allUsers.filter(u=>u.UserKindId!=1); });

}
else
this.showError();
});

  }
  showSuccess() {
    this.messageService.add({severity:'success', summary: 'Success Message', detail:'Employee successfully removed'});
}
showError() {
  this.messageService.add({severity:'error', summary: 'Error Message', detail:'Can not delete team leader with projects Remove the projects from the team head'});
}
}
