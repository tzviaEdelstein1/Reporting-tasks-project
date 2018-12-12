<?php

class User implements JsonSerializable {

    public $UserId;
    public $UserName;
    public $UserEmail;
    public $Password;
    public $TeamLeaderId;
    public $UserKindId;
public $VerifyPassword;
    public function __construct($sqlRaw_) {
        if($sqlRaw_['user_id'])
        $this->UserId = $sqlRaw_['user_id'];
        else
        $this->UserId = NULL;
   if(array_key_exists('user_name',$sqlRaw_))
        $this->UserName = $sqlRaw_['user_name'];
    
        if(array_key_exists('user_email',$sqlRaw_))
        $this->UserEmail = $sqlRaw_['user_email'];
        
    if(array_key_exists('password',$sqlRaw_))
        $this->Password = $sqlRaw_['password'];
  
    if(array_key_exists('team_leader_id',$sqlRaw_))
        $this->TeamLeaderId = $sqlRaw_['team_leader_id'];
    
      if(array_key_exists('user_kind_id',$sqlRaw_))
        $this->UserKindId = $sqlRaw_['user_kind_id'];
      if(array_key_exists('verify_password',$sqlRaw_))
        $this->VerifyPassword = $sqlRaw_['verify_password'];
    }
      
    

    public function jsonSerialize() {
        return get_object_vars($this);
    }

}
