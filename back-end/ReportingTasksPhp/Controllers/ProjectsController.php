<?php

require_once '../Connection/DbAccess.php';
require_once '../Models/Project.php';
require_once '../Models/User.php';

function runFunctionProject($method, $params, $entityBody) {

    switch ($method) {
        case "GetAllProjects":
            GetAllProjects();
            break;
        case "GetActiveProjects":
            GetActiveProjects();
            break;
        case "GetProjectsByTeamId":
            GetProjectsByTeamId($params[6]);
            break;
        case "GetProjectsByUserId":
            GetProjectsByUserId($params[6]);
            break;
        case "GetProjectsAndHoursByUserId":
            GetProjectsAndHoursByUserId($params[6]);
            break;
        case "GetProjectsAndHoursByUserIdAccordingTheMonth":
            GetProjectsAndHoursByUserIdAccordingTheMonth($params[6]);
            break;
        case "GetProjectsAndHoursByProjectId":
            GetProjectsAndHoursByProjectId($params[6]);
            break;
        case "GetProjectsAndHoursByTeamLeaderId":
            GetProjectsAndHoursByTeamLeaderId($params[6]);
            break;
        case "AddProject":
             AddProject($entityBody);
             break;
         case "UpdateProject":
             UpdateProject($entityBody);
             break;
    }
}

function GetAllProjects() {


    $query = "SELECT * FROM tasks.projects";
    echo json_encode(db_access::run_reader($query, "Project"));
}

function GetActiveProjects() {
    $query = "SELECT * FROM tasks.projects WHERE is_active=1";
    echo json_encode(db_access::run_reader($query, "Project"));
}

function GetProjectsByTeamId($teamId) {
    $query = "SELECT * FROM tasks.projects WHERE team_leader_id='$teamId'";
    echo json_encode(db_access::run_reader($query, "Project"));
}

function GetProjectsByUserId($userId) {
    $query = "SELECT * FROM tasks.projects p JOIN TASKS.worker_to_project w ON p.project_id=w.project_id WHERE user_id='$userId' AND is_active=1";
    echo json_encode(db_access::run_reader($query, "Project"));
}

function GetProjectsAndHoursByUserId($userId) {
    $query = "SELECT a.project_id AS id,project_name AS obj_name,hours,sum(count_houers) AS actual FROM tasks.actual_hours a JOIN tasks.projects p ON a.project_id = p.project_id JOIN TASKS.worker_to_project w ON w.project_id = a.project_id WHERE a.user_id ='$userId' AND is_active=1 group by a.project_id,a.user_id";
    echo json_encode(db_access::run_reader($query, "Unknown"));
}

function GetProjectsAndHoursByUserIdAccordingTheMonth($userId) {
    $year = date("Y");

    $month = date("m");

    $query = "SELECT a.project_id AS id,project_name AS obj_name,hours,sum(count_houers) AS actual 
              FROM tasks.actual_hours a JOIN tasks.projects p ON a.project_id = p.project_id JOIN TASKS.worker_to_project w ON w.project_id = a.project_id
              WHERE is_active=1 AND a.user_id ='$userId' AND YEAR(date)='$year'
              AND MONTH(date)='$month'
              group by a.user_id,a.project_id";
    echo json_encode(db_access::run_reader($query, "Unknown"));
}

function GetProjectsAndHoursByProjectId($projectId) {
    $query = "SELECT a.user_id AS id,u.user_name AS obj_name, w.hours,sum(count_houers) AS actual 
           FROM tasks.users u JOIN TASKS.worker_to_project w ON u.user_id = w.user_id
            JOIN tasks.actual_hours a ON a.user_id = u.user_id
            WHERE a.project_id = '$projectId' 
            group by a.user_id, a.project_id";

    echo json_encode(db_access::run_reader($query, "Unknown"));
}

