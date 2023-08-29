import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { LoginService } from 'Services/login.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  ErrorMessage: boolean = false;



  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      userName: this.fb.control('', [Validators.required]),
      password: this.fb.control('', [Validators.required,Validators.pattern(
        '^(?=.*[a-z])[a-zA-Z0-9]{6}$'
      ),]),
    });
  }

  get userName() { return this.loginForm.get('userName'); }
  get password() { return this.loginForm.get('password'); }

  submitData() {
    this.loginService.Login(this.loginForm.value).subscribe({
      next: data => {
        if (data.message == 'Success') {
          localStorage.setItem('UserToken', data.token);
          this.loginService.saveCurrentUser();
          const user: any = jwtDecode(data.token);
          console.log(user);
          if (user.Role == "User") {
            this.router.navigate(['/Home']);
          }
          else if (user.Role == "Admin") {
            this.router.navigate(['/Dashboard'])
            console.log("Admin")
          }
          else if (user.Role == "Radio") {
            this.router.navigate(['/Home'])
            console.log("Radio")
          }
        }
      },
      error: err => {
        // this.router.navigate(['/Login'])
        console.log(err),
          this.ErrorMessage = true;
      }
    });
  }
}



