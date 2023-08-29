import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-edit-rig',
  templateUrl: './edit-rig.component.html',
  styleUrls: ['./edit-rig.component.scss']
})
export class EditRigComponent {
  RigId:any;
  Rig!:IRig;
  RigForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.RigId = params.get("id");
      console.log(this.RigId)
    }),
    this.editDataService.GetRigById(this.RigId).subscribe({
      next: data => {
        this.Rig = data.data,
        console.log('*************************************************************')
        console.log(this.Rig)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.RigForm = this.fb.group(
      {
        id: this.fb.control(
          this.RigId,
          [
            Validators.required
          ]
        ),
        number: this.fb.control(
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
    return this.RigForm.get('id');
  }
  get number() {
    return this.RigForm.get('number');
  }

  submitData() {
    if (this.RigForm.valid) {
      this.editDataService.EditRig(this.RigForm.value).subscribe({
        next: data => {
          console.log(this.RigForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/Rig']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.RigForm);
    }
  }

}
