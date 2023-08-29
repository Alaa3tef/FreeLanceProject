import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AddNewAccidentService } from 'Services/add-new-accident.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IAccident } from 'SharedClasses/IAccident';
import { IAccidentCauses } from 'SharedClasses/IAccidentCauses';
import { IClassificationOfAccident } from 'SharedClasses/IClassificationOfAccident';
import { IPreventionCategory } from 'SharedClasses/IPreventionCategory';
import { IQHSEPosition } from 'SharedClasses/IQHSEPosition';
import { IQHSEPositionName } from 'SharedClasses/IQHSEPositionName';
import { IRig } from 'SharedClasses/IRig';
import { IToolPusherPosition } from 'SharedClasses/IToolPusherPosition';
import { IToolPusherPositionName } from 'SharedClasses/IToolPusherPositionName';
import { ITypeOfInjury } from 'SharedClasses/ITypeOfInjury';
import { IViolationCategory } from 'SharedClasses/IViolationCategory';

@Component({
  selector: 'app-edit-accident',
  templateUrl: './edit-accident.component.html',
  styleUrls: ['./edit-accident.component.scss']
})
export class EditAccidentComponent {
  accidentId: any;
  accident!: IAccident;
  ErrorMessage: string = "";
  accidentForm!: FormGroup;
  date: Date = new Date();
  rigList: IRig[] = []
  typeOfInjuryList: ITypeOfInjury[] = []
  violationCategoryList: IViolationCategory[] = []
  accidentCausesList: IAccidentCauses[] = []
  preventionCategoryList: IPreventionCategory[] = []
  classificationOfAccidentList: IClassificationOfAccident[] = []
  qhsePositionNameList: IQHSEPositionName[] = []
  toolPusherPositionNameList: IToolPusherPositionName[] = []
  toolPusherPositionList: IToolPusherPosition[] = []
  qhsePositionList: IQHSEPosition[] = []
  QHSEPositionID: number = 0;
  PusherPositionID: number = 0;
  base64: any;

  // QHSECodeList: any;

  QHSECodeRecord: any;

  QHSEPositionCodeID: number = 0;
  QHSENameCodeID: number = 0;
  QHSEposition: string = '';
  QHSEName: string = '';

  ToolPusherCodeList: any;

  ToolPusherCodeRecord: any;

  QHSECodeList: any;
  QHSE_NameID:number=0;
  QHSE_Name:string='';
  // QHSEPositionID: number = 0;
  QHSE_Position:string='';

  // ToolPusherCodeList: any;
  // PusherPositionID: number = 0;
  PusherPosition:string='';
  Pusher_Name:string='';
  Pusher_NameId:number=0;

  fileToEdit!: File;

  UserJsonString: any
  UserJsonObj: any

  User:any;

  constructor(private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService,
    private accidentService: AddNewAccidentService,
    private fb: FormBuilder,
    private router: Router) { }