function GetProjectsAndHoursByTeamLeaderId($teamId) {
    $year = date("Y");

    $month = date("m");
    $query = "SELECT a.user_id AS id,u.user_name AS obj_name, w.hours,sum(count_houers) AS actual 
    FROM tasks.users u JOIN TASKS.worker_to_project w ON u.user_id = w.user_id
    JOIN tasks.actual_hours a ON a.user_id = u.user_id
    WHERE team_leader_id = '$teamId' AND YEAR(date)='$year' AND MONTH(date)='$month'
    group by a.user_id";
    echo json_encode(db_access::run_reader($query, "Unknown"));
}

function AddProject($entityBody) {
    
    //echo $entityBody;
    $decoded_input = json_decode($entityBody, true);
    print_r($decoded_input);
    $ProjectName = $decoded_input["ProjectName"];
    $ClientName = $decoded_input["ClientName"];
    $TeamLeaderId = $decoded_input["TeamLeaderId"];
    $DevelopersHours = $decoded_input["DevelopersHours"];
    $QaHours = $decoded_input["QaHours"];
    $UiUxHours = $decoded_input["UiUxHours"];
    $StartDate = $decoded_input["StartDate"];
    $FinishDate = $decoded_input["FinishDate"];
    $IsActive = 1;


    $query2 = "INSERT INTO `tasks`.`projects` (`project_name`, `client_name`, `team_leader_id`, `develope_hours`, `qa_hours`, `ui/ux_hours`, `start_date`, `finish_date`, `is_active`) VALUES ('$ProjectName', '$ClientName', '$TeamLeaderId', '$DevelopersHours', '$QaHours', '$UiUxHours', '$StartDate', '$FinishDate', '$IsActive');";
    echo $query2;
    $newProjectId=  db_access::run_non_query($query2,1);
 
    $query3 = "SELECT user_id FROM tasks.users WHERE team_leader_id='$TeamLeaderId'";
    $usersToProject = json_encode(db_access::run_reader($query3, "User"));
    $arrUsers=json_decode($usersToProject, true);
    $i=0;
    while ($i<count($arrUsers))
    {
    $userId=$arrUsers[$i]["UserId"];
    $addWorkerQuery="INSERT INTO `tasks`.`worker_to_project` (`user_id`, `project_id`, `hours`) VALUES ('$userId', '$newProjectId', '0');";
    echo  db_access::run_non_query($addWorkerQuery);
    $i++;
    
    }
}
function UpdateProject($entityBody){
   file_put_contents("test.txt","upppppppppppppppppdate"+"  ");
    $decoded_input = json_decode($entityBody, true);
    
    $ProjectId=$decoded_input["ProjectId"];
//    file_put_contents("test.txt", __LINE__+"  ");
    $ProjectName = $decoded_input["ProjectName"];
    $ClientName = $decoded_input["ClientName"];
    $TeamLeaderId = $decoded_input["TeamLeaderId"];
    $DevelopersHours = $decoded_input["DevelopersHours"];
    $QaHours = $decoded_input["QaHours"];
    $UiUxHours = $decoded_input["UiUxHours"];
    $StartDate = $decoded_input["StartDate"];
    $FinishDate = $decoded_input["FinishDate"];
    $IsActive = $decoded_input["IsActive"];
if($IsActive=="false")
    $active=1;
else {
$active=0;
}  

   $query="UPDATE `tasks`.`projects` SET `project_name` = '".$ProjectName."', `client_name` = '".$ClientName."', `team_leader_id` = '".$TeamLeaderId."', `develope_hours` = '".$DevelopersHours."', `qa_hours` = '".$QaHours."', `ui/ux_hours` = '".$UiUxHours."', `start_date` = '".$StartDate."', `finish_date` = '".$FinishDate."',`is_active` = '".$active."' WHERE (`project_id` = '".$ProjectId."');";
   file_put_contents("test.txt", $query);
   db_access::run_non_query($query,$entityBody);
echo  0;
}
