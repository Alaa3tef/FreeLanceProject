import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IPreventionCategory } from 'SharedClasses/IPreventionCategory';

@Component({
  selector: 'app-edit-prevention-category',
  templateUrl: './edit-prevention-category.component.html',
  styleUrls: ['./edit-prevention-category.component.scss']
})
export class EditPreventionCategoryComponent {
  PreventionCategoryId:any;
  PreventionCategory!:IPreventionCategory;
  PreventionCategoryForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.PreventionCategoryId = params.get("id");
      console.log(this.PreventionCategoryId)
    }),
    this.editDataService.GetPreventionCategoryById(this.PreventionCategoryId).subscribe({
      next: data => {
        this.PreventionCategory = data.data,
        console.log('*************************************************************')
        console.log(this.PreventionCategory)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.PreventionCategoryForm = this.fb.group(
      {
        id: this.fb.control(
          this.PreventionCategoryId,
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
    return this.PreventionCategoryForm.get('id');
  }
  get name() {
    return this.PreventionCategoryForm.get('name');
  }

  submitData() {
    if (this.PreventionCategoryForm.valid) {
      this.editDataService.EditPreventionCategory(this.PreventionCategoryForm.value).subscribe({
        next: data => {
          console.log(this.PreventionCategoryForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/PreventionCategory']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.PreventionCategoryForm);
    }
  }
}
