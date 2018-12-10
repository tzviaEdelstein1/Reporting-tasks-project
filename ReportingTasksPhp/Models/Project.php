<?php

class Project implements JsonSerializable {

    public $ProjectId;
    public $ProjectName;
    public $ClientName;
    public $TeamLeaderId;
    public $DevelopersHours;
    public $QaHours;
    public $UiUxHours;
    public $StartDate;
    public $FinishDate;
    public $User;
    public $IsActive;

    public function __construct($sqlRaw_) {
 
        $this->ProjectId = $sqlRaw_['project_id'];
        $this->ProjectName = $sqlRaw_['project_name'];
        $this->ClientName = $sqlRaw_['client_name'];
        $this->TeamLeaderId = $sqlRaw_['team_leader_id'];
        $this->DevelopersHours = $sqlRaw_['develope_hours'];
        $this->QaHours = $sqlRaw_['qa_hours'];
        $this->UiUxHours = $sqlRaw_['ui/ux_hours'];
        $this->StartDate = $sqlRaw_['start_date'];
        $this->FinishDate = $sqlRaw_['finish_date'];
//        $this->IsActive = $sqlRaw_['is_active'];
     $this->User = new User($sqlRaw_);
//        if (array_key_exists('user_name', $sqlRaw_))


        
    }

/////היוזר מאותחל רק בid לעת עתה
    public function jsonSerialize() {
        return get_object_vars($this);
    }

}
