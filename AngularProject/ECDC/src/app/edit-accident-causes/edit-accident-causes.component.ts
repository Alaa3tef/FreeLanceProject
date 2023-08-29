import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IAccidentCauses } from 'SharedClasses/IAccidentCauses';

@Component({
  selector: 'app-edit-accident-causes',
  templateUrl: './edit-accident-causes.component.html',
  styleUrls: ['./edit-accident-causes.component.scss']
})
export class EditAccidentCausesComponent {
  accidentCausesId:any;
  accidentCauses!:IAccidentCauses;
  accidentCausesForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.accidentCausesId = params.get("id");
      console.log(this.accidentCausesId)
    }),
    this.editDataService.GetAccidentCausesById(this.accidentCausesId).subscribe({
      next: data => {
        this.accidentCauses = data.data,
        console.log('*************************************************************')
        console.log(this.accidentCauses)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.accidentCausesForm = this.fb.group(
      {
        id: this.fb.control(
          this.accidentCausesId,
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
    return this.accidentCausesForm.get('id');
  }
  get name() {
    return this.accidentCausesForm.get('name');
  }

  submitData() {
    if (this.accidentCausesForm.valid) {
      this.editDataService.EditAccidentCauses(this.accidentCausesForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/AccidentCauses']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.accidentCausesForm);
    }
  }

}
