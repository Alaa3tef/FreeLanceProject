import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from 'Services/register.service';
// import { ConfirmPasswordValidator } from 'Validatian/confirmPassword.validators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerForm!: FormGroup;
  roleslist!: any[];
  constructor(
    private registerService: RegisterService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.registerService.GetRoles().subscribe({
      next: (data) => {
        this.roleslist = data.data;
      },
      error: (data) => { console.log(data); }

    })
    this.registerForm = this.fb.group(
      {
        userName: this.fb.control(
          '',
          [
            Validators.required
          ],
        ),
        password: this.fb.control(
          '',
          [
            Validators.required,
            Validators.pattern(
              '^(?=.*[a-z])[a-zA-Z0-9]{6}$'
            ),
          ],
        ),

        Role: this.fb.control(
          '',
          [
            Validators.required
          ],
        )

      }, {
      // validator: [ConfirmPasswordValidator]
    }
    );

  }

  get userName() {
    return this.registerForm.get('userName');
  }
  get password() {
    return this.registerForm.get('password');
  }
  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }
  get Role() {
    return this.registerForm.get('Role');
  }






  submitData() {

    console.log(this.registerForm);
    this.registerService.Register(this.registerForm.value).subscribe({
      next: data => {
        console.log(data);
        location.reload();
      },
      error: error => console.log(error)
    });
  }
}

