import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/shared/models/User';
import { UserService } from 'src/app/shared/services/user.service';
import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';
import sha256 from 'async-sha256';
@Component({
  selector: 'app-new-password',
  templateUrl: './new-password.component.html',
  styleUrls: ['./new-password.component.css']
})
export class NewPasswordComponent implements OnInit {

  id:any;
  user:User;
  formGroup: FormGroup;
  obj: typeof Object = Object;
  constructor(private activatedRoute: ActivatedRoute,private userservice:UserService,
    private router: Router) {

      let formGroupConfig = {
       
        userPassword: new FormControl("", this.createValidatorArr("password", 6, 64))
      };
  
      this.formGroup = new FormGroup(formGroupConfig);
   }

  ngOnInit() {
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    console.log("nnnnnnnnnnnn",this.id);
    this.userservice.GetUserById(this.id).subscribe(res=>{
    
      this.user=res;
    console.log("user",this.user);
    });

  }

 async submitLogin() {

   let password=await sha256(this.formGroup.value.userPassword);

   this.user.Password=password;
 
   this.userservice.EditPassword(this.user).subscribe(res=>
    
    {
      console.log("ress",res);
   alert("Created new password succeed");
   this.router.navigateByUrl('');
  })

  }

  createValidatorArr(cntName: string, min: number, max: number): Array<ValidatorFn> {
    return [
      f => !f.value ? { "val": `${cntName} is required` } : null,
      f => f.value && f.value.length > max ? { "val": `${cntName} is max ${max} chars` } : null,
      f => f.value && f.value.length < min ? { "val": `${cntName} is min ${min} chars` } : null
    ];
  }
}
