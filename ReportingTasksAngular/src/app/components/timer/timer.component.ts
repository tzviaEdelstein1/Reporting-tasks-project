import { Component, OnInit } from '@angular/core';
import { ActualHours } from 'src/app/shared/models/ActualHours';
import { ProjectService } from 'src/app/shared/services/project.service';
import { HelpProjectsAndHours } from 'src/app/shared/models/HelpProjectsAndHours';
import { HoursService } from 'src/app/shared/services/hours.service';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.css']
})
export class TimerComponent implements OnInit {
  public now: Date = new Date();
  timerInterval: any = null;
  timerSeconds: number = 0;
  timerMinutes: number = 0;
  timerHours: number = 0;
  zeroFlagS: boolean = true;
  zeroFlagM: boolean = true;
  zeroFlagH: boolean = true;
  selectedProject: string;

  newActualHours: ActualHours;

  time: number;
  allYourProjectsAndHoursDetails: HelpProjectsAndHours[] = [];
  constructor(private projectservice:ProjectService,private hoursservice:HoursService) {

    
    setInterval(() => {
      this.now = new Date();
    }, 1);

   }

  ngOnInit() {
    this.projectservice.GetProjectsAndHoursByUserId(Number.parseInt(localStorage.getItem("currentUser"))).subscribe(
      res => {

        this.allYourProjectsAndHoursDetails = res;
        console.warn("my", this.allYourProjectsAndHoursDetails);
      }
    )
  }


  SelectProject(event) {
    this.selectedProject = event.target.value;
  }
  StartTimer() {
    this.timerHours = 0;
    this.timerMinutes = 0;
    this.timerSeconds = 0;

    this.zeroFlagS = true;
    this.zeroFlagM = true;
    this.zeroFlagH = true;

    if (this.timerInterval == null) {
      this.timerInterval = setInterval(() => {
        if (this.timerSeconds > 9)
          this.zeroFlagS = false;
        if (this.timerMinutes > 9)
          this.zeroFlagM = false;
        if (this.timerHours > 9)
          this.zeroFlagH = false;
        else
          this.zeroFlagH = true;

        if (this.timerSeconds == 59) {
          this.timerMinutes++;
          this.timerSeconds = 0;
          this.zeroFlagS = true;
        }
        if (this.timerMinutes == 59) {
          this.timerHours++;
          this.timerMinutes = 0;
          this.zeroFlagM = true;
        }
        this.timerSeconds++;
      }, 1000);
    }

  }


  StopTimer() {
    if (this.timerInterval) {
      clearInterval(this.timerInterval);
      this.time = this.timerHours + this.timerMinutes / 60;
      console.log("time", this.time);
      this.newActualHours = new ActualHours();
      this.newActualHours.UserId = Number.parseInt(localStorage.getItem("currentUser"));
      this.newActualHours.ProjectId = this.allYourProjectsAndHoursDetails.find(p => p.Name == this.selectedProject).Id;
      this.newActualHours.CountHours = this.time;
      this.newActualHours.date = this.now;

      this.hoursservice.AddActualHours(this.newActualHours).subscribe(res => {

        debugger;
        this.projectservice.GetProjectsAndHoursByUserId(Number.parseInt(localStorage.getItem("currentUser"))).subscribe(
          res => {

            this.allYourProjectsAndHoursDetails = res;
            console.warn("my", this.allYourProjectsAndHoursDetails);
          }
        )

        this.selectedProject = null;

        this.timerInterval = null;


      });


    }
  }
}
