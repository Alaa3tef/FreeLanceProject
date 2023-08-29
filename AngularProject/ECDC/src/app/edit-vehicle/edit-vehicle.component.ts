import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IVehicle } from 'SharedClasses/IVehicle';

@Component({
  selector: 'app-edit-vehicle',
  templateUrl: './edit-vehicle.component.html',
  styleUrls: ['./edit-vehicle.component.scss']
})
export class EditVehicleComponent {
  VehicleId:any;
  Vehicle!:IVehicle;
  VehicleForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.VehicleId = params.get("id");
      console.log(this.VehicleId)
    }),
    this.editDataService.GetVehicleById(this.VehicleId).subscribe({
      next: data => {
        this.Vehicle = data.data,
        console.log('*************************************************************')
        console.log(this.Vehicle)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.VehicleForm = this.fb.group(
      {
        id: this.fb.control(
          this.VehicleId,
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
          0,
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
    )
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
      this.editDataService.EditVehicle(this.VehicleForm.value).subscribe({
        next: data => {
          console.log(this.VehicleForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/Vehicle']);
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
