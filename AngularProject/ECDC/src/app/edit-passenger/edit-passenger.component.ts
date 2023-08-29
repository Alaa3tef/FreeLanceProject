import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IPassenger } from 'SharedClasses/IPassenger';

@Component({
  selector: 'app-edit-passenger',
  templateUrl: './edit-passenger.component.html',
  styleUrls: ['./edit-passenger.component.scss']
})
export class EditPassengerComponent {
  PassengerId:any;
  Passenger!:IPassenger;
  PassengerForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.PassengerId = params.get("id");
      console.log(this.PassengerId)
    }),
    this.editDataService.GetPassengerById(this.PassengerId).subscribe({
      next: data => {
        this.Passenger = data.data,
        console.log('*************************************************************')
        console.log(this.Passenger)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.PassengerForm = this.fb.group(
      {
        id: this.fb.control(
          this.PassengerId,
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
        telephone: this.fb.control(
          '',
          [
            Validators.pattern('^[0-9]{11}$')
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
    return this.PassengerForm.get('id');
  }
  get name() {
    return this.PassengerForm.get('name');
  }
  get telephone() {
    return this.PassengerForm.get('telephone');
  }

  submitData() {
    if (this.PassengerForm.valid) {
      this.editDataService.EditPassenger(this.PassengerForm.value).subscribe({
        next: data => {
          console.log(this.PassengerForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/Passenger']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.PassengerForm);
    }
  }
}
