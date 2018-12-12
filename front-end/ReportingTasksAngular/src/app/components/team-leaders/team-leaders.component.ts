import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-team-leaders',
  templateUrl: './team-leaders.component.html',
  styleUrls: ['./team-leaders.component.css']
})
export class TeamLeadersComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }
  LogOut(){
    localStorage.removeItem("currentUser");
    this.router.navigateByUrl('/');
  }
}
