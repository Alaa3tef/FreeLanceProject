import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IRouteName } from 'SharedClasses/IRouteName';

@Component({
  selector: 'app-edit-route-name',
  templateUrl: './edit-route-name.component.html',
  styleUrls: ['./edit-route-name.component.scss']
})
export class EditRouteNameComponent {
  RouteNameId:any;
  RouteName!:IRouteName;
  RouteNameForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.RouteNameId = params.get("id");
      console.log(this.RouteNameId)
    }),
    this.editDataService.GetRouteNameById(this.RouteNameId).subscribe({
      next: data => {
        this.RouteName = data.data,
        console.log('*************************************************************')
        console.log(this.RouteName)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.RouteNameForm = this.fb.group(
      {
        id: this.fb.control(
          this.RouteNameId,
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
    return this.RouteNameForm.get('id');
  }
  get name() {
    return this.RouteNameForm.get('name');
  }

  submitData() {
    if (this.RouteNameForm.valid) {
      this.editDataService.EditRouteName(this.RouteNameForm.value).subscribe({
        next: data => {
          console.log(this.RouteNameForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/RouteName']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.RouteNameForm);
    }
  }

}
