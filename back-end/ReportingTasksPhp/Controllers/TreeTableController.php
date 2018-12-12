<?php
$treeTable;
//require '../Connection/DbAccess.php';
//require_once '../Models/TreeTable.php';
require_once'../Connection/DbAccess.php';
function runFunctionTreeTable($method, $params) {
    switch ($method) {
        
        case "GetTreeTable":GetTreeTable();
            break; 
    }
}
function GetTreeTable(){
 $query = "SELECT p.*,user_id,user_name FROM tasks.projects P  JOIN tasks.users u ON u.user_id=p.team_leader_id ";

   echo json_encode(db_access::run_reader($query, "TreeTable"),JSON_NUMERIC_CHECK);

}


