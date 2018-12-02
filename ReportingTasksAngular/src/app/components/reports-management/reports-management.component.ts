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
  constructor(private treeTableService: TreeTableService, private userService: UserService, private projectService: ProjectService, private exportExcelService: ExportExcelService) {
  }
  exportToExcel() {
    var arr = [];
    this.filterd.forEach(v => arr.push(v.data));
    this.exportExcelService.export(arr);
  }
  ngOnInit() {
    this.fillDate();
    this.treeTableService.GetTreeTable().subscribe(res => {

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
        { field: 'percent', header: 'Percent' },
        { field: 'customer', header: 'Customer' },
        { field: 'startDate', header: 'Start' },
        { field: 'endDate', header: 'End' },
        { field: 'days', header: 'Days' },
        { field: 'workedDays', header: 'Worked' },
        { field: 'daysPercent', header: 'Percent' },
        { field: 'state', header: 'State' }

      ];
      this.initProjectsInfo();
    })
    //get all users from service
      this.userService.GetAllUsers().subscribe(res => { this.allUsers = res; console.log("this.allUsers", this.allUsers) });
    //get all projects from service
this.projectService.GetAllProjects().subscribe(res=>{this.allProjects=res;})
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
    if (this.projectInput != "") {
      this.ChangeProject();

    }
    if (this.userInput != "") {
      this.ChangeUser();

    }
    if (this.startDateValue != null) {
      this.ChangeStartDate();
    }
    if (this.endDateValue != null) {
      this.ChangeEndDate();
    }
    if(this.teamLeaderInput!="")
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
    debugger;
    this.projectInput = event;
    this.checkFilter();

  }
  ChangeProject() {
debugger;
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
    //let projectDays: number = this.baseService.dateDiffInDays(project.startDate, project.endDate);
    // let date = new Date();
    // if (date > project.endDate)
    //   date = project.endDate;
    // let workedDays: number = this.baseService.dateDiffInDays(project.startDate, date);
    // let daysPercent: number = workedDays / projectDays;

    // let projectPresenseHours: number = this.projectService.getPresenceHours(project);
    // let projectPercentHours: number = this.projectService.getPercentHours(project);
    // let state: string;

    // if (projectPercentHours == daysPercent)
    //   state = "good";
    // else
    //   if (projectPercentHours > daysPercent)
    //     state = "excellent";
    //   else
    //     state = "bad"
    let hours = project.Project.QaHours + project.Project.UiUxHours + project.Project.DevelopersHours;
    let actualhorsForProject = this.getActualHoursForProject(project);
    // console.log("hh", this.teamLeader);
    let root = {
      data: {
        name: project.Project.ProjectName,
        teamLeader: project.Project.User.UserName,
        hours: hours,
        // presence: this.baseService.toShortNumber(projectPresenseHours),
        percent: this.getPrecentOfNumbers(hours, actualhorsForProject),
        customer: project.Project.ClientName,
        startDate: project.Project.StartDate,
        endDate: project.Project.FinishDate,
        actualHours: actualhorsForProject
        // days: projectDays,
        // workedDays: workedDays,
        // daysPercent: this.baseService.toPercent(daysPercent),
        // state: state
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
        // presence: this.baseService.toShortNumber(presenceHoursForDepartment),
        // percent: departmentHours.numHours > 0 ? this.baseService.toPercent(presenceHoursForDepartment / departmentHours.numHours) : '-'
      },

      children: [

      ]
    };
    project.DetailsWorkerInProjects.forEach(worker => {


      if (worker.Kind == "Developers") {
        let actualHoursforWorker = this.getCountHours(worker)
        let workerNode = {
          data: {
            name: worker.Name,
            actualHours: actualHoursforWorker,
            hours: worker.Hours,
            percent: this.getPrecentOfNumbers(hours, actualHoursforWorker),
            teamLeader: worker.TeamLeaderName
            // presence: this.baseService.toShortNumber(presenceHoursForWorker),
            // percent: worker.workerHours.length ? this.baseService.toPercent(presenceHoursForWorker / worker.workerHours[0].numHours) : '-'
          }
        };
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
        // presence: this.baseService.toShortNumber(presenceHoursForDepartment),
        // percent: departmentHours.numHours > 0 ? this.baseService.toPercent(presenceHoursForDepartment / departmentHours.numHours) : '-'
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
            // presence: this.baseService.toShortNumber(presenceHoursForWorker),
            // percent: worker.workerHours.length ? this.baseService.toPercent(presenceHoursForWorker / worker.workerHours[0].numHours) : '-'
          }
        };
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
        // presence: this.baseService.toShortNumber(presenceHoursForDepartment),
        // percent: departmentHours.numHours > 0 ? this.baseService.toPercent(presenceHoursForDepartment / departmentHours.numHours) : '-'
      },
      children: [

      ]
    };

    project.DetailsWorkerInProjects.forEach(worker => {
      if (worker.Kind == "UI/UX") {
        let actualHoursforWorker = this.getCountHours(worker)
        let workerNode = {
          data: {
            name: worker.Name,
            actualHours: actualHoursforWorker,
            percent: this.getPrecentOfNumbers(hours, actualHoursforWorker),
            teamLeader: worker.TeamLeaderName,
            hours: worker.Hours
            // presence: this.baseService.toShortNumber(presenceHoursForWorker),
            // percent: worker.workerHours.length ? this.baseService.toPercent(presenceHoursForWorker / worker.workerHours[0].numHours) : '-'
          }
        };
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
  getPrecentOfNumbers(num1: number, num2: number) {
    return (num2 / num1) * 100 + '%';
  }
}
