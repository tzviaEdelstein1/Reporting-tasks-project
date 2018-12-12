<?php

class Unknown implements JsonSerializable {

    public $Id;
    public $Name;
    public $Hours;
    public $allocatedHours;

    public function __construct($sqlRaw_) {

//ל נבדק על כל הסוגיםא 
        $this->Id = $sqlRaw_['id'];
        $this->Name = $sqlRaw_['obj_name'];
        $this->Hours = $sqlRaw_['hours'];
        $this->allocatedHours = $sqlRaw_['actual'];
    }

    public function jsonSerialize() {
        return get_object_vars($this);
    }

}

