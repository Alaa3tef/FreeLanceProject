import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.scss']
})
export class ChangepasswordComponent {
  ChangePasswordForm!: FormGroup;
  User:any;


  constructor(
              private fb: FormBuilder,
              private loginService: LoginService,
               private router: Router)
             { }

  ngOnInit() {
    this.User= this.loginService.currentUser.getValue();
    this.ChangePasswordForm = this.fb.group({
      id: this.fb.control( this.User.ID, [Validators.required]),
      currentPassword: this.fb.control('', [Validators.required]),
      newPassword: this.fb.control('', [Validators.required]),
    });
  }
  get id() { return this.ChangePasswordForm.get('id');}
  get currentPassword() { return this.ChangePasswordForm.get('currentPassword');}
  get newPassword() { return this.ChangePasswordForm.get('newPassword');}

  submitData()
  {
    this.loginService.ChangePassword(this.ChangePasswordForm.value).subscribe({
      next: data =>
      {

        console.log("frooommm dataaaaa")
        console.log(data)
        this.loginService.SignOut();
      },
      error: error =>console.log(error) //this.router.navigate(['/Login'])
    });
  }

  
}
