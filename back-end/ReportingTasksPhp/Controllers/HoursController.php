<?php
require_once '../Connection/DbAccess.php';
function runFunctionActualHours($method, $params,$entityBody) {
    switch ($method) {
        case "AddActualHours":
           
            AddActualHours($entityBody);
            break;  
    }
}

function AddActualHours($entityBody)
{
   // echo $entityBody;
    
     $decoded_input = json_decode($entityBody, true);    
     print_r($decoded_input);
    // file_put_contents("test.txt",$ActualHoursId+"  ");
    $UserId = $decoded_input["UserId"];
   
    $ProjectId = $decoded_input["ProjectId"];
     
    $CountHours = $decoded_input["CountHours"];
    
 $date=$decoded_input["date"];
 

$d= date_format($date,"Y-m-d");
file_put_contents("test.txt",$d+"  ");
$year = date("Y");
// file_put_contents("test.txt",$year+"  ");
 $month = date("m");

 $day = date("d");
$allDate="'$year'-'$month'-'$day'";
  
    $query = "INSERT INTO `tasks`.`actual_hours`(`user_id`, `project_id`, `count_houers`, `date`) VALUES ('$UserId','$ProjectId','$CountHours','$d')";
  
    db_access::run_non_query($query);
}
//{actualHours.date.Year}-{actualHours.date.Month}-{actualHours.date.Day}
