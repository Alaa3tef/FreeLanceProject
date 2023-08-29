import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IViolationCategory } from 'SharedClasses/IViolationCategory';

@Component({
  selector: 'app-edit-violation-category',
  templateUrl: './edit-violation-category.component.html',
  styleUrls: ['./edit-violation-category.component.scss']
})
export class EditViolationCategoryComponent {
  ViolationCategoryId:any;
  ViolationCategory!:IViolationCategory;
  ViolationCategoryForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.ViolationCategoryId = params.get("id");
      console.log(this.ViolationCategoryId)
    }),
    this.editDataService.GetViolationCategoryById(this.ViolationCategoryId).subscribe({
      next: data => {
        this.ViolationCategory = data.data,
        console.log('*************************************************************')
        console.log(this.ViolationCategory)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.ViolationCategoryForm = this.fb.group(
      {
        id: this.fb.control(
          this.ViolationCategoryId,
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
    return this.ViolationCategoryForm.get('id');
  }
  get name() {
    return this.ViolationCategoryForm.get('name');
  }

  submitData() {
    if (this.ViolationCategoryForm.valid) {
      this.editDataService.EditViolationCategory(this.ViolationCategoryForm.value).subscribe({
        next: data => {
          console.log(this.ViolationCategoryForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/ViolationCategory']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.ViolationCategoryForm);
    }
  }


}
