import { Component } from '@angular/core';
import { AddBOPService } from 'Services/add-bop.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { PTSMService } from 'Services/ptsm.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  accidentsList:any;
  accidentcount:number=0;
  stopCardList:any;
  stopCardcount:number=0;
  JMPList:any;
  JMPcount:number=0;
  accidentCausesList:any;
  accidentCausescount:number=0;
  classificationList:any;
  classificationcount:number=0;
  classificationOfAccidentList:any;
  classificationOfAccidentcount:number=0;
  comminucationMethodList:any;
  comminucationMethodcount:number=0;
  driverList:any;
  drivercount:number=0;
  passengerList:any;
  passengercount:number=0;
  preventionCategoryList:any;
  preventionCategorycount:number=0;
  QHSEPositionList:any;
  QHSEPositioncount:number=0;
  QHSEPositionNameList:any;
  QHSEPositionNamecount:number=0;
  reportedByNameList:any;
  reportedByNamecount:number=0;
  reportedByPositionList:any;
  reportedByPositioncount:number=0;
  rigList:any;
  rigcount:number=0;
  routeNameList:any;
  routeNamecount:number=0;
  toolPusherPositionList:any;
  toolPusherPositioncount:number=0;
  toolPusherPositionNameList:any;
  toolPusherPositionNamecount:number=0;
  typeOfInjuryList:any;
  typeOfInjurycount:number=0;
  typeOfObserviationList:any;
  typeOfObserviationcount:number=0;
  vehicleList:any;
  vehiclecount:number=0;
  violationCategoryList:any;
  violationCategorycount:number=0;
  rigMovePerformanceList:any;
  rigMovePerformancecount:number=0;
  PTSMList:any;
  PTSMcount:number=0;
  BOPList:any;
  BOPcount:number=0;

  User:any;
  TotalManHours:any;

  constructor(private ptsmService:PTSMService,private loginService:LoginService,private dataService: DataService,private BopService:AddBOPService) { }

  ngOnInit(): void {
    this.User=this.loginService.currentUser.getValue();
    console.log("/////////////************************")
    console.log(this.User)
    this.dataService.GetAccidents(this.User.ID,this.User.Role).subscribe({
      next:data=>{
        console.log("data.data.length")
        console.log(data.data.length)
        this.accidentsList=data.data,
        this.accidentcount=this.accidentsList.length
      }
    })
    this.ptsmService.GetPTSM(this.User.ID,this.User.Role).subscribe({
      next:data=>{
        console.log("data.data.length")
        console.log(data.data.length)
        this.PTSMList=data.data,
        this.PTSMcount=this.PTSMList.length
      }
    })
    this.BopService.GetBOP(this.User.ID,this.User.Role).subscribe({
      next:data=>{
        console.log("data.data.length")
        console.log(data.data.length)
        this.BOPList=data.data,
        this.BOPcount=this.BOPList.length
      }
    })

    this.BopService.GetTotalManHours(this.User.ID,this.User.Role).subscribe({
      next:data=>{
        console.log("data.data.length")
        console.log(data.data.length)
        this.TotalManHours=data.data
      }
    })

    this.dataService.GetStopCards(this.User.ID,this.User.Role).subscribe({
      next:data=>{
        this.stopCardList=data.data,
        this.stopCardcount=this.stopCardList.length
      }
    })
    this.dataService.GetJMPs().subscribe({
      next:data=>{
        this.JMPList=data.data,
        this.JMPcount=this.JMPList.length
      }
    })
    this.dataService.GetRigPerformanceData(this.User.ID,this.User.Role).subscribe({
      next:data=>{
        console.log("rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr"+data.data)
        this.rigMovePerformanceList=data.data,
        this.rigMovePerformancecount=this.rigMovePerformanceList.length
      }
    })
    // this.dataService.GetAccidentCauses().subscribe({
    //   next:data=>{
    //     this.accidentCausesList=data.data,
    //     this.accidentCausescount=this.accidentCausesList.length
    //   }
    // })
    // this.dataService.GetClassification().subscribe({
    //   next:data=>{
    //     this.classificationList=data.data,
    //     this.classificationcount=this.classificationList.length
    //   }
    // })
    // this.dataService.GetClassificationOfAccident().subscribe({
    //   next:data=>{
    //     this.classificationOfAccidentList=data.data,
    //     this.classificationOfAccidentcount=this.classificationOfAccidentList.length
    //   }
    // })
    // this.dataService.GetCommuncationMethod().subscribe({
    //   next:data=>{
    //     this.comminucationMethodList=data.data,
    //     this.comminucationMethodcount=this.comminucationMethodList.length
    //   }
    // })
    // this.dataService.GetDriverName().subscribe({
    //   next:data=>{
    //     this.driverList=data.data,
    //     this.drivercount=this.driverList.length
    //   }
    // })
    // this.dataService.GetPassengerName().subscribe({
    //   next:data=>{
    //     this.passengerList=data.data,
    //     this.passengercount=this.passengerList.length
    //   }
    // })
    // this.dataService.GetPreventionCategory().subscribe({
    //   next:data=>{
    //     this.preventionCategoryList=data.data,
    //     this.preventionCategorycount=this.preventionCategoryList.length
    //   }
    // })
    // this.dataService.GetQHSEPosition().subscribe({
    //   next:data=>{
    //     this.QHSEPositionList=data.data,
    //     this.QHSEPositioncount=this.QHSEPositionList.length
    //   }
    // })
    // this.dataService.GetQHSEPositionName().subscribe({
    //   next:data=>{
    //     this.QHSEPositionNameList=data.data,
    //     this.QHSEPositionNamecount=this.QHSEPositionNameList.length
    //   }
    // })
    // this.dataService.GetReportedByName().subscribe({
    //   next:data=>{
    //     this.reportedByNameList=data.data,
    //     this.reportedByNamecount=this.reportedByNameList.length
    //   }
    // })
    // this.dataService.GetReportedByPosition().subscribe({
    //   next:data=>{
    //     this.reportedByPositionList=data.data,
    //     this.reportedByPositioncount=this.reportedByPositionList.length
    //   }
    // })
    // this.dataService.GetRig().subscribe({
    //   next:data=>{
    //     this.rigList=data.data,
    //     this.rigcount=this.rigList.length
    //   }
    // })
    // this.dataService.GetRoutName().subscribe({
    //   next:data=>{
    //     this.routeNameList=data.data,
    //     this.routeNamecount=this.routeNameList.length
    //   }
    // })
    // this.dataService.GetToolPusherPosition().subscribe({
    //   next:data=>{
    //     this.toolPusherPositionList=data.data,
    //     this.toolPusherPositioncount=this.toolPusherPositionList.length
    //   }
    // })
    // this.dataService.GetToolPusherPositionName().subscribe({
    //   next:data=>{
    //     this.toolPusherPositionNameList=data.data,
    //     this.toolPusherPositionNamecount=this.toolPusherPositionNameList.length
    //   }
    // })
    // this.dataService.GetTypeOfInjury().subscribe({
    //   next:data=>{
    //     this.typeOfInjuryList=data.data,
    //     this.typeOfInjurycount=this.typeOfInjuryList.length
    //   }
    // })
    // this.dataService.GetTypeOfObservationCategory().subscribe({
    //   next:data=>{
    //     this.typeOfObserviationList=data.data,
    //     this.typeOfObserviationcount=this.typeOfObserviationList.length
    //   }
    // })
    // this.dataService.GetVehicleName().subscribe({
    //   next:data=>{
    //     this.vehicleList=data.data,
    //     this.vehiclecount=this.vehicleList.length
    //   }
    // })
    // this.dataService.GetViolationCategory().subscribe({
    //   next:data=>{
    //     this.violationCategoryList=data.data,
    //     this.violationCategorycount=this.violationCategoryList.length
    //   }
    // })
  }
}
