import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IReportedByPosition } from 'SharedClasses/IReportedByPosition';

@Component({
  selector: 'app-edit-reported-by-position',
  templateUrl: './edit-reported-by-position.component.html',
  styleUrls: ['./edit-reported-by-position.component.scss']
})
export class EditReportedByPositionComponent {
  ReportedByPositionId:any;
  ReportedByPosition!:IReportedByPosition;
  ReportedByPositionForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.ReportedByPositionId = params.get("id");
      console.log(this.ReportedByPositionId)
    }),
    this.editDataService.GetReportedByPositionById(this.ReportedByPositionId).subscribe({
      next: data => {
        this.ReportedByPosition = data.data,
        console.log('*************************************************************')
        console.log(this.ReportedByPosition)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.ReportedByPositionForm = this.fb.group(
      {
        id: this.fb.control(
          this.ReportedByPositionId,
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
    return this.ReportedByPositionForm.get('id');
  }
  get name() {
    return this.ReportedByPositionForm.get('name');
  }

  submitData() {
    if (this.ReportedByPositionForm.valid) {
      this.editDataService.EditReportedByPosition(this.ReportedByPositionForm.value).subscribe({
        next: data => {
          console.log(this.ReportedByPositionForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/ReportedByPosition']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.ReportedByPositionForm);
    }
  }

}
