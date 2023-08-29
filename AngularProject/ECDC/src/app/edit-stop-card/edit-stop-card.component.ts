import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ParamMap, ActivatedRoute } from '@angular/router';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { stopcardservice } from 'Services/stop-card.service';
import { IClassification } from 'SharedClasses/IClassification';
import { IReportedByName } from 'SharedClasses/IReportedByName';
import { IReportedByPosition } from 'SharedClasses/IReportedByPosition';
import { IStopCardRegister } from 'SharedClasses/IStopCardRegister';
import { ITypeOfObservationCategory } from 'SharedClasses/ITypeOfObservationCategory';

@Component({
  selector: 'app-edit-stop-card',
  templateUrl: './edit-stop-card.component.html',
  styleUrls: ['./edit-stop-card.component.scss']
})
export class EditStopCardComponent {
  stopCardId:any;
  stopCard!:IStopCardRegister;
  StopCardForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  time = new Date();
  classificationList: IClassification[] = []
  reportedByPositionList: IReportedByPosition[] = []
  reportedByNameList: IReportedByName[] = []
  typeOfObservationCategoryList: ITypeOfObservationCategory[] = []

  ReportedByCodeList: any;
  ReportedBy_NameID: number = 0;
  ReportedBy_Name: string = '';
  ReportedByPositionID: number = 0;
  ReportedBy_Position: string = '';

  User:any;

  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private dataService: DataService, private StopCardService: stopcardservice, private fb: FormBuilder, private router: Router) {

  }

  ngOnInit(): void {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.stopCardId = params.get("id");
      console.log(this.stopCardId)
    }),
    this.StopCardService.GetStopCardById(this.stopCardId,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.stopCard = data.data,
        console.log('*************************************************************')
        console.log(this.stopCard)
        console.log('###################################################')
        this.dataService.GetReportedByNameByEmpCode(this.stopCard.empCode).subscribe({
          next:data=>{
            this.ReportedBy_NameID=data.data.id
            this.ReportedBy_Name=data.data.name,
            this.ReportedByPositionID=data.data.positionId
            console.log("this.ReportedBy_Name")
            console.log(this.ReportedBy_Name)
            console.log("this.ReportedBy_PositionID")
            console.log(this.ReportedByPositionID)
            this.dataService.GetReportedByPositionByID(this.ReportedByPositionID).subscribe({
              next:data=>{
                this.ReportedBy_Position=data.data.name,
                console.log("this.ReportedBy_Position")
                console.log(this.ReportedBy_Position)
              },
              error:err=>{
                this.ErrorMessage=err,
                console.log(err)
              }
            })
          },
          error:err=>{
            this.ErrorMessage=err,
            console.log(err)
          }
        })
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.dataService.GetReportedByName().subscribe({
      next: data => {
        this.ReportedByCodeList = data.data,
          console.log("this.ReportedByCodeList")
        console.log(this.ReportedByCodeList)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log(err)
      }
    })
    this.StopCardForm = this.fb.group(
      {
        id: this.fb.control(
          this.stopCardId,
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
        classificationID: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        description: this.fb.control(
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
        reportedByPositionID: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        reportedByNameID: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        actionRequired: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        typeOfObservationCategoryID: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        status: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        stopWorkAuthorityApplied: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        userID: this.fb.control(
          this.UserJsonObj.ID,
          [
            Validators.required
          ]
        )
      }
    ),
      this.StopCardService.GetStopCard(this.User.ID,this.User.Role).subscribe({
        next: data => this.json_data = data.data,
        error: err => this.ErrorMessage = err
      }),
      this.dataService.GetClassification().subscribe({
        next: data => this.classificationList = data.data,
        error: err => this.ErrorMessage = err
      }),
      this.dataService.GetReportedByPosition().subscribe({
        next: data => this.reportedByPositionList = data.data,
        error: err => this.ErrorMessage = err
      }),
      this.dataService.GetTypeOfObservationCategory().subscribe({
        next: data => this.typeOfObservationCategoryList = data.data,
        error: err => this.ErrorMessage = err
      })
  }

  selectedMenace(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetReportedByNameByEmpCode(event.target.value).subscribe({
      next:data=>{
        this.ReportedBy_NameID=data.data.id
        this.ReportedBy_Name=data.data.name,
        this.ReportedByPositionID=data.data.positionId
        console.log("this.ReportedBy_Name")
        console.log(this.ReportedBy_Name)
        console.log("this.ReportedBy_PositionID")
        console.log(this.ReportedByPositionID)
        this.dataService.GetReportedByPositionByID(this.ReportedByPositionID).subscribe({
          next:data=>{
            this.ReportedBy_Position=data.data.name,
            console.log("this.ReportedBy_Position")
            console.log(this.ReportedBy_Position)
          },
          error:err=>{
            this.ErrorMessage=err,
            console.log(err)
          }
        })
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }


  get id() {
    return this.StopCardForm.get('id');
  }
  get date() {
    return this.StopCardForm.get('date');
  }
  get classificationID() {
    return this.StopCardForm.get('classificationID');
  }
  get description() {
    return this.StopCardForm.get('description');
  }
  get empCode() {
    return this.StopCardForm.get('empCode');
  }
  get reportedByPositionID() {
    return this.StopCardForm.get('reportedByPositionID');
  }
  get reportedByNameID() {
    return this.StopCardForm.get('reportedByNameID');
  }
  get actionRequired() {
    return this.StopCardForm.get('actionRequired');
  }
  get typeOfObservationCategoryID() {
    return this.StopCardForm.get('typeOfObservationCategoryID');
  }
  get status() {
    return this.StopCardForm.get('status');
  }
  get stopWorkAuthorityApplied() {
    return this.StopCardForm.get('stopWorkAuthorityApplied');
  }
  get userID() {
    return this.StopCardForm.get('userID');
  }

  // DateSelected(event: any) {
  //   console.log(event.target.value)
  //   this.PositionID=event.target.value
  //   this.dataService.GetReportedByNameByPositionId(this.PositionID).subscribe({
  //     next: data => this.reportedByNameList = data.data,
  //     error: err => this.ErrorMessage = err
  //   })
  // }


  verifecationStateSelected(event: any) {
    var boolValue = JSON.parse(event.target.value);
    this.stopWorkAuthorityApplied?.setValue(boolValue, { onlySelf: true, });
    console.log(" this.verifecationState   " + boolValue)
  }


  submitData() {
    if (this.StopCardForm.valid) {
      this.StopCardService.EditStopCard(this.StopCardForm.value).subscribe({
        next: data => {
          console.log(data)
          this.router.navigate(['/Dashboard/Stopcard'])
        },
        error: error => console.log(error)
      });
      console.log(this.StopCardForm.value)
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.StopCardForm);
    }
  }

}
