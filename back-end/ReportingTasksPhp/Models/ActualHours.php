<?php

class ActualHours implements JsonSerializable {

    public $ActualHoursId;
    public $UserId;
    public $ProjectId;
    public $CountHours;
    public $date;
    public function __construct($sqlRaw_) {
        $this->ActualHoursId = $sqlRaw_['actual_hours_id'];
        $this->UserId = $sqlRaw_['user_id'];
        $this->ProjectId = $sqlRaw_['project_id'];
        $this->CountHours = $sqlRaw_['count_houers'];
        $this->date = $sqlRaw_['date'];
    }
    public function jsonSerialize() {
        return get_object_vars($this);
    }

}
