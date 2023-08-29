import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IClassification } from 'SharedClasses/IClassification';

@Component({
  selector: 'app-edit-classification',
  templateUrl: './edit-classification.component.html',
  styleUrls: ['./edit-classification.component.scss']
})
export class EditClassificationComponent {
  classificationId:any;
  classification!:IClassification;
  classificationForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.classificationId = params.get("id");
      console.log(this.classificationId)
    }),
    this.editDataService.GetClassificationById(this.classificationId).subscribe({
      next: data => {
        this.classification = data.data,
        console.log('*************************************************************')
        console.log(this.classification)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.classificationForm = this.fb.group(
      {
        id: this.fb.control(
          this.classificationId,
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
    return this.classificationForm.get('id');
  }
  get name() {
    return this.classificationForm.get('name');
  }

  submitData() {
    if (this.classificationForm.valid) {
      this.editDataService.EditClassification(this.classificationForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/Classification']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.classificationForm);
    }
  }

}
