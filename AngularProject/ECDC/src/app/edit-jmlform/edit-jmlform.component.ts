import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IDriver } from 'SharedClasses/IDriver';
import { IJMP } from 'SharedClasses/IJMP';
import { IVehicle } from 'SharedClasses/IVehicle';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-edit-jmlform',
  templateUrl: './edit-jmlform.component.html',
  styleUrls: ['./edit-jmlform.component.scss']
})
export class EditJMLFormComponent {
  jmpId!: any;
  jmp!: IJMP;
  JMPForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString: any;
  UserJsonObj: any;
  DriversNames: any[] = [];
  VehiclesName: any[] = [];
  PassengersNames: any[] = [];
  RouteNames: any[] = [];
  CommunicationMethod: any[] = [];

  Driver!: IDriver;
  driverPhone: string = '';
  driverLicenceNo!: string;
  driverLicenceExpire!: Date;

  Vehicle!: IVehicle;
  vehicleType: string = '';
  vehicleColor: string = '';
  vehicleLicenceExpire!: Date;
  vehicleLicenceNo!: string;
  json_data: any;

  constructor(private dataService:DataService,private activatedRoute: ActivatedRoute, private loginService: LoginService, private editDataService: EditDataService, private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.jmpId = params.get("id");
      console.log(this.jmpId)
    }),
      this.editDataService.GetJMPById(this.jmpId).subscribe({
        next: data => {
          this.jmp = data.data,
          console.log('*************************************************************')
          console.log(this.jmp)
          console.log('###################################################')
          this.dataService.GetDriverData(this.jmp.driverNameId).subscribe({
            next: (data: { data: IDriver; }) => {
              this.Driver = data.data,
                this.driverPhone = this.Driver.phoneNumber
              this.driverLicenceNo = this.Driver.licenceNumber
              this.driverLicenceExpire = this.Driver.licenceExpireData;

              console.log("******************")
              console.log(this.driverPhone)
              console.log(this.driverLicenceNo)
              console.log(this.driverLicenceExpire)
              console.log(data.data)
              console.log(this.Driver)
            },
            error: (err: string) => this.ErrorMessage = err
          });
          this.dataService.GetVehicleData(this.jmp.vehicleId).subscribe({
            next: (data: { data: IVehicle; }) => {
              this.Vehicle = data.data,
                this.vehicleType = this.Vehicle.type
              this.vehicleColor = this.Vehicle.color
              this.vehicleLicenceExpire = this.Vehicle.licenceExpireData;
              this.vehicleLicenceNo = this.Vehicle.licenceNumber;
            },
            error: (err: string) => this.ErrorMessage = err
          });
        },
        error: (erorr: string) => this.ErrorMessage = erorr
      }),
      this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);
    this.JMPForm = this.fb.group(
      {
        id: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        company: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        journyNumber: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        // licenceNumber: this.fb.control(
        //   '',
        //   [
        //     Validators.required
        //   ]
        // ),
        speedLimit: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        departureDate: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        // licenceExpireDate: this.fb.control(
        //   '',
        //   [
        //     Validators.required
        //   ]
        // ),
        distance: this.fb.control(
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
        destination: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        purposeOfJourny: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        reachBeforeDark: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        communicationID: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        journyManagerName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        managerNumber: this.fb.control(
          '',
          [
            Validators.required,
            Validators.pattern('^[0-9]{11}$')
          ]
        ),
        driverNameId: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        passengerName1: this.fb.control(
          ''
        ),
        passengerName2: this.fb.control(
          ''
        ),
        passengerName3: this.fb.control(
          ''
        ),
        passengerName4: this.fb.control(
          ''
        )
        ,
        passengerPhone1: this.fb.control(
          '',
          [Validators.pattern('^[0-9]{11}$')]
        )
        ,
        passengerPhone2: this.fb.control(
          '',
          [Validators.pattern('^[0-9]{11}$')]

        )
        ,
        passengerPhone3: this.fb.control(
          '',
          [Validators.pattern('^[0-9]{11}$')]

        )
        ,
        passengerPhone4: this.fb.control(
          '',
          [Validators.pattern('^[0-9]{11}$')]

        )
        ,
        vehicleId: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),

        estimatedArriveDate: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        estimatedArriveTime: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        restLocationNames: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        routeNameID: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),

        inspectionVechile: this.fb.control(
          '',
          [
            Validators.required
          ]
        )
        ,
        status: this.fb.control(
          '',
          [
            Validators.required
          ]
        )
        ,
        userId: this.fb.control(
          this.UserJsonObj.ID,
          [
            Validators.required
          ]
        ),
        nightDrivingReason: this.fb.control(
          null
        )
        ,
        qhseManagerMustApprove: this.fb.control(
          null
        )
      }
    ),
      this.dataService.GetCommuncationMethod().subscribe({
        next:data=>{
          this.CommunicationMethod=data.data,
          console.log(this.CommunicationMethod)
        },
        error:err=>this.ErrorMessage=err
      })
      this.dataService.GetDriverName().subscribe({
        next: data => this.DriversNames = data.data,
        error: err => this.ErrorMessage = err
      }),
      this.dataService.GetVehicleName().subscribe({
        next: data => this.VehiclesName = data.data,
        error: err => this.ErrorMessage = err
      }),
      this.dataService.GetPassengerName().subscribe({
        next: data => this.PassengersNames = data.data,
        error: err => this.ErrorMessage = err
      }),
      this.dataService.GetRoutName().subscribe({
        next: data => this.RouteNames = data.data,
        error: err => this.ErrorMessage = err
      })
  }



  get id() {
    return this.JMPForm.get('id');
  }
  get company() {
    return this.JMPForm.get('company');
  }
  get speedLimit() {
    return this.JMPForm.get('speedLimit');
  }
  get distance() {
    return this.JMPForm.get('distance');
  }
  get journyNumber() {
    return this.JMPForm.get('journyNumber');
  }
  get date() {
    return this.JMPForm.get('date');
  }
  get departureDate() {
    return this.JMPForm.get('departureDate');
  }
  get destination() {
    return this.JMPForm.get('destination');
  }
  get purposeOfJourny() {
    return this.JMPForm.get('purposeOfJourny');
  }
  get reachBeforeDark() {
    return this.JMPForm.get('reachBeforeDark');
  }
  get communicationID() {
    return this.JMPForm.get('communicationID');
  }
  get journyManagerName() {
    return this.JMPForm.get('journyManagerName');
  }
  get driverNameId() {
    return this.JMPForm.get('driverNameId');
  }
  get phoneNumber() {
    return this.JMPForm.get('phoneNumber');
  }
  get licenceNumber() {
    return this.JMPForm.get('licenceNumber');
  }
  get passengerName1() {
    return this.JMPForm.get('passengerName1');
  }

  get passengerName2() {
    return this.JMPForm.get('passengerName2');
  }

  get passengerName3() {
    return this.JMPForm.get('passengerName3');
  }

  get passengerName4() {
    return this.JMPForm.get('passengerName4');
  }

  get passengerPhone1() {
    return this.JMPForm.get('passengerPhone1');
  }

  get passengerPhone2() {
    return this.JMPForm.get('passengerPhone2');
  }

  get passengerPhone3() {
    return this.JMPForm.get('passengerPhone3');
  }

  get passengerPhone4() {
    return this.JMPForm.get('passengerPhone4');
  }

  get vehicleId() {
    return this.JMPForm.get('vehicleId');
  }
  get estimatedArriveDate() {
    return this.JMPForm.get('estimatedArriveDate');
  }
  get licenceExpireDate() {
    return this.JMPForm.get('licenceExpireDate');
  }
  get estimatedArriveTime() {
    return this.JMPForm.get('estimatedArriveTime');
  }
  get restLocationNames() {
    return this.JMPForm.get('restLocationNames');
  }
  get routeNameID() {
    return this.JMPForm.get('routeNameID');
  }
  get passengerID() {
    return this.JMPForm.get('passengerID');
  }
  get inspectionVechile() {
    return this.JMPForm.get('inspectionVechile');
  }
  get status() {
    return this.JMPForm.get('status');
  }
  get nightDrivingReason() {
    return this.JMPForm.get('nightDrivingReason');
  }
  get qhseManagerMustApprove() {
    return this.JMPForm.get('qhseManagerMustApprove');
  }
  get managerNumber() {
    return this.JMPForm.get('managerNumber');
  }

  onChange(event: any) {
    console.log(event.target.value)
    this.dataService.GetDriverData(event.target.value).subscribe({
      next: (data: { data: IDriver; }) => {
        this.Driver = data.data,
          this.driverPhone = this.Driver.phoneNumber
        this.driverLicenceNo = this.Driver.licenceNumber
        this.driverLicenceExpire = this.Driver.licenceExpireData;

        console.log("******************")
        console.log(this.driverPhone)
        console.log(this.driverLicenceNo)
        console.log(this.driverLicenceExpire)
        console.log(data.data)
        console.log(this.Driver)
      },
      error: (err: string) => this.ErrorMessage = err
    });

  }

  OnVehiclehange(event: any) {
    console.log(event.target.value)
    this.dataService.GetVehicleData(event.target.value).subscribe({
      next: (data: { data: IVehicle; }) => {
        this.Vehicle = data.data,
          this.vehicleType = this.Vehicle.type
        this.vehicleColor = this.Vehicle.color
        this.vehicleLicenceExpire = this.Vehicle.licenceExpireData;
        this.vehicleLicenceNo = this.Vehicle.licenceNumber;
      },
      error: (err: string) => this.ErrorMessage = err
    });

  }
  submitData() {
    // if (this.JMPForm.valid) {
    //   const Formdata = new FormData();
    //   Formdata.append('id', this.jmpId);
    //   Formdata.append('driverNameId', this.driverNameId?.value);
    //   //Formdata.append('timeOfEvent', this.timeOfEvent?.value);
      if (this.JMPForm.valid) {
        this.editDataService.EditJMPForm(this.jmpId,this.JMPForm.value).subscribe({
          next: (data: any) => {
            console.log('from service')
            console.log(data)
            this.router.navigate(['Dashboard/SJPTable']);
          },
          error: (error: any) => {
            console.log("from Error")
            console.log(error)
          }
        });
      }
      else {
        console.log("E+++++====error in : ");
        console.log(this.JMPForm);
      }
    // }
  }
  // Download() {
  //   let workbook = new Workbook();

  //   let worksheet = workbook.addWorksheet("SJP Data");

  //   let header = [
  //     "Id",
  //     "Company",
  //     "Speed Limit",
  //     "Distance",
  //     "Journy Number",
  //     "Date",
  //     "Destination",
  //     "PurposeOf Journy",
  //     "Reach Before Dark",
  //     "Communication ID",
  //     "Journy Manager Name",
  //     "Manager Number",
  //     "Driver Name Id",
  //     "Phone Number",
  //     "Licence Number",
  //     "licenceExpireDate",
  //     "Departure Date",
  //     "Time",
  //     "Vehicle Id",
  //     "Estimated Arrive Date",
  //     "Estimated Arrive Time",
  //     "RestLocation Names",
  //     "Route Name ID",
  //     "Passenger ID",
  //     "Inspection Vechile",
  //     "Status",
  //     "Night Driving Reason",
  //     "QHSE Manager Must Approve",
  //     "User Name"
  //   ];

  //   // this.json_data.push(this.accidentForm.value)

  //   let headerRow = worksheet.addRow(header);

  //   for (let x1 of this.json_data) {
  //     let x2 = Object.keys(x1);
  //     let temp: any[] = []
  //     for (let y of x2) {
  //       temp.push(x1[y])
  //     }
  //     worksheet.addRow(temp)
  //   }

  //   let fname = "SJP Report"

  //   //add data and file name and download
  //   workbook.xlsx.writeBuffer().then((data) => {
  //     let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
  //     saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
  //   });
  // }
}
