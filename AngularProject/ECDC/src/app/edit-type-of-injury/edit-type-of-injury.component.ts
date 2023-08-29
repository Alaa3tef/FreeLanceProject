import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { ITypeOfInjury } from 'SharedClasses/ITypeOfInjury';

@Component({
  selector: 'app-edit-type-of-injury',
  templateUrl: './edit-type-of-injury.component.html',
  styleUrls: ['./edit-type-of-injury.component.scss']
})
export class EditTypeOfInjuryComponent {
  TypeOfInjuryId:any;
  TypeOfInjury!:ITypeOfInjury;
  TypeOfInjuryForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.TypeOfInjuryId = params.get("id");
      console.log(this.TypeOfInjuryId)
    }),
    this.editDataService.GetTypeOfInjuryById(this.TypeOfInjuryId).subscribe({
      next: data => {
        this.TypeOfInjury = data.data,
        console.log('*************************************************************')
        console.log(this.TypeOfInjury)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.TypeOfInjuryForm = this.fb.group(
      {
        id: this.fb.control(
          this.TypeOfInjuryId,
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
    return this.TypeOfInjuryForm.get('id');
  }
  get name() {
    return this.TypeOfInjuryForm.get('name');
  }

  submitData() {
    if (this.TypeOfInjuryForm.valid) {
      this.editDataService.EditTypeOfInjury(this.TypeOfInjuryForm.value).subscribe({
        next: data => {
          console.log(this.TypeOfInjuryForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/TypeOfInjury']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.TypeOfInjuryForm);
    }
  }

}
