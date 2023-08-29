import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-add-driver',
  templateUrl: './add-driver.component.html',
  styleUrls: ['./add-driver.component.scss']
})
export class AddDriverComponent {
  DriverForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private loginService:LoginService,private addDataService:AddDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.DriverForm = this.fb.group(
      {
        id: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        name: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        phoneNumber: this.fb.control(
          '',
          [
            Validators.required,
            Validators.pattern('^[0-9]{11}$')
          ]
        ),
        licenceExpireData: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        licenceNumber: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        isDeleted: this.fb.control(
          false,
          [
            Validators.required
          ]
        )
      }
    ),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
  }

  get id() {
    return this.DriverForm.get('id');
  }
  get name() {
    return this.DriverForm.get('name');
  }
  get phoneNumber() {
    return this.DriverForm.get('phoneNumber');
  }
  get licenceExpireData() {
    return this.DriverForm.get('licenceExpireData');
  }
  get licenceNumber() {
    return this.DriverForm.get('licenceNumber');
  }

  submitData() {
    if (this.DriverForm.valid) {
      this.addDataService.AddDriver(this.DriverForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          location.reload();
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.DriverForm);
    }
  }
}
