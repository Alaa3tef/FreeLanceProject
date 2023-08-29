import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AddnewJMPService } from 'Services/addnew-jmp.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  IsAdmin: boolean = false;
  UserName: any;
  UserId: any;
  UserRole!: string;
  IsLoging: boolean = false;
  JMPRecords:number=0;

  constructor(private JMPService:AddnewJMPService,
    private loginService: LoginService,
    private dataService:DataService,
    private router: Router) {

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.loginService.currentUser.subscribe({
      next: (data: any) => {
        this.UserId = data.ID;
        this.UserName = data.Name;
        this.UserRole = data.Role;

      }
    })
    this.loginService.isAdmin.subscribe({
      next: data => this.IsAdmin = data


    })
    this.loginService.isLogin.subscribe({

      next: (data: any) => {

        console.log("-------------------------------------+");

        console.log(data);

        this.IsLoging = data
      }

    })
    this.JMPService.PendingJMP.subscribe({
      next:data=>{
        console.log("data")
        console.log(data)

        this.JMPRecords=data

        console.log("this.JMPRecords")
        console.log(this.JMPRecords)
      }
    })

    this.dataService.GetPendingJMP(1).subscribe({
      next: data => {
        console.log("data.items.length")
        console.log(data.items.length)
        this.JMPService.PendingJMP.next(data.items.length)
        console.log(this.JMPService.PendingJMP.getValue())
      },
      error: err => {
        console.log(err)
      }
    })

  }
}
