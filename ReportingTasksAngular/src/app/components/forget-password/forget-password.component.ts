import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {

  formGroup: FormGroup;
  obj: typeof Object = Object;
  constructor(private userservice: UserService, private route: ActivatedRoute,
    private router: Router) {

    let formGroupConfig = {
      userName: new FormControl("", this.createValidatorArr("name", 3, 15)),

    };

    this.formGroup = new FormGroup(formGroupConfig);
  }



  ngOnInit() {
  }

  submitLogin() {

    console.log(this.formGroup.value);
    console.log(this.formGroup.controls);

    try {
      this.userservice.VerifyUserName(this.formGroup.value.userName).subscribe(res => {
        if (res == "ok")

          this.router.navigateByUrl('/verifyPassword');
        else
          alert("Your user name doesnt exist")

      }


      )
    }
    catch (e) {
      alert("Login failed!!!");
    }


  }

  createValidatorArr(cntName: string, min: number, max: number): Array<ValidatorFn> {
    return [
      f => !f.value ? { "val": `${cntName} is required` } : null,
      f => f.value && f.value.length > max ? { "val": `${cntName} is max ${max} chars` } : null,
      f => f.value && f.value.length < min ? { "val": `${cntName} is min ${min} chars` } : null
    ];
  }
}
