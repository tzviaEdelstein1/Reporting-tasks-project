import { Component, OnInit } from '@angular/core';
import { ProjectService } from 'src/app/shared/services/project.service';
import { HelpProjectsAndHours } from 'src/app/shared/models/HelpProjectsAndHours';
// import * as CanvasJS from './canvasjs.min';

// import CanvasJS from 'canvasjs';
@Component({
  selector: 'app-hours-status-graph',
  templateUrl: './hours-status-graph.component.html',
  styleUrls: ['./hours-status-graph.component.css']
})
export class HoursStatusGraphComponent implements OnInit {
  workersAndHours:HelpProjectsAndHours[]=[];
  workersNames:string[]=[];
  workersGlobalHours:number[]=[];
  workersActualHours:number[]=[];
  
  constructor(private projectService:ProjectService){


  }
  ngOnInit() {

    this.projectService.GetProjectsAndHoursByTeamLeaderId(Number.parseInt(localStorage.getItem("currentUser"))).subscribe(
      res=>{this.workersAndHours=res;
        console.log(res);
        
      for(var i=0;i<this.workersAndHours.length;i++){
        this.workersNames.push(this.workersAndHours[i].Name);
        this.workersGlobalHours.push(this.workersAndHours[i].Hours);
        this.workersActualHours.push(this.workersAndHours[i].allocatedHours);
      }

      console.log(" this.workersNames", this.workersNames);
      });
  }
  public barChartOptions:any = {
    scaleShowVerticalLines: false,
    responsive: true
  };



  public barChartLabels:string[] = this.workersNames;
  public barChartType:string = 'bar';
  public barChartLegend:boolean = true;
 
  public barChartData:any[] = [
    {data: this.workersGlobalHours, label: 'GlobalHours'},
    {data:this.workersActualHours, label: 'ActualHours'}
  ];
 
  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }
}



