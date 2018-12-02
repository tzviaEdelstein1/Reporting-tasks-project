import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-managers',
  templateUrl: './managers.component.html',
  styleUrls: ['./managers.component.css']
})
export class ManagersComponent implements OnInit {

  constructor(private router: Router) { }
  items: any[] = [ {
    text: 'Item2',
    items: [{ text: 'Add user',  path: "managers/addUser" }, { text: 'edit User',path:"managers/editUser"  }, { text: 'delete user',path:"managers/deleteUser" }]
  }];
  
  ngOnInit() {
  }
  LogOut(){
    localStorage.removeItem("currentUser");
    this.router.navigateByUrl('/');
  }
  public onSelect({ item }): void {
    debugger;
    if (!item.items) {
        this.router.navigate([ item.path ]);
    }
}
