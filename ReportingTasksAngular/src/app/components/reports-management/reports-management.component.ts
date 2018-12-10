import { Component, OnInit } from '@angular/core';
import { TreeTableService } from '../../shared/services/tree-table.service';
import { TreeTable } from '../../shared/models/TreeTable';
import { TreeTableModule } from 'primeng/treetable';
import { forEach } from '@angular/router/src/utils/collection';
import { Tree, TreeNode } from 'primeng/primeng';
import { CardModule } from 'primeng/card';
import { Project } from '../../shared/models/Project';
import { DetailsWorkerInProjects } from '../../shared/models/DetailsWorkerInProjects';
import { UserService } from '../../shared/services/user.service';
import { User } from '../../shared/models/User';
import { ProjectService } from '../../shared/services/project.service';
import { CalendarModule } from 'primeng/calendar';
import { ExportExcelService } from '../../shared/services/export-excel.service';
import { numberSymbols } from '@telerik/kendo-intl';

@Component({
  selector: 'app-reports-management',
  templateUrl: './reports-management.component.html',
  styleUrls: ['./reports-management.component.css']
})
export class ReportsManagementComponent implements OnInit {
  treeTable: TreeTable[] = [];
  allProjects: Project[] = [];
  files1: TreeNode[] = [];
  filterd: TreeNode[] = [];
  filterdUser: TreeNode[] = [];

  cols: any[];
  arr: any[] = [];
  startDateValue: Date = null;
  endDateValue: Date = null;
  date12: Date;
  rangeDates: Date[];
  minDate: Date;
  maxDate: Date;
  es: any;
  tr: any;
  invalidDates: Array<Date>
  teamLeaders: User[]=[];
  allUsers: User[] = [];
  projectInput: string = "";
  userInput: string = "";
teamLeaderInput:string="";
filterFiles:any[]=[];
  constructor(private treeTableService: TreeTableService, private userService: UserService, private projectService: ProjectService, private exportExcelService: ExportExcelService) {
  }
  exportToExcel() {
    var arr = [];
    debugger;
   arr=this.filterFilesToExport();
    this.exportExcelService.export(arr);
  }
  ngOnInit() {


    this.fillDate();
    this.treeTableService.GetTreeTable().subscribe(res => {
      debugger;
      this.treeTable = res;
      //     this.treeTable.forEach(element => {
      //       console.log("element",element); 
      //       debugger;
      //   this.files1.push({
      // data:{
      //   ProjectName:element["Project"].ProjectName
      // }
      //   })
      // });
      this.cols = [
        { field: 'name', header: 'Name' },
        { field: 'teamLeader', header: 'TeamLeader' },
        { field: 'hours', header: 'Hours' },
        { field: 'actualHours', header: 'ActualHours' },
        { field: 'date', header: 'Date' },
        { field: 'percent', header: 'Percent' },
        { field: 'customer', header: 'Customer' },
        { field: 'startDate', header: 'Start' },
        { field: 'endDate', header: 'End' },

      ];
      this.initProjectsInfo();
    })
    //get all users from service
      this.userService.GetAllUsers().subscribe(res => { this.allUsers = res; console.log("this.allUsers", this.allUsers) });
    //get all projects from service
   this.projectService.GetActiveProjects().subscribe(res=>{this.allProjects=res;})
//get all team leaders 
this.userService.GetTeamLeaders().subscribe(res=>{this.teamLeaders=res})
  }
  fillDate() {
    this.es = {
      firstDayOfWeek: 1,
      dayNames: ["domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado"],
      dayNamesShort: ["dom", "lun", "mar", "mié", "jue", "vie", "sáb"],
      dayNamesMin: ["D", "L", "M", "X", "J", "V", "S"],
      monthNames: ["enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"],
      monthNamesShort: ["ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic"],
      today: 'Hoy',
      clear: 'Borrar'
    }

    this.tr = {
      firstDayOfWeek: 1
    }

    let today = new Date();
    let month = today.getMonth();
    let year = today.getFullYear();
    let prevMonth = (month === 0) ? 11 : month - 1;
    let prevYear = (prevMonth === 11) ? year - 1 : year;
    let nextMonth = (month === 11) ? 0 : month + 1;
    let nextYear = (nextMonth === 0) ? year + 1 : year;
    this.minDate = new Date();
    this.minDate.setMonth(prevMonth);
    this.minDate.setFullYear(prevYear);
    this.maxDate = new Date();
    this.maxDate.setMonth(nextMonth);
    this.maxDate.setFullYear(nextYear);

    let invalidDate = new Date();
    invalidDate.setDate(today.getDate() - 1);
    this.invalidDates = [today, invalidDate];
  }
  initProjectsInfo() {
    this.files1 = this.treeTable.map(project => this.getProjectInfo(project));
    this.filterd = this.files1;

  }
  checkFilter() {
    this.filterd = this.files1;
    if (this.projectInput != ""&&this.projectInput!="allProjects") {
      this.ChangeProject();

    }
    if (this.userInput != ""&&this.userInput!="allUsers") {
      this.ChangeUser();

    }
    if (this.startDateValue != null) {
      this.ChangeStartDate();
    }
    if (this.endDateValue != null) {
      this.ChangeEndDate();
    }
    if(this.teamLeaderInput!=""&&this.teamLeaderInput!="allTeamLeaders")
    {
      this.ChangeTeamLeader();
    }
  }
  onChangeTeamLeader(event:any)
  {
this.teamLeaderInput=event;
this.checkFilter();
  }
  ChangeTeamLeader()
  {
    this.filterd = this.filterd.filter(t => t.data["teamLeader"] == this.teamLeaderInput);
  }
  onChangeProject(event: any) {

    this.projectInput = event;
    this.checkFilter();

  }
  ChangeProject() {

    this.filterd = this.filterd.filter(t => t.data["name"] == this.projectInput);
    console.log(this.filterd);
  }
  ChangeUser() {

    this.filterdUser = [];
    this.filterd.forEach(t => t.children.forEach(r => r.children.forEach(e => e.data["name"] == this.userInput ? this.filterdUser.push(t) : console.log("ccc"))))
    this.filterd = this.filterdUser;
  }
  onChangeStartDate() {
    this.checkFilter();

  }
  ChangeStartDate() {
    this.filterd = this.filterd.filter(t => new Date(t.data["startDate"]).getMonth() == this.startDateValue.getMonth() && new Date(t.data["startDate"]).getFullYear() == this.startDateValue.getFullYear());
    console.log(this.filterd);
  }
  onChangeEndDate() {
    this.checkFilter();
  }
  ChangeEndDate() {
    this.filterd = this.filterd.filter(t => new Date(t.data["endDate"]).getMonth() == this.endDateValue.getMonth() && new Date(t.data["endDate"]).getFullYear() == this.endDateValue.getFullYear());
    console.log(this.filterd);
  }
  onChangeUser(event: any) {
    this.userInput = event;
    this.checkFilter();
  }
  
