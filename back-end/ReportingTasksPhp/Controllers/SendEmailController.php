<?php
require_once '../Connection/DbAccess.php';
function runFunctionSendEmail($method, $params, $entityBody) {
    switch ($method) {
        case "SendEmail":
    
            SendEmail($params[6]);
            break;
    }
}
function SendEmail($emailBody)
{ 

    $query = "SELECT * FROM tasks.users where user_kind_id=1";
        file_put_contents("test.txt",$query);
    $user=json_encode(db_access::run_reader($query, "User")[0]);
      $userJson = json_decode($user, true);
      $emailTo=$userJson["UserEmail"];
     file_put_contents("test.txt", $emailTo);
      $emailSubject="connect the manager";
      maill($emailTo,$emailBody,$emailSubject);
      echo 1;
}
function maill($emailTo,$emailBody,$emailSubject)
{
    mail($emailTo,$emailSubject,$emailBody);
}
