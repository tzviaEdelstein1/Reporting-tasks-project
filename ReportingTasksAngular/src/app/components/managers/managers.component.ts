import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-managers',
  templateUrl: './managers.component.html',
  styleUrls: ['./managers.component.css']
})
export class ManagersComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }
  LogOut(){
    localStorage.removeItem("currentUser");
    this.router.navigateByUrl('/');
  }
}
