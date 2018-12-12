<?php

require_once '../Connection/DbAccess.php';

function runFunctionActualHours($method, $params, $entityBody) {
    switch ($method) {
        case "AddActualHours":

            AddActualHours($entityBody);
            break;
    }
}

function AddActualHours($entityBody) {


    $decoded_input = json_decode($entityBody, true);
    $UserId = $decoded_input["UserId"];
    $ProjectId = $decoded_input["ProjectId"];
    $CountHours = $decoded_input["CountHours"];
    $date = $decoded_input["date"];


    $query = "INSERT INTO `tasks`.`actual_hours`(`user_id`, `project_id`, `count_houers`, `date`) VALUES ('$UserId','$ProjectId','$CountHours','2018-12-13')";

    db_access::run_non_query($query);
}


