<?php

require_once '../Connection/DbAccess.php';

//require'../Models/User.php';
function runFunctionWorkerToProject($method, $params, $entityBody) {
    switch ($method) {
        case "GetProjectsbyUserName":GetProjectsbyUserName($params[6]);
            break;
        case "GetWorkersToProjectByProjectId":GetWorkersToProjectByProjectId($params[6]);
            break;
        case "GetWorkerToProjectByPidAndUid":GetWorkerToProjectByPidAndUid($params[6], $params[7]);
            break;
          case "AddWorkerToProject":AddWorkerToProject($entityBody);
            break;
        case "UpdateWorkerToProject":
            UpdateWorkerToProject($entityBody);
            break;;
        
    }
}

function GetProjectsbyUserName($userName) {
    $query = "SELECT * FROM tasks.projects p JOIN tasks.worker_to_project w on p.project_id = w.project_id WHERE w.user_id =(SELECT user_id FROM tasks.users WHERE user_name='$userName')";
    echo json_encode(db_access::run_reader($query, "Project"));
}

function GetWorkersToProjectByProjectId($projectId) {
    $query = "SELECT * FROM tasks.worker_to_project WHERE project_id=$projectId";
    echo json_encode(db_access::run_reader($query, "WorkerToProject"));
}

function GetWorkerToProjectByPidAndUid($projectId, $userId) {
    $query = "SELECT * FROM tasks.worker_to_project WHERE project_id='$projectId' AND user_id='$userId'";
    echo json_encode(db_access::run_reader($query, "WorkerToProject"));
}

function AddWorkerToProject($entityBody) {
    $decoded_input = json_decode($entityBody, true);
    $UserId = $decoded_input["UserId"];
    $ProjectId = $decoded_input["ProjectId"];
    $query = "INSERT INTO `tasks`.`worker_to_project` (`user_id`, `project_id`) VALUES ('$UserId','$ProjectId')";
    echo $query;
    db_access::run_non_query($query);
}
function UpdateWorkerToProject($entityBody){
     $decoded_input = json_decode($entityBody, true);
    
    $WorkerToProjectId=$decoded_input["WorkerToProjectId"];
    $UserId = $decoded_input["UserId"];
    $ProjectId = $decoded_input["ProjectId"];
    $Hours = $decoded_input["Hours"];
   
    
      $query="UPDATE `tasks`.`worker_to_project` SET `user_id` = '$UserId', `project_id` = '$ProjectId', `hours` = '$Hours' WHERE (`worker_to_project_id` = '$WorkerToProjectId');";

      db_access::run_non_query($query);
      echo  0;
}
