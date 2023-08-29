import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { PTSMService } from 'Services/ptsm.service';
import { IPTSM } from 'SharedClasses/IPTSM';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-edit-ptsm',
  templateUrl: './edit-ptsm.component.html',
  styleUrls: ['./edit-ptsm.component.scss']
})
export class EditPTSMComponent {
  PTSMId:any;
  PTSM!:IPTSM;
  PTSMForm!: FormGroup;
  ErrorMessage = '';
  UserJsonString:any
  UserJsonObj:any
  rigList: IRig[] = []

  User:any;

  constructor(private activatedRoute:ActivatedRoute,private dataService: DataService,private loginService:LoginService,private addPTSMService:PTSMService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.PTSMId = params.get("id");
      console.log(this.PTSMId)
    }),
    this.addPTSMService.GePTSMById(this.PTSMId,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.PTSM = data.data,
        console.log('*************************************************************')
        console.log(this.PTSM)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.dataService.GetRig().subscribe({
      next: data => this.rigList = data.data,
      error: err => this.ErrorMessage = err
    }),

    this.PTSMForm = this.fb.group(
      {
        id: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        rigId: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        time: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        date: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        trainerName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        numsofTrainees: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        subjectTitle: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        subjectContent: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        no1: this.fb.control(
          1,
          [
          ]
        ),
        position1: this.fb.control(
          '',
          [
          ]
        ),
        name1: this.fb.control(
          '',
          [
          ]
        ),
        no2: this.fb.control(
          2,
          [
          ]
        ),
        position2: this.fb.control(
          '',
          [
          ]
        ),
        name2: this.fb.control(
          '',
          [
          ]
        ),
        no3: this.fb.control(
          3,
          [
          ]
        ),
        position3: this.fb.control(
          '',
          [
          ]
        ),
        name3: this.fb.control(
          '',
          [
          ]
        ),
        no4: this.fb.control(
          4,
          [
          ]
        ),
        position4: this.fb.control(
          '',
          [
          ]
        ),
        name4: this.fb.control(
          '',
          [
          ]
        ),
        no5: this.fb.control(
          5,
          [
          ]
        ),
        position5: this.fb.control(
          '',
          [
          ]
        ),
        name5: this.fb.control(
          '',
          [
          ]
        ),
        isDeleted: this.fb.control(
          false,
          [
            Validators.required
          ]
        ),
        userId: this.fb.control(this.UserJsonObj.ID, [Validators.required]),

      }
    )
  }

  get id() {
    return this.PTSMForm.get('id');
  }
  get rigId() {
    return this.PTSMForm.get('rigId');
  }
  get time() {
    return this.PTSMForm.get('time');
  }
  get date() {
    return this.PTSMForm.get('date');
  }
  get trainerName() {
    return this.PTSMForm.get('trainerName');
  }
  get numsofTrainees() {
    return this.PTSMForm.get('numsofTrainees');
  }
  get subjectTitle() {
    return this.PTSMForm.get('subjectTitle');
  }
  get subjectContent() {
    return this.PTSMForm.get('subjectContent');
  }
  get userId() {
    return this.PTSMForm.get('userId');
  }
  get no1() {
    return this.PTSMForm.get('no1');
  }
  get position1() {
    return this.PTSMForm.get('position1');
  }
  get name1() {
    return this.PTSMForm.get('name1');
  }
  get no2() {
    return this.PTSMForm.get('no2');
  }
  get position2() {
    return this.PTSMForm.get('position2');
  }
  get name2() {
    return this.PTSMForm.get('name2');
  }
  get no3() {
    return this.PTSMForm.get('no3');
  }
  get position3() {
    return this.PTSMForm.get('position3');
  }
  get name3() {
    return this.PTSMForm.get('name3');
  }
  get no4() {
    return this.PTSMForm.get('no4');
  }
  get position4() {
    return this.PTSMForm.get('position4');
  }
  get name4() {
    return this.PTSMForm.get('name4');
  }
  get no5() {
    return this.PTSMForm.get('no5');
  }
  get position5() {
    return this.PTSMForm.get('position5');
  }
  get name5() {
    return this.PTSMForm.get('name5');
  }

  submitData() {
    if (this.PTSMForm.valid) {
      this.addPTSMService.EditPTSM(this.PTSMId,this.PTSMForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['/Dashboard/PTSM'])
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.PTSMForm);
    }
  }
}
