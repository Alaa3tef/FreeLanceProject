import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IToolPusherPositionName } from 'SharedClasses/IToolPusherPositionName';

@Component({
  selector: 'app-edit-tool-pusher-position-name',
  templateUrl: './edit-tool-pusher-position-name.component.html',
  styleUrls: ['./edit-tool-pusher-position-name.component.scss']
})
export class EditToolPusherPositionNameComponent {
  ToolPusherPositionNameId:any;
  ToolPusherPositionName!:IToolPusherPositionName;
  ToolPusherPositionNameForm!: FormGroup;
  positionList:any[]=[];
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private dataService:DataService,private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.ToolPusherPositionNameId = params.get("id");
      console.log(this.ToolPusherPositionNameId)
    }),
    this.editDataService.GetToolPusherPositionNameById(this.ToolPusherPositionNameId).subscribe({
      next: data => {
        this.ToolPusherPositionName = data.data,
        console.log('*************************************************************')
        console.log(this.ToolPusherPositionName)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.ToolPusherPositionNameForm = this.fb.group(
      {
        id: this.fb.control(
          this.ToolPusherPositionNameId,
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
    this.dataService.GetToolPusherPosition().subscribe({
      next:data=>this.positionList=data.data
    })
  }

  get id() {
    return this.ToolPusherPositionNameForm.get('id');
  }
  get name() {
    return this.ToolPusherPositionNameForm.get('name');
  }
  get empCode() {
    return this.ToolPusherPositionNameForm.get('empCode');
  }
  get positionId() {
    return this.ToolPusherPositionNameForm.get('positionId');
  }

  submitData() {
    if (this.ToolPusherPositionNameForm.valid) {
      this.editDataService.EditToolPusherPositionName(this.ToolPusherPositionNameForm.value).subscribe({
        next: data => {
          console.log(this.ToolPusherPositionNameForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/ToolPusherPositionName']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.ToolPusherPositionNameForm);
    }
  }
}
