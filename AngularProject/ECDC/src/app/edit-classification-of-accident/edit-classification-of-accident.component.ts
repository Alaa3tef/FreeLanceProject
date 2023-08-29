import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IClassificationOfAccident } from 'SharedClasses/IClassificationOfAccident';

@Component({
  selector: 'app-edit-classification-of-accident',
  templateUrl: './edit-classification-of-accident.component.html',
  styleUrls: ['./edit-classification-of-accident.component.scss']
})
export class EditClassificationOfAccidentComponent {
  classificationOfAccidentId:any;
  classificationOfAccident!:IClassificationOfAccident;
  classificationOfAccidentForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.classificationOfAccidentId = params.get("id");
      console.log(this.classificationOfAccidentId)
    }),
    this.editDataService.GetClassificationOfAccidentById(this.classificationOfAccidentId).subscribe({
      next: data => {
        this.classificationOfAccident = data.data,
        console.log('*************************************************************')
        console.log(this.classificationOfAccident)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.classificationOfAccidentForm = this.fb.group(
      {
        id: this.fb.control(
          this.classificationOfAccidentId,
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
    return this.classificationOfAccidentForm.get('id');
  }
  get name() {
    return this.classificationOfAccidentForm.get('name');
  }

  submitData() {
    if (this.classificationOfAccidentForm.valid) {
      this.editDataService.EditClassificationOfAccident(this.classificationOfAccidentForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/ClassificationOfAccident']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.classificationOfAccidentForm);
    }
  }
}
