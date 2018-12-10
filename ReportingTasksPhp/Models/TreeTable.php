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
//       $this->DetailsWorkerInProjects=new DetailsWorkerInProjects($sqlRaw_)
//            $this->Project = array();
//            $this->Project["ProjectId"] = $sqlRaw_['project_id'];
//            $this->Project["ProjectName"] = $sqlRaw_['project_name'];
//            $this->Project["ClientName"] = $sqlRaw_['client_name'];
//            $this->Project["TeamLeaderId"] = $sqlRaw_['team_leader_id'];
//            $this->Project["DevelopersHours"] = $sqlRaw_['develope_hours'];
//            $this->Project["QaHours"] = $sqlRaw_['qa_hours'];
//            $this->Project["UiUxHours"] = $sqlRaw_['ui/ux_hours'];
//            $this->Project["StartDate"] = $sqlRaw_['start_date'];
//            $this->Project["FinishDate"] = $sqlRaw_['finish_date'];
//            $this->Project["IsActive"] = $sqlRaw_['is_active'];
//            $this->Project["User"] = array();
//            $this->Project["User"]["UserName"] = $sqlRaw_['user_name'];
//              $this->Project["User"]["UserId"] = $sqlRaw_['user_id'];
        }
    }

    public function jsonSerialize() {
        return get_object_vars($this);
    }

}