  getProjectInfo(project: TreeTable) {
    
    let hours =project.Project.QaHours+ project.Project.UiUxHours +project.Project.DevelopersHours;
    let actualhorsForProject = this.getActualHoursForProject(project);
    let root = {
      data: {
        name: project.Project.ProjectName,
        teamLeader: project.Project.User.UserName,
        hours: hours,
     
        percent: this.getPrecentOfNumbers(hours, actualhorsForProject),
        customer: project.Project.ClientName,
        startDate:this.getShorerDate( project.Project.StartDate),
        endDate: this.getShorerDate(project.Project.FinishDate),
        actualHours: actualhorsForProject

      },
      children: []
    };
    let actualHoursForDepartment = this.getActualHoursForDepartment(project, "DevelopersHours")
    let departmentNode = {
      data: {
        name: "DevelopersHours",
        hours: project.Project.DevelopersHours,
        actualHours: actualHoursForDepartment,
        percent: this.getPrecentOfNumbers(hours, actualHoursForDepartment),
       
      },

      children: [

      ]
    };
    project.DetailsWorkerInProjects.forEach(worker => {


      if (worker.Kind == "developer") {
        let actualHoursforWorker = this.getCountHours(worker)
        let workerNode = {
          data: {
            name: worker.Name,
            actualHours: actualHoursforWorker,
            hours: worker.Hours,
            percent: this.getPrecentOfNumbers(hours, actualHoursforWorker),
            teamLeader: worker.TeamLeaderName
        
          },
          children:[]
        };
       worker.ActualHours.forEach(actualHours=>
        {
          let workerActualHoursNode={
            data:{
              actualHours:actualHours.CountHours,          
              date:this.getShorerDate(actualHours.date)
            }
          }
          debugger;
          workerNode.children.push(workerActualHoursNode)
        }
        );
     
      
        departmentNode.children.push(workerNode);


      }


    })
    root.children.push(departmentNode);
    let actualHoursForDepartment1 = this.getActualHoursForDepartment(project, "QaHours");
    let departmentNode1 = {
      data: {
        name: "QaHours",
        hours: project.Project.QaHours,
        actualHours: actualHoursForDepartment1,
        percent: this.getPrecentOfNumbers(hours, actualHoursForDepartment1),
       
      },

      children: [

      ]
    };

    project.DetailsWorkerInProjects.forEach(worker => {
      if (worker.Kind == "QA") {
        let actualHoursforWorker = this.getCountHours(worker)
        let workerNode = {
          data: {
            name: worker.Name,
            actualHours: actualHoursforWorker,
            hours: worker.Hours,
            percent: this.getPrecentOfNumbers(hours, actualHoursforWorker),
            teamLeader: worker.TeamLeaderName
        
          },
          children:[]
         
        };
        worker.ActualHours.forEach(actualHours=>
          {
            let workerActualHoursNode={
              data:{
                actualHours:actualHours.CountHours,          
                date:this.getShorerDate(actualHours.date)
              }
            }
            debugger;
            workerNode.children.push(workerActualHoursNode)
          }
          );
        
        departmentNode1.children.push(workerNode);
      }
    })
    root.children.push(departmentNode1);
    let actualHoursForDepartment2 = this.getActualHoursForDepartment(project, "UiUxHours");
    let departmentNode2 = {
      data: {
        name: "UiUxHours",
        hours: project.Project.UiUxHours,
        actualHours: actualHoursForDepartment2,
        percent: this.getPrecentOfNumbers(hours, actualHoursForDepartment2),
      
      },
      children: [

      ]
    };

    project.DetailsWorkerInProjects.forEach(worker => {
      if (worker.Kind == "ui/ux") {
        let actualHoursforWorker = this.getCountHours(worker)
        let workerNode = {
          data: {
            name: worker.Name,
            actualHours: actualHoursforWorker,
            percent: this.getPrecentOfNumbers(hours, actualHoursforWorker),
            teamLeader: worker.TeamLeaderName,
            hours: worker.Hours
     
          },
          children:[]
        };
        worker.ActualHours.forEach(actualHours=>
          {
            let workerActualHoursNode={
              data:{
                actualHours:actualHours.CountHours,          
                date:this.getShorerDate(actualHours.date)
              }
            }
            debugger;
            workerNode.children.push(workerActualHoursNode)
          }
          );
        departmentNode2.children.push(workerNode);
      }
    })
    root.children.push(departmentNode2);
    return <TreeNode>(root);
  }

