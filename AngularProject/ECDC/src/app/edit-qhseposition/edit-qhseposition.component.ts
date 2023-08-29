import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IQHSEPosition } from 'SharedClasses/IQHSEPosition';

@Component({
  selector: 'app-edit-qhseposition',
  templateUrl: './edit-qhseposition.component.html',
  styleUrls: ['./edit-qhseposition.component.scss']
})
export class EditQHSEPositionComponent {
  QHSEPositionId:any;
  QHSEPosition!:IQHSEPosition;
  QHSEPositionForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.QHSEPositionId = params.get("id");
      console.log(this.QHSEPositionId)
    }),
    this.editDataService.GetQHSEPositionById(this.QHSEPositionId).subscribe({
      next: data => {
        this.QHSEPosition = data.data,
        console.log('*************************************************************')
        console.log(this.QHSEPosition)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.QHSEPositionForm = this.fb.group(
      {
        id: this.fb.control(
          this.QHSEPositionId,
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
    return this.QHSEPositionForm.get('id');
  }
  get name() {
    return this.QHSEPositionForm.get('name');
  }

  submitData() {
    if (this.QHSEPositionForm.valid) {
      this.editDataService.EditQHSEPosition(this.QHSEPositionForm.value).subscribe({
        next: data => {
          console.log(this.QHSEPositionForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/QHSEPosition']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.QHSEPositionForm);
    }
  }
}
