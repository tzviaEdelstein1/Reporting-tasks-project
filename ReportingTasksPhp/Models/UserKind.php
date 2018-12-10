<?php

class UserKind {
    
     public $KindUserId;
    public $KindUserName;
     public function __construct($sqlRaw_) {    
         $this->KindUserId = $sqlRaw_['user_kinds_id'];
         $this->KindUserName = $sqlRaw_['user_kinds_name'];          
    }
    public function jsonSerialize() {
        return get_object_vars($this);
    }
}
