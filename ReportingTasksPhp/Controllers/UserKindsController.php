<?php
require_once '../Connection/DbAccess.php';
function runFunctionUserKinds($method, $params,$entityBody) {
    echo $method;
    switch ($method) {
        case "Get":
            Get();          
            break;
    }
}
function Get() {
    $query = "SELECT * FROM tasks.user_kinds WHERE user_kinds_id!=1";
    echo json_encode(db_access::run_reader($query, "UserKind"));
}
