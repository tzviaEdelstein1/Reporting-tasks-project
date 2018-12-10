<?php
$treeTable;
//require '../Connection/DbAccess.php';
//require_once '../Models/TreeTable.php';
require_once'../Connection/DbAccess.php';
function runFunctionTreeTable($method, $params) {
    switch ($method) {
        
        case "TreeTable":TreeTable();
            break; 
    }
}
function TreeTable(){
 $query = "SELECT p.*,user_id,user_name FROM tasks.projects P  JOIN tasks.users u ON u.user_id=p.team_leader_id ";
   // $query="SELECT * FROM tasks.projects";
   echo json_encode(db_access::run_reader($query, "TreeTable"),JSON_NUMERIC_CHECK);
// echo json_encode($treeTable);
//    FillHoursToTreeTable();
}
function FillHoursToTreeTable()
{
  foreach ($treeTable as $value) {
      echo $value;
    }
//        $query = "SELECT hours,user_kinds_name,u.user_name,u.user_id ,us.user_name teamLeadername FROM tasks.worker_to_project W JOIN tasks.users u ON w.user_id=u.user_id JOIN tasks.user_kinds uk ON u.user_kind_id=uk.user_kinds_id  JOIN tasks.users us ON u.team_leader_id=us.user_id where project_id={item.Project.ProjectId}";
//    echo json_encode(db_access::run_reader($query, "User"));
}
