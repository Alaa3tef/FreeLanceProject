import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IToolPusherPosition } from 'SharedClasses/IToolPusherPosition';

@Component({
  selector: 'app-edit-tool-pusher-position',
  templateUrl: './edit-tool-pusher-position.component.html',
  styleUrls: ['./edit-tool-pusher-position.component.scss']
})
export class EditToolPusherPositionComponent {
  ToolPusherPositionId:any;
  ToolPusherPosition!:IToolPusherPosition;
  ToolPusherPositionForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.ToolPusherPositionId = params.get("id");
      console.log(this.ToolPusherPositionId)
    }),
    this.editDataService.GetToolPusherPositionById(this.ToolPusherPositionId).subscribe({
      next: data => {
        this.ToolPusherPosition = data.data,
        console.log('*************************************************************')
        console.log(this.ToolPusherPosition)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.ToolPusherPositionForm = this.fb.group(
      {
        id: this.fb.control(
          this.ToolPusherPositionId,
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
    return this.ToolPusherPositionForm.get('id');
  }
  get name() {
    return this.ToolPusherPositionForm.get('name');
  }

  submitData() {
    if (this.ToolPusherPositionForm.valid) {
      this.editDataService.EditToolPusherPosition(this.ToolPusherPositionForm.value).subscribe({
        next: data => {
          console.log(this.ToolPusherPositionForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/ToolPusherPosition']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.ToolPusherPositionForm);
    }
  }

}
