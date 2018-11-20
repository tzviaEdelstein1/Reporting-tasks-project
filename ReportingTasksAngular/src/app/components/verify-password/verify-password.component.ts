import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/shared/models/User';

@Component({
  selector: 'app-verify-password',
  templateUrl: './verify-password.component.html',
  styleUrls: ['./verify-password.component.css']
})
export class VerifyPasswordComponent implements OnInit {

  formGroup: FormGroup;
  obj: typeof Object = Object;
  constructor(private userservice: UserService, private route: ActivatedRoute,
    private router: Router) {

    let formGroupConfig = {

      userPassword: new FormControl("")
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
  }
  submitLogin() {

    console.log(this.formGroup.value);
    console.log(this.formGroup.controls);

    try {
      this.userservice.VerifyPassword(this.formGroup.value.userPassword).subscribe(res => {
        if (res != 'error') {
        
          console.log("good", res)
          this.router.navigateByUrl('/newPassword/'+res.UserId);
        }
        else {
          console.log("bad", res);
          alert("Incorrect Password");
        }
      }


      )
    }
    catch (e) {
      alert("Login failed!!!");
    }


  }
}
