import { Component, OnInit } from '@angular/core';
import { SendEmailService } from 'src/app/shared/services/send-email.service';

@Component({
  selector: 'app-send-email',
  templateUrl: './send-email.component.html',
  styleUrls: ['./send-email.component.css']
})
export class SendEmailComponent implements OnInit {
  message: string;
  constructor(private sendEmailService:SendEmailService) { }

  ngOnInit() {
  }
  ChangeMessage(event) {
    this.message = event.target.value;
  }

  Send(){
this.sendEmailService.SendEmail(this.message).subscribe(res=>{
  alert("Succesfuly sending!!");
  this.message=null;
})
  }
}
