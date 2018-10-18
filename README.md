# Reporting-tasks-project
## Using this technologies:
* Web api
* WinForms
* Angular

## System diagram:
![picture](step1.png)

***
## Web api
### Models
* User:
    * UserId - int, requiered,unique, identity
    * UserName - string - minLength: 2, maxLength:10, reqiered
    * UserEmail - string - pattern:email pattern, reqiered
    * Password - string -  minLength: 6, maxLength:10, reqiered
    * TeamLeaderId -int, optional
    * UserKindId-int,requiered
* UserKind:
    * KindUserId - int, requiered,unique, identity
     * KindUserName - string, requiered,
 * Access:
    * AccessId - int, requiered,unique, identity
    * AccessName - string, reqiered
* UserKindToAccess:
    * UserKindToAccessId - int, requiered,unique, identity
    * userKindId - int, requiered
    * AccessId - int, requiered
* Projects:
    * ProjectId - int, requiered,unique, identity
    * ProjectName - string,reqiered
    * ClientName - string,reqiered
    * TeamLeaderId- int reqiered
    * DevelopersHours -int,reqiered
    * QaHours -int,reqiered
    * Ui/UxHours -int,reqiered 
    * StartDate -date,reqiered 
    * FinishDate -date,reqiered 
 * WorkerToProject:
    * WorkerToProjectId - int, requiered,unique, identity
    * UserId - int, requiered
    * ProjectId - int, requiered 
    * Hours - int, requiered 
 * ActualHours:
    * ActualHoursId - int, requiered,unique, identity
    * UserId - int, requiered
    * ProjectId - int, requiered 
    * CountHours - double, requiered 
    * date - date, requiered


### Controllers
* User controller:
    * Get -getAllUsers
      We will return all the users from the db.
    
    * Post - Register    
    requierd data: 
      *User
    If the user is valid - we will add him to the db, and return true, Else - we will return a matching error
    * Get - Login
      requierd data: 
        * UserName 
        * Password 
     If the user whith the UserName and Password is exist in the db we will return the UserId object, Else - we will return not found.
    * Get - GetUserById
      requierd data: 
        * UserId
    If there is in the db user with this UserId ,we will return the user object ,Else we will return not found.
    * Put - update user
       requierd data: 
        * User
     If there is in the db user object whith the same user_id and the new user object is valid - we will update the user in the db to this user, Else - we will return matching error.

    * Delete - remove user
       requierd data: 
        * UserId
    If a user with this UserId is exist in the db - we will dellete him, Else we will return matching error.
    
   
* UserKind controller:
    * Get - get all the user kinds  
      We will return all the users kinds from the db.
* Access controller:
    * Get - get all the access
     We will return all the access from the db.

* AccessToUserKind controller:
    * Get - get access by UserKindId
      requierd data: 
        *UserKindId
    If the UserKindId is exist in the db - we will return all the access that belong to this user kind, Else - return matching error.

* Project controller:
    * Get - get all Projects
      We will return all the projects that exist in the db.
    * Post - add project    
        requierd data: 
        *Project
        *currentUserId

    If the user that his id equal to the currentUserId has the access to add new project, and the project id valid - we will add the new project to the db, Else - we will return a matching error.

    * Put - update project
       requierd data: 
        *Project
        *currentUserId
    If the user that his id equal to the currentUserId has the accessto update  projects, and a project with the same id to the project date is found, we will update this project to the new project object, Else - we will return matching error.
    * Delete 
        requierd data: 
          *ProjectId
    If there is the db project with id that equals ProjectId - we will delete it from the db, Else - we will return matching error.
    * Get - get projects by team leader id
        requierd data: 
           *TeamLeaderId
    If user with id -TeamLeaderId is exist in the db , we will return all the projects that belongs to him, Else - we will return matching error.

    

* Hours controller:
    * Get - get actual hours count to project
       requierd data: 
           *ProjectId
     If the ProjectId is exist, we will return all the hours that belong to it, Else - we will return matching error.

    * Get - get hours on month to user
        requierd data: 
           *UserId
     If the UserId is exist, we will return all the hours that belong to him, Else - we will return matching error.

    * Post - add 
     requierd data: 
           *ActualHours (object)
     If the ActualHours object is valid, we will add it to the db, Else we will return matchig error.
    * Get - get hours to project by user kind (Example:get all the QA hours that have done to project 1)
       requierd data: 
           *ProjectId
           *UserKindId
       We will select and return all the hours that belongs to this project (project id is equals to ProjectId) and their user(get it by user id) kind is UserKindId. If we wont find we will return matching error;


* WorkerToProject controller:
    * Get - get projects by UserId
       requierd data: 
           *UserId
       We will return all the projects that belong to the User with id UserId or matching error.
    * Get - get workers by projectId
       requierd data: 
           *ProjectId
       We will return all the workers that belong to the project with id ProjectId or matching error.
    * Post - add new worker to project
       requierd data: 
           *WorkerToProject (object)
       If the WorkerToProject object is valid, we will add it to the db, Else we will return matchig error.
    * Put - updete details of worker to project record .
        requierd data: 
        *WorkerToProject
        *currentUserId
    If the user that his id equal to the currentUserId has the access to update  WorkerToProject records, and a WorkerToProject with the same id to the WorkerToProject id is found, we will update this WorkerToProject to the new WorkerToProject object, Else - we will return matching error.
    * Delete
     requierd data: 
        *WorkerToProjectId
        *currentUserId
    If the user that his id equal to the currentUserId has the access to delete  WorkerToProject records, and a WorkerToProject with the same id to the WorkerToProject id is found, we will delete this WorkerToProject from the db, Else - we will return matching error.
***
## WinForms +  Angular
![picture](step2.png)   
![picture](step3.png)   
![picture](step4.png)   
![picture](step5.png)   

