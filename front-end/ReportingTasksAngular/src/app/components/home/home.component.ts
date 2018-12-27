import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { User } from 'src/app/shared/models/User';

@Component({
  selector: 'app-home',
 templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor( private router: Router,private userservice: UserService) { }
  newUser: User;
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
  
  LoginPage()
  {
    this.router.navigateByUrl('/login');
  }
}