  getCountHours(worker: DetailsWorkerInProjects) {
    let count = 0;
    worker.ActualHours.forEach(actualHours => { count += actualHours.CountHours })
    return count;
  }
  getActualHoursForDepartment(treeTable: TreeTable, department: string) {
    let count = 0;
    treeTable.DetailsWorkerInProjects.forEach(worker => { if (worker.Kind == department) worker.ActualHours.forEach(ah => count += ah.CountHours) });
    return count;
  }
  getActualHoursForProject(treeTable: TreeTable) {
    let count = 0;
    treeTable.DetailsWorkerInProjects.forEach(worker => { worker.ActualHours.forEach(ah => count += ah.CountHours) });
    return count;
  }
  getPrecentOfNumbers(num1: number, num2: number) 
  {
debugger; 
    var c= (num2 / num1) * 100+"%";
  var x= parseFloat(c).toFixed(3)
  if(x=="0.000")
    return c;
    return x+"%";
  }

  getShorerDate(date:Date)
  {
debugger;
var d=new  Date( date)
  return d.toLocaleDateString();
  }
  //Export to excel
  //In order to export to Excel, you need a flat list of data suitable for the filter 
  filterFilesToExport() {
    debugger;
    for (var i = 0; i < this.filterd.length; i++) {
     
        //push project
        let project: any = {
          name:this.filterd[i].data["name"],
          teamLeader:this.filterd[i].data["teamLeader"],
          hours:this.filterd[i].data["hours"],
        
          percent:this.filterd[i].data["percent"],
          customer: this.filterd[i].data["customer"],
          startDate:this.filterd[i].data["startDate"],
          endDate:this.filterd[i].data["endDate"],
          actualHours: this.filterd[i].data["actualHours"],
          date:""
        }
    
        this.filterFiles.push(project);             
          for (var j = 0; j < this.filterd[i].children.length; j++) {
            //push department
            let department: any = {
              name:this.filterd[i].children[j].data["name"],
              teamLeader:" ",
              hours:this.filterd[i].children[j].data["hours"],
            
              percent:this.filterd[i].children[j].data["percent"],
              customer: " ",
              startDate:" ",
              endDate:" ",
              actualHours: this.filterd[i].children[j].data["actualHours"],
              date:""

            }
            this.filterFiles.push(department);

            for (var l = 0; l < this.filterd[i].children[j].children.length; l++) {
              //push presence
              let presence: any = {
                name:this.filterd[i].children[j].children[l].data["name"],
                teamLeader:this.filterd[i].children[j].children[l].data["teamLeader"],
                hours:this.filterd[i].children[j].children[l].data["hours"],
              
                percent:this.filterd[i].children[j].children[l].data["napercentme"],
                customer: " ",
                startDate:" ",
                endDate:" ",
                actualHours: this.filterd[i].children[j].children[l].data["actualHours"],
                date:""
              }
              this.filterFiles.push(presence);
            
              for (var k = 0; k< this.filterd[i].children[j].children[l].children.length;k++) {
                //push presence
                let presence: any = {
                  name:" ",
                  teamLeader:" ",
                  hours: " ",
                
                  percent:" ",
                  customer: " ",
                  startDate:" ",
                  endDate:" ",
                  actualHours: this.filterd[i].children[j].children[l].children[k].data["actualHours"],
                  date:this.filterd[i].children[j].children[l].children[k].data["date"]
                }
                this.filterFiles.push(presence);
              
            }
          }
        }
      }
      return this.filterFiles;
    }
  }

// }
