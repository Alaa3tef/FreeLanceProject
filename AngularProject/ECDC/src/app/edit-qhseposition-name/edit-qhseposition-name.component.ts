import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IQHSEPositionName } from 'SharedClasses/IQHSEPositionName';

@Component({
  selector: 'app-edit-qhseposition-name',
  templateUrl: './edit-qhseposition-name.component.html',
  styleUrls: ['./edit-qhseposition-name.component.scss']
})
export class EditQHSEPositionNameComponent {
  QHSEPositionNameId:any;
  QHSEPositionName!:IQHSEPositionName;
  QHSEPositionNameForm!: FormGroup;
  positionList:any[]=[];
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private dataService:DataService,private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.QHSEPositionNameId = params.get("id");
      console.log(this.QHSEPositionNameId)
    }),
    this.editDataService.GetQHSEPositionNameById(this.QHSEPositionNameId).subscribe({
      next: data => {
        this.QHSEPositionName = data.data,
        console.log('*************************************************************')
        console.log(this.QHSEPositionName)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.QHSEPositionNameForm = this.fb.group(
      {
        id: this.fb.control(
          this.QHSEPositionNameId,
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
    this.dataService.GetQHSEPosition().subscribe({
      next:data=>this.positionList=data.data
    })
  }

  get id() {
    return this.QHSEPositionNameForm.get('id');
  }
  get name() {
    return this.QHSEPositionNameForm.get('name');
  }
  get empCode() {
    return this.QHSEPositionNameForm.get('empCode');
  }
  get positionId() {
    return this.QHSEPositionNameForm.get('positionId');
  }

  submitData() {
    if (this.QHSEPositionNameForm.valid) {
      this.editDataService.EditQHSEPositionName(this.QHSEPositionNameForm.value).subscribe({
        next: data => {
          console.log(this.QHSEPositionNameForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/QHSEPositionName']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.QHSEPositionNameForm);
    }
  }
}
