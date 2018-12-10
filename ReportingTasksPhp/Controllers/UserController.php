<?php

$user;

require_once '../Connection/DbAccess.php';
require '../Models/Globaly.php';
//require'../Models/User.php';
function runFunctionUser($method, $params, $entityBody) {
    switch ($method) {
        case "GetAllUsers":GetAllUsers();
            break;
        case "GetTeamLeaders":GetTeamLeaders();
            break;
        case "GetUsersForTeamLeader":GetUsersForTeamLeader($params[6]);
            break;
        case "VerifyEmail":VerifyEmail($params[6]);
            break;
        case "VerifyPassword":VerifyPassword($params[6]);
            break;
        case "GetUserById":GetUserById($params[6]);
            break;
        case "AddUser":AddUser($entityBody);
            break;
        case "Login":
            Login($params[6], $params[7]);
            break;
        case "UpdateUser":
            UpdateUser($entityBody);
            break;
        case "DeleteUser":
            DeleteUser($params[6]);
            break;
        case "EditPassword":
            EditPassword($entityBody);
            break;
        case "CheckUserIp":
            CheckUserIp($entityBody);
            break;
        case "Logout":
            Logout();
            break;
    }
}
function GetAllUsers() {
    $query = "SELECT * FROM tasks.users";
    echo json_encode(db_access::run_reader($query, "User"));
}
function VerifyEmail($userName)
{
    $query = "SELECT * FROM tasks.users where user_name='$userName'";
    //$GLOBALS["user"] = db_access::run_reader($query, "User");
   $GLOBALS["user"]=json_encode(db_access::run_reader($query, "User")[0]);
     //echo $user;  
     $userJson= json_decode($GLOBALS["user"],true);
    // echo $userJson["UserEmail"];

   // echo json_encode($GLOBALS["user"]);
   // echo json_encode($GLOBALS["user"]["UserEmail"]);
   // SendEmail($GLOBALS["user"][0]["user_email"]);
   sendEmail($userJson["UserEmail"]);
}

function GetTeamLeaders() 
{
    $query = "SELECT * FROM tasks.users WHERE user_kind_id=2";
    echo json_encode(db_access::run_reader($query, "User"));
}
function GetUsersForTeamLeader($teamLeaderId) {
    $query = "SELECT * FROM tasks.users where team_leader_id='$teamLeaderId'";
      echo json_encode(db_access::run_reader($query, "User"));
}

function sendEmail($emailTo) {
//    echo 'email';
    $_SESSION['make'] = generatePassword();
    $msg = "First line of textSecond line of text";
    //mail($emailTo, "My subject", $msg);
        mail($emailTo, "My subject", $_SESSION['make'] );  
}

function generatePassword($length = 8) {
    $chars = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    $count = mb_strlen($chars);

    for ($i = 0, $result = ''; $i < $length; $i++) {
        $index = rand(0, $count - 1);
        $result .= mb_substr($chars, $index, 1);
    }
    echo $result;
    return $result;
}

function VerifyPassword($password) {
    echo $_SESSION['make'];
    echo 'ccc';
//    if ($password == $GLOBALS["body"]) {
//        echo $GLOBALS["user"];
//    }
}
function AddUser($entityBody)
{
     $decoded_input = json_decode($entityBody, true);    
      $UserId = $decoded_input["UserId"];
    $UserName = $decoded_input["UserName"];
    $UserEmail = $decoded_input["UserEmail"];
    $Password = $decoded_input["Password"];
    $TeamLeaderId = $decoded_input["TeamLeaderId"];
    $UserKindId = $decoded_input["UserKindId"];


    $query = "INSERT INTO tasks.users(`user_name`, `user_email`, `password`, `team_leader_id`, `user_kind_id`) VALUES ('$UserName','$UserEmail','$Password',$TeamLeaderId,$UserKindId)";
    db_access::run_non_query($query);
}
function GetUserById($userId) {
    echo $userId;
    $query = "SELECT * FROM tasks.users WHERE user_id='$userId'";
    $user = db_access::run_reader($query, "User");
    echo json_encode($user);
    if ($user != NULL) {
        return $user[0];
    }
}
function Login($userName,$password) {
    if($userName and $password)
{
//    $password = hash('sha256',$password);
 $query = "SELECT * FROM tasks.users WHERE user_name='$userName' and password='$password'";
   $user=db_access::run_reader($query, "User")[0]; 
echo json_encode($user);

    }
}

function UpdateUser($entityBody) {
    $decoded_input = json_decode($entityBody, true);

    $UserId = $decoded_input["UserId"];
    $UserName = $decoded_input["UserName"];
    $UserEmail = $decoded_input["UserEmail"];

    $TeamLeaderId = $decoded_input["TeamLeaderId"];
    $UserKindId = $decoded_input["UserKindId"];


    $query = "UPDATE `tasks`.`users` SET `user_name` = '$UserName', `user_email` = '$UserEmail', `team_leader_id` = '$TeamLeaderId', `user_kind_id` = '$UserKindId' WHERE (`user_id` = '$UserId');";

    db_access::run_non_query($query);
    echo 0;
}

function DeleteUser($id) {
    $query1 = "DELETE FROM tasks.actual_hours WHERE user_id='$id'";
    db_access::run_non_query($query1);
    $query2 = "DELETE FROM tasks.worker_to_project  WHERE  user_id='$id'";
    db_access::run_non_query($query2);
    $query3 = "DELETE FROM tasks.users  WHERE  user_id='$id'";
    db_access::run_non_query($query3);
    echo 0;
}

//לא בדקתי עם אנגולר
function EditPassword($entityBody) {
    echo 'EditPassword';
    $decoded_input = json_decode($entityBody, true);

    $UserId = $decoded_input["UserId"];
    $Password = $decoded_input["Password"];
    $query = "UPDATE tasks.users SET password='$Password' WHERE user_id='$UserId'";

    db_access::run_non_query($query);
    echo 0;
}
//לא נבדק בקליינט---רק לווינפורם 
function CheckUserIp($ip) {
    $query = "SELECT * FROM tasks.users WHERE user_ip=$ip";
    $user = db_access::run_reader($query, "User");
    if (count($user) == 1)
        echo json_encode($user[0]);
    else
        echo "error";
}

function Logout($param) {
    //רק בווינפורם לכן לא עשינו לבינתיים
}