import { Component, OnInit } from '@angular/core';
import { HelpProjectsAndHours } from 'src/app/shared/models/HelpProjectsAndHours';
import { ProjectService } from 'src/app/shared/services/project.service';

@Component({
  selector: 'app-status-graph-for-month',
  templateUrl: './status-graph-for-month.component.html',
  styleUrls: ['./status-graph-for-month.component.css']
})
export class StatusGraphForMonthComponent implements OnInit {

  ProjectsAndHours:HelpProjectsAndHours[]=[];
  projectsNames:string[]=[];
  projectsGlobalHours:number[]=[];
  projectsActualHours:number[]=[];
  
  constructor(private projectService:ProjectService){


  }
  ngOnInit() {

    this.projectService.GetProjectsAndHoursByUserIdAccordingTheMonth(Number.parseInt(localStorage.getItem("currentUser"))).subscribe(
      res=>{this.ProjectsAndHours=res;
        console.log(res);
        
      for(var i=0;i<this.ProjectsAndHours.length;i++){
        this.projectsNames.push(this.ProjectsAndHours[i].Name);
        this.projectsGlobalHours.push(this.ProjectsAndHours[i].Hours);
        this.projectsActualHours.push(this.ProjectsAndHours[i].allocatedHours);
      }

  
      });
  }
  public barChartOptions:any = {
    scaleShowVerticalLines: false,
    responsive: true
  };



  public barChartLabels:string[] = this.projectsNames;
  public barChartType:string = 'bar';
  public barChartLegend:boolean = true;
 
  public barChartData:any[] = [
    {data: this.projectsGlobalHours, label: 'GlobalHours'},
    {data:this.projectsActualHours, label: 'ActualHours'}
  ];
 
  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }

}
