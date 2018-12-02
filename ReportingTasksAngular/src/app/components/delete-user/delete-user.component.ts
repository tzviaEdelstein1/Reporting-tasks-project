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
    this.userservice.GetAllUsers().subscribe(res => { this.allUsers = res; console.log("this.allUsers", this.allUsers) });
    this.allUsers=this.allUsers.filter(u=>u.UserKindId!=2)
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

  submitDelete(){
debugger;

this.userservice.DeleteUser(this.deleteUserId,Number.parseInt(localStorage.getItem("currentUser"))).subscribe(res=>{console.log("dell",res);this.showSuccess();});
this.deleteUserId=this.allUsers.find(u=>u.UserName==this.formGroup.value.DeleteUser).UserId;
  
  }
  showSuccess() {
    this.messageService.add({severity:'success', summary: 'Success Message', detail:'Employee successfully removed'});
}
}
