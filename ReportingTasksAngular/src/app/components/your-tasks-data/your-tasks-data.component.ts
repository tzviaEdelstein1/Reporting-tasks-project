import { Component, OnInit } from '@angular/core';
import { HelpProjectsAndHours } from 'src/app/shared/models/HelpProjectsAndHours';
import { ProjectService } from 'src/app/shared/services/project.service';
import { HoursService } from 'src/app/shared/services/hours.service';

@Component({
  selector: 'app-your-tasks-data',
  templateUrl: './your-tasks-data.component.html',
  styleUrls: ['./your-tasks-data.component.css']
})
export class YourTasksDataComponent implements OnInit {
  allYourProjectsAndHoursDetails: HelpProjectsAndHours[] = [];
  constructor(private projectservice: ProjectService, private hoursservice: HoursService) { }

  ngOnInit() {
    this.projectservice.GetProjectsAndHoursByUserId(Number.parseInt(localStorage.getItem("currentUser"))).subscribe(
      res => {

        this.allYourProjectsAndHoursDetails = res;
        console.warn("my", this.allYourProjectsAndHoursDetails);
      }
    )
  }

}
