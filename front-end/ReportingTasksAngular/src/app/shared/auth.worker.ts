import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { User } from './models/User';
import { UserService } from './services/user.service';

@Injectable({ providedIn: 'root' })
export class AuthWorker implements CanActivate {
user:User;
    constructor(private router: Router,private userservice:UserService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('currentUser')) {
         
            return true;
      
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['']);
        return false;
    }
}