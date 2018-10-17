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
    * date - int, requiered
### Global Properties
* `List<User>`
* `List<Game>`

### Controllers
* User controller:
    * Post - sign in to a new game    
    requierd data: 
        * userName
        * age
    If the user is valid - we will add him to the UserList, and return true, Else - we will return a matching error
    * Get - get the list of the users that looks for a partner to the game (all the users that contains `null` in the `PartnerUserName` property)
    * Get - get the details of the current user
    * Put - The client sends a userName that he choosed to a partner.
    The server will update his details to the chosen partner. And the `PartnerUserName` property of chosen partner, to his name.   
    If the update completed succefuly - return true, And craete a new `Game` object with the 2 users as players, and the current userName as the `CurrentTurn`  
    Else - return a matching error.
* Game controller:
    * Get - get all cards and `CurrentTurn`
    * Put - The client sends a userName and the chosen cards results.
    The server will update the `Game` object `CurrentTurn` to the other player's name.   
    If the user managed to choose 2 cards with the same value - we will update the element in the `CardArray` that has the key of this card content - to the current user name.
    After the update it will check if the game is over (all the element in the `CardArray` contains value), If yes - the winner usrt will get 1 point to the `score` property.

***
## WinForms +  Angular
![picture](step2.png)   
![picture](step3.png)   
![picture](step4.png)   
![picture](step5.png)   

