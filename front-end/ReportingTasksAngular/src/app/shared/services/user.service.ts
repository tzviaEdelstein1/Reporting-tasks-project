import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
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

  Login(userName: string, password: string):Observable<any>  {
    return this.http.get(this.globalService.path+"Users/Login/"+ userName +"/" + password)
    .map((res:any)=>res)
  

  }
  GetAllUsers():Observable<User[]>  {
      return this.http.get(this.globalService.path+"Users/GetAllUsers")
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

  GetTeamLeaders():Observable<User[]>  {
    return this.http.get(this.globalService.path+"Users/GetTeamLeaders")
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

   GetUsersByTeamLeaderId(TeamLeaderId:number):Observable<User[]>  {
    return this.http.get(this.globalService.path+"Users/GetUsersForTeamLeader/"+TeamLeaderId)
    .map((res:User[])=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));

  }

  AddNewUser(user:User,userId:number):Observable<any>{
 
    return this.http.post(this.globalService.path+"Users/AddUser/"+userId,user, {
      headers: new HttpHeaders().set('userId',userId.toString()),
    }) .map((res:Response)=>res)
    .catch((r:HttpErrorResponse)=>Observable.throw(r));;

  }

  EditUser(user:User,userId:number){
    return this.http.put(this.globalService.path+"Users/UpdateUser/"+userId,user);
  }

DeleteUser(id:number,userId:number){
  return this.http.delete(this.globalService.path+"Users/Delete/"+id+"/"+userId);
}

GetUserById(id:number):Observable<User>{
  return this.http.get(this.globalService.path+"Users/GetUserById/"+id)
  .map((res:User)=>res)
  .catch((r:HttpErrorResponse)=>Observable.throw(r));
}


VerifyUserName(userName:string){
  return this.http.get(this.globalService.path+"Users/VerifyEmail/"+userName)
  .map((res:any)=>"ok")
  .catch((res:any)=>"e");
 
}


VerifyPassword(pass:string,userName:string):Observable<any>
{
  return this.http.get(this.globalService.path+"Users/VerifyPassword/"+pass+"/"+userName)
 
  //return this.http.get("http://localhost:56028/api/Users/VerifyPassword/"+pass+"/"+userName)
  .map((res:User)=>res)
  .catch((r:HttpErrorResponse)=>"e");
}


EditPassword(user:User){

  //return this.http.put("http://localhost:56028/api/Users/EditPassword",user)
  return this.http.put(this.globalService.path+"Users/EditPassword",user)
  .map((res:any)=>"ok")
  .catch((res:any)=>"e");
}
CheckIfTeamIsAbleToDelete(userId:number)
{
  return this.http.get(this.globalService.path+"Users/CheckIfTeamIsAbleToDelete/"+userId)
  .map((res:boolean)=>res)
  .catch((r:HttpErrorResponse)=>Observable.throw(r));
}
}

