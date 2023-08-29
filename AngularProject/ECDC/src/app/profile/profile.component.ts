import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  IsLoging: boolean = false;
  UserName: any;
  UserId: any;
  UserRole!: string;
  constructor(private loginService: LoginService, private router: Router) {

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.loginService.currentUser.subscribe({
      next: (data: any) => {
  
        console.log(data);
        if (data.Role.length > 2) {
          this.IsLoging = true;
        }
        this.UserId = data.ID;
        this.UserName = data.Name;
        this.UserRole = data.Role;

      }
    })
  }
}




