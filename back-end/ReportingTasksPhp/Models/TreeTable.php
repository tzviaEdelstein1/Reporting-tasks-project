<?php

class TreeTable implements JsonSerializable {

    public $Project;
    public $DetailsWorkerInProjects;

    public function __construct($sqlRaw_) {

        if (array_key_exists('project_name', $sqlRaw_)) {

            $this->Project = new Project($sqlRaw_);

            $id = $sqlRaw_["project_id"];
            $query = "SELECT project_id,hours,user_kinds_name,u.user_name,u.user_id ,us.user_name teamLeadername FROM tasks.worker_to_project W JOIN tasks.users u ON w.user_id=u.user_id JOIN tasks.user_kinds uk ON u.user_kind_id=uk.user_kinds_id  JOIN tasks.users us ON u.team_leader_id=us.user_id where project_id='$id'";
            $this->DetailsWorkerInProjects = db_access::run_reader($query, "DetailsWorkerInProjects");

        }
    }

    public function jsonSerialize() {
        return get_object_vars($this);
    }

}
