<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of WorkerToProject
 *
 * @author EdelsteinT
 */
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
