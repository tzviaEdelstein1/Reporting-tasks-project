<?php


class WorkerToProject implements JsonSerializable{
  public $WorkerToProjectId;
    public $UserId;
    public $ProjectId;
    public $Hours;
     public function __construct($sqlRaw_) {    
         $this->WorkerToProjectId = $sqlRaw_['worker_to_project_id'];
         $this->UserId = $sqlRaw_['user_id']; 
         $this->ProjectId = $sqlRaw_['project_id']; 
         $this->Hours = $sqlRaw_['hours'];   
    }
    public function jsonSerialize() {
        return get_object_vars($this);
    }   
}
