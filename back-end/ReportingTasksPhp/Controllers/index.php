
<?php

//header("Access-Control-Allow-Origin: *");
//header("Access-Control-Request-Headers: *");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Request-Headers: *");
header('Content-type: application/json');
header('Access-Control-Allow-Headers: Origin, X-Requested-With,Content-Type, Accept');
header('Access-Control-Allow-Methods: GET,PUT,POST,DELETE');
$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
$path = parse_url($link, PHP_URL_PATH);
//include '../includes.php';
require '../Controllers/HoursController.php';
require '../Controllers/ProjectsController.php';
require '../Controllers/SendEmailController.php';
require_once '../Controllers/TreeTableController.php';
require_once '../Controllers/UserController.php';
require '../Controllers/UserKindsController.php';
require '../Controllers/WorkerToProjectController.php';
$exploded_path = explode('/', $path);
$controller_name = $exploded_path[4];
$method_name = $exploded_path[5];
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $entityBody = file_get_contents('php://input');
    // The request is using the POST method
} else if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $entityBody = null;
    // The request is using the POST method
} else if ($_SERVER['REQUEST_METHOD'] === 'PUT') {

    $entityBody = file_get_contents('php://input');
}
else if ($_SERVER['REQUEST_METHOD'] === 'DELETE') {
    $entityBody = null;
    // The request is using the POST method
}

switch ($controller_name) {
    //manager
    case "Users":
        runFunctionUser($method_name, $exploded_path, $entityBody);
        break;
    case "Projects":

        runFunctionProject($method_name, $exploded_path, $entityBody);
        break;
    case "TreeTable":
        runFunctionTreeTable($method_name, $exploded_path, $entityBody);
        break;
    case "WorkerToProject":
        runFunctionWorkerToProject($method_name, $exploded_path, $entityBody);
        break;
    case "UserKinds":
        runFunctionUserKinds($method_name, $exploded_path, $entityBody);
        break;
    case "ActualHours":
        //file_put_contents("test.txt","ActualHours"+"  ");
       
        runFunctionActualHours($method_name, $exploded_path, $entityBody);
        break;

    case "SendEmail":
        runFunctionSendEmail($method_name, $exploded_path, $entityBody);
        break;

    default:
        var_dump(http_response_code(404));
        die("no such funcation");
}
die();

