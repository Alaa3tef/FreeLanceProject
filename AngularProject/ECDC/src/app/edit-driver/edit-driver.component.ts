import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IDriver } from 'SharedClasses/IDriver';

@Component({
  selector: 'app-edit-driver',
  templateUrl: './edit-driver.component.html',
  styleUrls: ['./edit-driver.component.scss']
})
export class EditDriverComponent {
  DriverId:any;
  Driver!:IDriver;
  DriverForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.DriverId = params.get("id");
      console.log(this.DriverId)
    }),
    this.editDataService.GetDriverById(this.DriverId).subscribe({
      next: data => {
        this.Driver = data.data,
        console.log('*************************************************************')
        console.log(this.Driver)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.DriverForm = this.fb.group(
      {
        id: this.fb.control(
          this.DriverId,
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
    )
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
      this.editDataService.EditDriverForm(this.DriverForm.value).subscribe({
        next: data => {
          console.log(this.DriverForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/Driver']);
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