  ngOnInit(): void {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.accidentId = params.get("id");
      console.log(this.accidentId)
    }),
      this.accidentService.GetAccidentByID(this.accidentId,this.User.ID,this.User.Role).subscribe({
        next: data => {
          this.accident = data.data,
            console.log('*************************************************************')
          console.log(this.accident)
          this.date = this.accident.dateOfEvent
          console.log('###################################################')

          const file = data.data.imageOfaccident;
          this.accidentForm.patchValue({
            ImageOfaccident: file
          });
          this.accidentForm.get('ImageOfaccident')?.updateValueAndValidity()

          const reader = new FileReader();     //to reade image file and dispaly it
          reader.onload = () => {
            this.base64 = reader.result as string;
          }
          this.dataService.GetQHSEPositionNameByEmpCode(this.accident.qhseEmpCode).subscribe({
            next:data=>{
              this.QHSE_NameID=data.data.id
              this.QHSE_Name=data.data.name,
              this.QHSEPositionID=data.data.positionId
              console.log("this.QHSE_Name")
              console.log(this.QHSE_Name)
              console.log("this.QHSE_PositionID")
              console.log(this.QHSEPositionID)
              this.dataService.GetQHSEPositionByID(this.QHSEPositionID).subscribe({
                next:data=>{
                  this.QHSE_Position=data.data.name,
                  console.log("this.QHSE_Position")
                  console.log(this.QHSE_Position)
                },
                error:err=>{
                  this.ErrorMessage=err,
                  console.log(this.ErrorMessage)
                }
              })
            },
            error:err=>{
              this.ErrorMessage=err,
              console.log(err)
            }
          })
          this.dataService.GetToolPusherPositionNameByEmpCode(this.accident.pusherEmpCode).subscribe({
            next:data=>{
              this.Pusher_NameId=data.data.id
              this.Pusher_Name=data.data.name,
              this.PusherPositionID=data.data.positionId
              console.log("this.Pusher_Name")
              console.log(this.Pusher_Name)
              console.log("this.PusherPositionID")
              console.log(this.PusherPositionID)
              this.dataService.GetToolPusherPositionByID(this.PusherPositionID).subscribe({
                next:data=>{
                  this.PusherPosition=data.data.name,
                  console.log("this.PusherPosition")
                  console.log(this.PusherPosition)
                },
                error:err=>{
                  this.ErrorMessage=err,
                  console.log(this.ErrorMessage)
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
      this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue()),
      this.UserJsonObj = JSON.parse(this.UserJsonString),
      this.dataService.GetQHSEPositionName().subscribe({
        next: data => {
          this.QHSECodeList = data.data,
            console.log("this.QHSECodeList")
          console.log(this.QHSECodeList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log("this.ErrorMessage")
          console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetToolPusherPositionName().subscribe({
        next: data => {
          this.ToolPusherCodeList = data.data,
            console.log("this.ToolPusherCodeList")
          console.log(this.ToolPusherCodeList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log("this.ErrorMessage")
          console.log(this.ErrorMessage)
        }
      })
    this.accidentForm = this.fb.group({
      id: this.fb.control(0, [Validators.required]),
      rigId: this.fb.control('', [Validators.required]),
      timeOfEvent: this.fb.control('', [Validators.required]),
      dateOfEvent: this.fb.control('', [Validators.required]),
      typeOfInjuryID: this.fb.control('', [Validators.required]),
      violationCategoryId: this.fb.control('', [Validators.required]),
      accidentCausesId: this.fb.control('', [Validators.required]),
      preventionCategoryId: this.fb.control('', [Validators.required]),
      classificationOfAccidentId: this.fb.control('', [Validators.required]),
      accidentLocation: this.fb.control('', [Validators.required]),
      qhsePositionNameId: this.fb.control('', [Validators.required]),
      toolPusherPositionNameId: this.fb.control('', [Validators.required]),
      drillerName: this.fb.control('', [Validators.required]),
      pusherEmpCode: this.fb.control('', [Validators.required]),
      qhseEmpCode: this.fb.control('',[Validators.required]),
      descriptionOfTheEvent: this.fb.control('', [Validators.required]),
      toolPusherPositionId: this.fb.control('', [Validators.required]),
      qhsePositionId: this.fb.control('', [Validators.required]),
      immediateActionType: this.fb.control('', [Validators.required]),
      directCauses: this.fb.control('', [Validators.required]),
      rootCauses: this.fb.control('', [Validators.required]),
      recommendations: this.fb.control('', [Validators.required]),
      // pictures: this.fb.control('', [Validators.required]),
      userID: this.fb.control(this.UserJsonObj.ID, [Validators.required]),
      imageOfaccident: this.fb.control(null)
    }),
      // this.userID=this.UserJsonObj.ID;
      this.dataService.GetAccidentCauses().subscribe({
        next: data => {
          this.accidentCausesList = data.data,
            console.log(this.accidentCausesList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetRig().subscribe({
        next: data => {
          this.rigList = data.data,
            console.log(this.rigList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetClassificationOfAccident().subscribe({
        next: data => {
          this.classificationOfAccidentList = data.data,
            console.log(this.classificationOfAccidentList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetPreventionCategory().subscribe({
        next: data => {
          this.preventionCategoryList = data.data,
            console.log(this.preventionCategoryList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetTypeOfInjury().subscribe({
        next: data => {
          this.typeOfInjuryList = data.data,
            console.log(this.typeOfInjuryList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetViolationCategory().subscribe({
        next: data => {
          this.violationCategoryList = data.data,
            console.log(this.violationCategoryList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetToolPusherPosition().subscribe({
        next: data => {
          this.toolPusherPositionList = data.data,
            console.log(this.accidentCausesList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetQHSEPosition().subscribe({
        next: data => {
          this.qhsePositionList = data.data,
            console.log(this.accidentCausesList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      })
  }

  selectedMenace(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetQHSEPositionNameByEmpCode(event.target.value).subscribe({
      next:data=>{
        this.QHSE_NameID=data.data.id
        this.QHSE_Name=data.data.name,
        this.QHSEPositionID=data.data.positionId
        console.log("this.QHSE_Name")
        console.log(this.QHSE_Name)
        console.log("this.QHSE_PositionID")
        console.log(this.QHSEPositionID)
        this.dataService.GetQHSEPositionByID(this.QHSEPositionID).subscribe({
          next:data=>{
            this.QHSE_Position=data.data.name,
            console.log("this.QHSE_Position")
            console.log(this.QHSE_Position)
          },
          error:err=>{
            this.ErrorMessage=err,
            console.log(this.ErrorMessage)
          }
        })
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }

  selectedMenaceTool(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetToolPusherPositionNameByEmpCode(event.target.value).subscribe({
      next:data=>{
        this.Pusher_NameId=data.data.id
        this.Pusher_Name=data.data.name,
        this.PusherPositionID=data.data.positionId
        console.log("this.Pusher_Name")
        console.log(this.Pusher_Name)
        console.log("this.PusherPositionID")
        console.log(this.PusherPositionID)
        this.dataService.GetToolPusherPositionByID(this.PusherPositionID).subscribe({
          next:data=>{
            this.PusherPosition=data.data.name,
            console.log("this.PusherPosition")
            console.log(this.PusherPosition)
          },
          error:err=>{
            this.ErrorMessage=err,
            console.log(this.ErrorMessage)
          }
        })
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }

  // ToolPusherSelected(event: any) {
  //   this.PusherPositionID = event.target.value
  //   this.dataService.GetToolPusherPositionNameByPositionId(this.PusherPositionID).subscribe({
  //     next: data => this.toolPusherPositionNameList = data.data,
  //     error: err => this.ErrorMessage = err
  //   })
  // }

  // QHSESelected(event: any) {
  //   this.QHSEPositionID = event.target.value
  //   this.dataService.GetTQHSEPositionNameByPositionId(this.QHSEPositionID).subscribe({
  //     next: data => this.qhsePositionNameList = data.data,
  //     error: err => this.ErrorMessage = err
  //   })
  // }

  // get id() {
  //   return this.accidentForm.get('id');
  // }
  get rigId() {
    return this.accidentForm.get('rigId');
  }
  get timeOfEvent() {
    return this.accidentForm.get('timeOfEvent');
  }
  get dateOfEvent() {
    return this.accidentForm.get('dateOfEvent');
  }
  get typeOfInjuryID() {
    return this.accidentForm.get('typeOfInjuryID');
  }
  get violationCategoryId() {
    return this.accidentForm.get('violationCategoryId');
  }
  get accidentCausesId() {
    return this.accidentForm.get('accidentCausesId');
  }
  get preventionCategoryId() {
    return this.accidentForm.get('preventionCategoryId');
  }
  get pusherEmpCode() {
    return this.accidentForm.get('pusherEmpCode');
  }
  get qhseEmpCode() {
    return this.accidentForm.get('qhseEmpCode');
  }
  get classificationOfAccidentId() {
    return this.accidentForm.get('classificationOfAccidentId');
  }
  get accidentLocation() {
    return this.accidentForm.get('accidentLocation');
  }
  get qhsePositionNameId() {
    return this.accidentForm.get('qhsePositionNameId');
  }
  get toolPusherPositionNameId() {
    return this.accidentForm.get('toolPusherPositionNameId');
  }
  get drillerName() {
    return this.accidentForm.get('drillerName');
  }
  get descriptionOfTheEvent() {
    return this.accidentForm.get('descriptionOfTheEvent');
  }
  get toolPusherPositionId() {
    return this.accidentForm.get('toolPusherPositionId');
  }
  get qhsePositionId() {
    return this.accidentForm.get('qhsePositionId');
  }
  get immediateActionType() {
    return this.accidentForm.get('immediateActionType');
  }
  get directCauses() {
    return this.accidentForm.get('directCauses');
  }
  get rootCauses() {
    return this.accidentForm.get('rootCauses');
  }
  get recommendations() {
    return this.accidentForm.get('recommendations');
  }
  // get pictures() {
  //   return this.accidentForm.get('pictures');
  // }
  get userID() {
    return this.accidentForm.get('userID');
  }
  get imageOfaccident() {
    return this.accidentForm.get('ImageOfaccident');
  }


  submitData() {
    if (this.accidentForm.valid) {
      const Formdata = new FormData();
      Formdata.append('id', this.accidentId);
      Formdata.append('ImageOfaccident', this.imageOfaccident?.value);
      Formdata.append('rigId', this.rigId?.value);
      Formdata.append('timeOfEvent', this.timeOfEvent?.value);
      Formdata.append('dateOfEvent', this.dateOfEvent?.value);
      Formdata.append('typeOfInjuryID', this.typeOfInjuryID?.value);
      Formdata.append('violationCategoryId', this.violationCategoryId?.value);
      Formdata.append('accidentCausesId', this.accidentCausesId?.value);
      Formdata.append('preventionCategoryId', this.preventionCategoryId?.value);
      Formdata.append('classificationOfAccidentId', this.classificationOfAccidentId?.value);
      Formdata.append('accidentLocation', this.accidentLocation?.value);
      Formdata.append('qhsePositionNameId', this.qhsePositionNameId?.value);
      Formdata.append('toolPusherPositionNameId', this.toolPusherPositionNameId?.value);
      Formdata.append('drillerName', this.drillerName?.value);
      Formdata.append('pusherEmpCode', this.pusherEmpCode?.value);
      Formdata.append('qhseEmpCode', this.qhseEmpCode?.value);
      Formdata.append('descriptionOfTheEvent', this.descriptionOfTheEvent?.value);
      Formdata.append('toolPusherPositionId', this.toolPusherPositionId?.value);
      Formdata.append('qhsePositionId', this.qhsePositionId?.value);
      Formdata.append('immediateActionType', this.immediateActionType?.value);
      Formdata.append('directCauses', this.directCauses?.value);
      Formdata.append('rootCauses', this.rootCauses?.value);
      Formdata.append('recommendations', this.recommendations?.value);
      // Formdata.append('pictures', this.pictures?.value);
      Formdata.append('userID', this.UserJsonObj.ID);

      this.accidentService.EditAccident(Formdata).subscribe({
        next: data => {
          console.log(data)
          this.router.navigate(['/Dashboard/Accidents']);
        },
        error: error => console.log(error)
      });
      // console.log(this.accidentForm.value)
      // this.router.navigate(['/Dashboard/AccidentTable'])
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.accidentForm);
    }
  }


  GetImagePath(event: any) {

    const file = event.target.files[0];
    this.accidentForm.patchValue({
      ImageOfaccident: file
    });
    this.accidentForm.get('ImageOfaccident')?.updateValueAndValidity()

    const reader = new FileReader();     //to reade image file and dispaly it
    reader.onload = () => {
      this.base64 = reader.result as string;
    }
    reader.readAsDataURL(file)

      // const file: File = event.target.files[0];
      // this.fileToEdit = file;
  }

}
