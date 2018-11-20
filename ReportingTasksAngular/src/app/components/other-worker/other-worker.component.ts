import { Component, OnInit } from '@angular/core';
import { Time } from '@angular/common';
import { HelpProjectsAndHours } from 'src/app/shared/models/HelpProjectsAndHours';
import { ProjectService } from 'src/app/shared/services/project.service';
import { ActualHours } from 'src/app/shared/models/ActualHours';
import { HoursService } from 'src/app/shared/services/hours.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-other-worker',
  templateUrl: './other-worker.component.html',
  styleUrls: ['./other-worker.component.css']
})
export class OtherWorkerComponent implements OnInit {
  public now: Date = new Date();
  
 



  constructor(private router: Router) {

    setInterval(() => {
      this.now = new Date();
    }, 1);



  }

  ngOnInit() {
   
  }
  LogOut(){
    localStorage.removeItem("currentUser");
    this.router.navigateByUrl('/');
  }


}
