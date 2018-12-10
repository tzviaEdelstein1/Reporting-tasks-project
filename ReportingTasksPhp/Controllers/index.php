
<?php

//header("Access-Control-Allow-Origin: *");
//header("Access-Control-Request-Headers: *");
header("Access-Control-Allow-Origin: *");
header('Content-type: application/json');
header("Access-Control-Allow-Headers: Origin, X-Requested-With,Content-Type, Accept");
$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
$path = parse_url($link, PHP_URL_PATH);
//include '../includes.php';
require '../Controllers/HoursController.php';
require '../Controllers/ProjectsController.php';
require '../Controllers/SendEmailController.php';
require_once  '../Controllers/TreeTableController.php';
require_once '../Controllers/UserController.php';
require '../Controllers/UserKindsController.php';
require '../Controllers/WorkerToProjectController.php';
$exploded_path = explode('/', $path);
$controller_name = $exploded_path[4];
$method_name = $exploded_path[5];
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $entityBody = file_get_contents('php://input');
     // The request is using the POST method
}
else if ($_SERVER['REQUEST_METHOD'] === 'GET') {
   $entityBody=null;
     // The request is using the POST method
}

else if($_SERVER['REQUEST_METHOD'] === 'PUT')
{
    
    $entityBody = file_get_contents('php://input');
    
}
else if ($_SERVER['REQUEST_METHOD'] === 'DELETE') {
   $entityBody=null;
     // The request is using the POST method
}

switch ($controller_name) {
    //manager
    case "users":
        runFunctionUser($method_name, $exploded_path,$entityBody);
        break;
    case "projects":
        runFunctionProject($method_name, $exploded_path,$entityBody);
        break;
    case "treeTable":
    runFunctionTreeTable($method_name, $exploded_path,$entityBody);
           break;
    case "workerToProject":
        runFunctionWorkerToProject($method_name, $exploded_path, $entityBody);
        break;
      case "userKinds":
        runFunctionUserKinds($method_name, $exploded_path, $entityBody);
        break;  
       case "actualHours":
        runFunctionActualHours($method_name, $exploded_path, $entityBody);
        break;  
    default:
        var_dump(http_response_code(404));
        die("no such funcation");
}
die();

