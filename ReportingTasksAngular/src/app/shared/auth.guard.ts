import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { User } from './models/User';
import { UserService } from './services/user.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    user: User;
    constructor(private router: Router, private userservice: UserService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        // if (localStorage.getItem('currentUser')) { 


        // try {
        //     this.userservice.GetUserById(Number.parseInt(localStorage.getItem('currentUser'))).subscribe(res => {
        //         debugger;
        //         this.user = res;

        //         if (res.UserKindId == 1)


        //             return true;

        //         this.router.navigate(['']);
        //         return false;
        //     });
        // }

        // catch{
        //     this.router.navigate(['']);
        //     return false;
        // }


        //      debugger;



        // }
        // else{
        // debugger;
        // // not logged in so redirect to login page with the return url
        // this.router.navigate(['']);
      return true;
        // }
    }
}