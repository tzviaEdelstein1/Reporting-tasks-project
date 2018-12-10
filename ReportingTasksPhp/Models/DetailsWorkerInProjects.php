<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of DetailsWorkerInProjects
 *
 * @author EdelsteinT
 */
class DetailsWorkerInProjects implements JsonSerializable {
    public $UserId;
    public $TeamLeaderName;
    public $Name;
    public $Kind;
    public $Hours;    
    public $ProjectId;
    public $ActualHours;
    public function __construct($sqlRaw_) {    
         $this->UserId = $sqlRaw_['user_id'];
         $this->TeamLeaderName = $sqlRaw_['teamLeadername']; 
         $this->Name = $sqlRaw_['user_name']; 
         $this->Kind = $sqlRaw_['user_kinds_name']; 
         $this->Hours = $sqlRaw_['hours']; 
         $this->ProjectId=$sqlRaw_["project_id"];
         $id=$sqlRaw_["project_id"];
         $userId=$sqlRaw_["user_id"];
              $query =  "SELECT * FROM tasks.actual_hours where project_id='$id' and user_id='$userId'";
            $this->ActualHours=db_access::run_reader($query, "ActualHours");   
    }
    
    
    
    public function jsonSerialize() {
          return get_object_vars($this);
    }

}
