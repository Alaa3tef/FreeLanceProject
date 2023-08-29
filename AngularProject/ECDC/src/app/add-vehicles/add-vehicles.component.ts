import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-add-vehicles',
  templateUrl: './add-vehicles.component.html',
  styleUrls: ['./add-vehicles.component.scss']
})
export class AddVehiclesComponent {
  VehicleForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private loginService:LoginService,private addDataService:AddDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.VehicleForm = this.fb.group(
      {
        id: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        number: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        type: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        color: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        passengerNumber: this.fb.control(
          '',
          [
            Validators.required
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
    return this.VehicleForm.get('id');
  }
  get number() {
    return this.VehicleForm.get('number');
  }
  get type() {
    return this.VehicleForm.get('type');
  }
  get color() {
    return this.VehicleForm.get('color');
  }
  get passengerNumber() {
    return this.VehicleForm.get('passengerNumber');
  }
  get licenceExpireData() {
    return this.VehicleForm.get('licenceExpireData');
  }
  get licenceNumber() {
    return this.VehicleForm.get('licenceNumber');
  }

  submitData() {
    if (this.VehicleForm.valid) {
      this.addDataService.AddVehicle(this.VehicleForm.value).subscribe({
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
      console.log(this.VehicleForm);
    }
  }



}
