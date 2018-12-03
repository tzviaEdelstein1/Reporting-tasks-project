import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';
import { UserService } from '../../shared/services/user.service';
import { User } from '../../shared/models/User';
import { ActivatedRoute, Router } from '@angular/router';

import sha256 from 'async-sha256';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  newUser: User;
  formGroup: FormGroup;
  obj: typeof Object = Object;
  sha256Pass:string;
  pass:string="";
  constructor(private userservice: UserService, private route: ActivatedRoute,
    private router: Router) {

    let formGroupConfig = {
      userName: new FormControl("", this.createValidatorArr("name", 3, 15)),
      userPassword: new FormControl("", this.createValidatorArr("password", 6, 64))
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    if (localStorage.getItem("currentUser") != null) {
      
      this.userservice.GetUserById(Number(localStorage.getItem("currentUser"))).subscribe(res=>{this.newUser=res;
        console.warn("new", this.newUser);
        console.warn("kind"+res.UserKindId);
        if(res.UserKindId==1)
        this.router.navigateByUrl('/managers');
        else if(res.UserKindId==2)
        this.router.navigateByUrl('/team-leaders');
        else
        this.router.navigateByUrl('/other-workers');
      });
      
   
     

    }
  }

   async submitLogin() {
debugger;
 this.pass=await sha256(this.formGroup.value.userPassword);
console.log("rrrrrrrr",this.pass);
   
    console.log(this.formGroup.value);
    console.log(this.formGroup.controls);
    alert(this.formGroup.status);
    try
     {
      this.userservice.Login(this.formGroup.value.userName,this.pass).subscribe(res => {
        console.warn(res);
        if (res != null) {
          alert("login succees");
          this.newUser=res;
          console.warn("new", this.newUser);
          console.warn("kind"+res.UserKindId);
         localStorage.setItem("currentUser",this.newUser.UserId.toString());
          if(res.UserKindId==1)
          this.router.navigateByUrl('/managers');
          else if(res.UserKindId==2)
          this.router.navigateByUrl('/team-leaders');
          else
          this.router.navigateByUrl('/other-workers');

        }

        else
          alert("Login failed!!!");
      })
    }
    catch (e) {
      alert("Login failed!!!");
    }




  }

  createValidatorArr(cntName: string, min: number, max: number): Array<ValidatorFn> {
    return [
      f => !f.value ? { "val": `${cntName} is required` } : null,
    ];
  }

}