<?php

require_once '../Models/User.php';
require_once '../Models/Access.php';
require_once '../Models/ActualHours.php';
require_once '../Models/DetailsWorkerInProjects.php';
require_once '../Models/Project.php';
require_once '../Models/TreeTable.php';
require_once '../Models/Unknown.php';
require_once '../Models/UserKind.php';
require_once '../Models/UserKindToAccess.php';
require_once '../Models/WorkerToProject.php';
//require '../includes.php';
$dbPassword = "1234";
$dbUserName = "root";
$dbServer = "localhost:3306";
$dbName = "tasks";
$connection = new mysqli($dbServer, $dbUserName, $dbPassword, $dbName);
if ($connection->connect_errno) {
    echo 'error ddrddddd';
    //echo "Database Connection Failed. Reason: ".$connection->connect_error;
    exit("Database Connection Failed. Reason: " . $connection->connect_error);
}

class db_access {

    static function run_non_query($query, $flag = 0) {
        global $connection;
        try {
            $connection->query($query);

            //echo "Newly Created Author Id:" . $connection->insert_id;
            if ($flag == 1)
                return $connection->insert_id;
            else
            { echo 1;}
        } 
        catch (Exception $ex) {
            echo $ex;
        }
    }

    static function run_reader($query, $model) {
        global $connection;
//        $objects[];
        $resultObj = $connection->query($query);
        $objects = array();
        $ClientModel = array();
        $i = 0;
        while ($singleRowFromQuery = $resultObj->fetch_array(MYSQLI_ASSOC)) {

            switch ($model) {
                case "User":
                    array_push($objects, new User($singleRowFromQuery));
                    break;
                case "Access":
                    array_push($objects, new Access($singleRowFromQuery));
                    break;
                case "ActualHours":
                    array_push($objects, new ActualHours($singleRowFromQuery));
                    break;
                case "DetailsWorkerInProjects":
                    array_push($objects, new DetailsWorkerInProjects($singleRowFromQuery));
                    break;
                case "Project":
                    array_push($objects, new Project($singleRowFromQuery));
                    break;
                case "TreeTable":
                    array_push($objects, new TreeTable($singleRowFromQuery));
                    break;
                case "Unknown":
                    array_push($objects, new Unknown($singleRowFromQuery));
                    break;
                case "UserKind":
                    array_push($objects, new UserKind($singleRowFromQuery));
                    break;
                case "UserKindToAccess":
                    array_push($objects, new UserKindToAccess($singleRowFromQuery));

                    break;
                case "WorkerToProject":
                    array_push($objects, new WorkerToProject($singleRowFromQuery));
                    break;
                default:
                    break;
            }
        }

        return $objects;

    }

    static function run_scalar($query) {
        global $connection;
        $resultObj = $connection->query($query);
        return $resultObj;
    }

}
