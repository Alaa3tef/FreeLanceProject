import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { ITypeOfObservationCategory } from 'SharedClasses/ITypeOfObservationCategory';

@Component({
  selector: 'app-edit-type-of-observation-category',
  templateUrl: './edit-type-of-observation-category.component.html',
  styleUrls: ['./edit-type-of-observation-category.component.scss']
})
export class EditTypeOfObservationCategoryComponent {
  TypeOfObservationCategoryId:any;
  TypeOfObservationCategory!:ITypeOfObservationCategory;
  TypeOfObservationCategoryForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.TypeOfObservationCategoryId = params.get("id");
      console.log(this.TypeOfObservationCategoryId)
    }),
    this.editDataService.GetTypeOfObservationCategoryById(this.TypeOfObservationCategoryId).subscribe({
      next: data => {
        this.TypeOfObservationCategory = data.data,
        console.log('*************************************************************')
        console.log(this.TypeOfObservationCategory)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.TypeOfObservationCategoryForm = this.fb.group(
      {
        id: this.fb.control(
          this.TypeOfObservationCategoryId,
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
    return this.TypeOfObservationCategoryForm.get('id');
  }
  get name() {
    return this.TypeOfObservationCategoryForm.get('name');
  }

  submitData() {
    if (this.TypeOfObservationCategoryForm.valid) {
      this.editDataService.EditTypeOfObservationCategory(this.TypeOfObservationCategoryForm.value).subscribe({
        next: data => {
          console.log(this.TypeOfObservationCategoryForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/TypeOfObserviationCategory']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.TypeOfObservationCategoryForm);
    }
  }

}
