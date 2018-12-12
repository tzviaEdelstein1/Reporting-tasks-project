import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Project } from '../models/Project';
import { GlobalService } from './global.service';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient,private globalService:GlobalService){ }

  Login(userName: string, password: string):Observable<User>  {
    //return this.http.get("http://localhost:56028/users/"+userName+"/"+password)
    // let url=this.globalService.path+"users/Login/"+ userName +"/" + password;
    return this.http.get(this.globalService.path+"Users/Login/"+ userName +"/" + password)
    .map((res:User)=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }
  GetAllUsers():Observable<User[]>  {
   //let url="http://localhost:8080/ReportingTasksPhp/Controllers/index.php/users/GetAllUsers"
    // return this.http.get("http://localhost:56028/api/Users/GetAllUsers")
      return this.http.get(this.globalService.path+"Users/GetAllUsers")
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

  GetTeamLeaders():Observable<User[]>  {
   
    //return this.http.get("http://localhost:56028/api/Users/GetTeamLeaders")
    return this.http.get(this.globalService.path+"Users/GetTeamLeaders")
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

   GetUsersByTeamLeaderId(TeamLeaderId:number):Observable<User[]>  {
   
    // return this.http.get("http://localhost:56028/api/Users/GetUsersForTeamLeader/"+TeamLeaderId)
    return this.http.get(this.globalService.path+"Users/GetUsersForTeamLeader/"+TeamLeaderId)
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

  AddNewUser(user:User,userId:number):Observable<any>{
    debugger;
    //return this.http.post("http://localhost:56028/api/Users/"+userId,user) .map((res:User)=>res)
    return this.http.post(this.globalService.path+"Users/AddUser/"+userId,user) .map((res:any)=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));;

  }

  EditUser(user:User,userId:number){
    debugger;
    // return this.http.put("http://localhost:56028/api/Users/"+userId,user);
    return this.http.put(this.globalService.path+"Users/UpdateUser",user);
  }

DeleteUser(id:number,userId:number){
  debugger;
 // return this.http.delete("http://localhost:56028/api/Users/"+id+"/"+userId);
  return this.http.delete(this.globalService.path+"Users/DeleteUser/"+id+"/"+userId);
}

GetUserById(id:number):Observable<User>{
 // return this.http.get("http://localhost:56028/api/Users/GetUserById/"+id)
  return this.http.get(this.globalService.path+"Users/GetUserById/"+id)
  .map((res:User)=>res)
  .catch((r:HttpErrorResponse)=>Observable.throw(r));
}


VerifyUserName(userName:string){
  // return this.http.get("http://localhost:56028/api/Users/VerifyEmail/"+userName)
  return this.http.get(this.globalService.path+"Users/VerifyEmail/"+userName)
  .map((res:any)=>"ok")
  .catch((res:any)=>"error");
 
}


VerifyPassword(pass:string,userName:string):Observable<any>
{ debugger;
  return this.http.get(this.globalService.path+"Users/VerifyPassword/"+pass+"/"+userName)
 
  //return this.http.get("http://localhost:56028/api/Users/VerifyPassword/"+pass+"/"+userName)
  .map((res:User)=>res)
  .catch((r:HttpErrorResponse)=>"error");
}


EditPassword(user:User){

  //return this.http.put("http://localhost:56028/api/Users/EditPassword",user)
  return this.http.put(this.globalService.path+"Users/EditPassword",user)
  .map((res:any)=>"ok")
  .catch((res:any)=>"e");

  
}
}

