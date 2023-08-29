import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IComminucationMethod } from 'SharedClasses/IComminucationMethod';

@Component({
  selector: 'app-edit-comminucation-method',
  templateUrl: './edit-comminucation-method.component.html',
  styleUrls: ['./edit-comminucation-method.component.scss']
})
export class EditComminucationMethodComponent {
  ComminucationMethodId:any;
  ComminucationMethod!:IComminucationMethod;
  ComminucationMethodForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.ComminucationMethodId = params.get("id");
      console.log(this.ComminucationMethodId)
    }),
    this.editDataService.GetComminucationMethodById(this.ComminucationMethodId).subscribe({
      next: data => {
        this.ComminucationMethod = data.data,
        console.log('*************************************************************')
        console.log(this.ComminucationMethod)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.ComminucationMethodForm = this.fb.group(
      {
        id: this.fb.control(
          this.ComminucationMethodId,
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
    return this.ComminucationMethodForm.get('id');
  }
  get name() {
    return this.ComminucationMethodForm.get('name');
  }

  submitData() {
    if (this.ComminucationMethodForm.valid) {
      this.editDataService.EditComminucationMethod(this.ComminucationMethodForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/ComminucationMethod']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.ComminucationMethodForm);
    }
  }
}
