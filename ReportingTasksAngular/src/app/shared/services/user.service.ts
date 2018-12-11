import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/catch';
import { Project } from '../models/Project';
import 'rxjs/Rx';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient){ }

  Login(userName: string, password: string):Observable<any>  {

    //return this.http.get("http://localhost:56028/users/"+userName+"/"+password)
    let url="http://localhost:8080/ReportingTasksPhp/Controllers/index.php/users/Login/"+ userName +"/" + password;
    return this.http.get(url)
    .map((res:User)=>res)
    .catch((r:any)=>'0');


  }
  GetAllUsers():Observable<User[]>  {
   let url="http://localhost:8080/ReportingTasksPhp/Controllers/index.php/users/GetAllUsers"
    // return this.http.get("http://localhost:56028/api/Users/GetAllUsers")
      return this.http.get(url)
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

  GetTeamLeaders():Observable<User[]>  {
   
    return this.http.get("http://localhost:56028/api/Users/GetTeamLeaders")
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

   GetUsersByTeamLeaderId(TeamLeaderId:number):Observable<User[]>  {
   
    return this.http.get("http://localhost:56028/api/Users/GetUsersForTeamLeader/"+TeamLeaderId)
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

  AddNewUser(user:User,userId:number):Observable<User>{
    return this.http.post("http://localhost:56028/api/Users/"+userId,user) .map((res:User)=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));;

  }

  EditUser(user:User,userId:number){
    return this.http.put("http://localhost:56028/api/Users/"+userId,user);
   
  }

DeleteUser(id:number,userId:number){
  debugger;
  return this.http.delete("http://localhost:56028/api/Users/"+id+"/"+userId);
}

GetUserById(id:number):Observable<User>{
  return this.http.get("http://localhost:56028/api/Users/GetUserById/"+id)
  .map((res:User)=>res)
  .catch((r:HttpErrorResponse)=>Observable.throw(r));
}


VerifyUserName(userName:string){
  debugger;
  //return this.http.get("http://localhost:56028/api/Users/VerifyEmail/"+userName)
    return this.http.get("http://localhost:8080/ReportingTasksPhp/Controllers/index.php/users/VerifyEmail/"+userName)
  .map((res:any)=>"ok")
  .catch((res:any)=>"error");
 
}

VerifyPassword(pass:string,userName:string):Observable<any>
{ return this.http.get(" http://localhost:8080/ReportingTasksPhp/Controllers/index.php/users/VerifyPassword/"+pass+"/"+userName)
 
  //return this.http.get("http://localhost:56028/api/Users/VerifyPassword/"+pass+"/"+userName)
  .map((res:User)=>res)
  .catch((r:HttpErrorResponse)=>'error');
}

EditPassword(user:User){
  return this.http.put("http://localhost:56028/api/Users/EditPassword",user)
  .map((res:any)=>'ok')
  .catch((r:any)=>'error');

  
}
}

