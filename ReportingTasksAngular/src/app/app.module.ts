import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';


import { RouterModule, Routes } from '@angular/router';

import { HttpClientModule, HttpClient } from '@angular/common/http';
import { HttpModule } from '../../node_modules/@angular/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { LoginComponent } from './components/login/login.component';
import { UserService } from './shared/services/user.service';
import { ManagersComponent } from './components/managers/managers.component';
import { TeamLeadersComponent } from './components/team-leaders/team-leaders.component';
import { OtherWorkerComponent } from './components/other-worker/other-worker.component';
import { AddProjectComponent } from './components//add-project/add-project.component';
import { ReportsManagementComponent } from './components/reports-management/reports-management.component';
import { UserManagementComponent } from './components/user-management/user-management.component';
import { TeamManagementComponent } from './components/team-management/team-management.component';
import { ProjectService } from './shared/services/project.service';
import { AddUserComponent } from './components/add-user/add-user.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { DeleteUserComponent } from './components/delete-user/delete-user.component';
import { UserKindService } from './shared/services/user-kind.service';
import { WorkerToProjectService } from './shared/services/worker-to-project.service';
import { HoursStatusGraphComponent } from './components/hours-status-graph/hours-status-graph.component';
import { ProjectsStateComponent } from './components/projects-state/projects-state.component';
import { RetrohoursComponent } from './components/retrohours/retrohours.component';
import { HoursService } from './shared/services/hours.service';
import { timer } from 'rxjs';
import { SendEmailComponent } from './components/send-email/send-email.component';
import { TimerComponent } from './components/timer/timer.component';
import { SendEmailService } from './shared/services/send-email.service';
import { ChartsModule } from 'ng2-charts';
import { StatusGraphForMonthComponent } from './components/status-graph-for-month/status-graph-for-month.component';
import { YourTasksDataComponent } from './components/your-tasks-data/your-tasks-data.component';
import {AccordionModule} from 'primeng/accordion';     //accordion and accordion tab
import {MenuItem} from 'primeng/api';   
import {TreeTableModule} from 'primeng/treetable';
import {TreeNode} from 'primeng/api';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';
import { VerifyPasswordComponent } from './components/verify-password/verify-password.component';
import { NewPasswordComponent } from './components/new-password/new-password.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import * as shajs from 'sha.js';
import { ExportExcelService } from './shared/services/export-excel.service';
import { CalendarModule } from 'primeng/primeng';
const routes: Routes = [
  
  { path: '', component: LoginComponent },
  {path:'forgetPassword',component:ForgetPasswordComponent},
  {path:'verifyPassword',component:VerifyPasswordComponent},
  {path:'newPassword/:id',component:NewPasswordComponent},
  { path: 'managers', component: ManagersComponent, children: [

      { path: 'addProject', component: AddProjectComponent },
      { path: 'reportsManagement', component: ReportsManagementComponent },
      { path: 'teamManagement', component: TeamLeadersComponent },
      {path: 'userManagement', component: UserManagementComponent, children: [
          { path: 'addUser', component: AddUserComponent },
          { path: 'deleteUser', component: DeleteUserComponent },
          { path: 'editUser', component: EditUserComponent }
        ]
      },
     

    ]
  },
  { path: 'team-leaders', component: TeamLeadersComponent ,children:[
    {path:'hoursStatusGraph',component:HoursStatusGraphComponent},
    {path:'projectsState',component:ProjectsStateComponent},
    {path:'retroHours',component:RetrohoursComponent},
  ]},
  { path: 'other-workers', component: OtherWorkerComponent ,children:[
    {path:'tasksData',component:YourTasksDataComponent},
    {path:'monthGraph',component:StatusGraphForMonthComponent},
    {path:'sendMessage',component:SendEmailComponent},
  ]},

  

]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ManagersComponent,
    TeamLeadersComponent,
    OtherWorkerComponent,
    AddProjectComponent,
    ReportsManagementComponent,
    UserManagementComponent,
    TeamManagementComponent,
    AddUserComponent,
    EditUserComponent,
    DeleteUserComponent,
    HoursStatusGraphComponent,
    ProjectsStateComponent,
    RetrohoursComponent,
    SendEmailComponent,
    TimerComponent,
    StatusGraphForMonthComponent,
    YourTasksDataComponent,
    ForgetPasswordComponent,
    VerifyPasswordComponent,
    NewPasswordComponent,
   



  ],
  imports: [
    BrowserModule, RouterModule.forRoot(routes),ChartsModule, HttpModule,
     FormsModule, ReactiveFormsModule , HttpClientModule,TreeTableModule, BrowserAnimationsModule,CalendarModule
  ],
  providers: [UserService, ProjectService,UserKindService,WorkerToProjectService,HoursService,SendEmailService,ExportExcelService],
  bootstrap: [AppComponent]
})
export class AppModule { }