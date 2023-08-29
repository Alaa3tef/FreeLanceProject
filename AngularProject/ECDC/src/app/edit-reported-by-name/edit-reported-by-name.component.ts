import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IReportedByName } from 'SharedClasses/IReportedByName';

@Component({
  selector: 'app-edit-reported-by-name',
  templateUrl: './edit-reported-by-name.component.html',
  styleUrls: ['./edit-reported-by-name.component.scss']
})
export class EditReportedByNameComponent {
  ReportedByNameId:any;
  ReportedByName!:IReportedByName;
  ReportedByNameForm!: FormGroup;
  positionList:any[]=[];
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private dataService:DataService,private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.ReportedByNameId = params.get("id");
      console.log(this.ReportedByNameId)
    }),
    this.editDataService.GetReportedByNameById(this.ReportedByNameId).subscribe({
      next: data => {
        this.ReportedByName = data.data,
        console.log('*************************************************************')
        console.log(this.ReportedByName)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.ReportedByNameForm = this.fb.group(
      {
        id: this.fb.control(
          this.ReportedByNameId,
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
        empCode: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        positionId: this.fb.control(
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
    this.dataService.GetReportedByPosition().subscribe({
      next:data=>this.positionList=data.data
    })
  }

  get id() {
    return this.ReportedByNameForm.get('id');
  }
  get name() {
    return this.ReportedByNameForm.get('name');
  }
  get empCode() {
    return this.ReportedByNameForm.get('empCode');
  }
  get positionId() {
    return this.ReportedByNameForm.get('positionId');
  }

  submitData() {
    if (this.ReportedByNameForm.valid) {
      this.editDataService.EditReportedByName(this.ReportedByNameForm.value).subscribe({
        next: data => {
          console.log(this.ReportedByNameForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/ReportedByName']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.ReportedByNameForm);
    }
  }
}
