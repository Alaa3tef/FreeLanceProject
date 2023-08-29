import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AddBOPService } from 'Services/add-bop.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-edit-bop',
  templateUrl: './edit-bop.component.html',
  styleUrls: ['./edit-bop.component.scss']
})
export class EditBOPComponent {
  BOPForm!: FormGroup;
  ErrorMessage = '';
  UserJsonString:any
  UserJsonObj:any
  rigList: IRig[] = [];
  BOPId:any;
  Bop:any;
  user:any;

  // totalMan:any =this.manPower


  constructor(private activatedRoute:ActivatedRoute,private dataService: DataService,private loginService:LoginService,private addBOP:AddBOPService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {

    this.user=this.loginService.currentUser.getValue()
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.BOPId = params.get("id");
      console.log(this.BOPId)
    }),
    this.addBOP.GeBOPById(this.BOPId,this.user.ID,this.user.Role).subscribe({
      next: data => {
        this.Bop = data.data,
        console.log('*************************************************************')
        console.log(this.Bop)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.dataService.GetRig().subscribe({
      next: data => this.rigList = data.data,
      error: err => this.ErrorMessage = err
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.BOPForm = this.fb.group(
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
       
        date: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        ecdc: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        client: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        service: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        visitors: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        catering: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        watchMen: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        inspection: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        rental: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        other: this.fb.control(
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
        ),
        userId: this.fb.control(this.UserJsonObj.ID, [Validators.required]),
      }
    )
  }

  get id() {
    return this.BOPForm.get('id');
  }
  get rigId() {
    return this.BOPForm.get('rigId');
  }

  get date() {
    return this.BOPForm.get('date');
  }
  get ecdc() {
    return this.BOPForm.get('ecdc');
  }
  get client() {
    return this.BOPForm.get('client');
  }
  get service() {
    return this.BOPForm.get('service');
  }
  get visitors() {
    return this.BOPForm.get('visitors');
  }
  get catering() {
    return this.BOPForm.get('catering');
  }
  get watchMen() {
    return this.BOPForm.get('watchMen');
  }
  get inspection() {
    return this.BOPForm.get('inspection');
  }
  get rental() {
    return this.BOPForm.get('rental');
  }
  get other() {
    return this.BOPForm.get('other');
  }

  get userId() {
    return this.BOPForm.get('userId');
  }
 

  submitData() {
    console.log("============================================================")

    console.log(this.BOPForm.value)
    if (this.BOPForm.valid) {
      this.addBOP.EditBOP(this.BOPId,this.BOPForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          location.reload();
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.BOPForm);
    }
  }
}
