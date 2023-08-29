import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddnewJMPService } from 'Services/addnew-jmp.service';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IDriver } from 'SharedClasses/IDriver';
import { IVehicle } from 'SharedClasses/IVehicle';
import { SignalrService } from 'Services/signalr.service';


@Component({
  selector: 'app-jmpform',
  templateUrl: './jmpform.component.html',
  styleUrls: ['./jmpform.component.scss']
})
export class JMPFormComponent {
  JMPForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  DriversNames: any[] = [];
  VehiclesName: any[] = [];
  PassengersNames: any[] = [];
  RouteNames: any[] = [];
  CommunicationMethod: any[] = [];
  // inspectionVechileTemp:string='';

  UserJsonString: any;
  UserJsonObj: any;

  Driver!: IDriver;
  driverPhone: string = '';
  driverLicenceNo!: string;
  driverLicenceExpire!: Date;

  Vehicle!: IVehicle;
  vehicleType: string = '';
  vehicleColor: string = '';
  vehicleLicenceExpire!: Date;
  vehicleLicenceNo!: string;


  constructor(
    private JMPService: AddnewJMPService,
    private SignalR_Service: SignalrService,
    private loginService: LoginService,
    private dataService: DataService,
    private jmpservice: AddnewJMPService,
    private fb: FormBuilder) {
  }

  ngOnInit() {
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
        speedLimit: this.fb.control(
          '',
          [
            Validators.required,
            Validators.pattern('^[1-9]|[1-9][0-9]+$')
          ]
        ),
        departureDate: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        distance: this.fb.control(
          '',
          [
            Validators.required,
            Validators.pattern('^[1-9]|[1-9][0-9]+$')
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
        qHSEManagerMustApprove: this.fb.control(
          null
        )
      }
    )
    this.jmpservice.GetJMPsForExcel().subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    }),
      this.dataService.GetCommuncationMethod().subscribe({
        next: data => this.CommunicationMethod = data.data,
        error: err => this.ErrorMessage = err
      }),
      this.dataService.GetCommuncationMethod().subscribe({
        next: data => this.CommunicationMethod = data.data,
        error: err => this.ErrorMessage = err
      }),
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


  changeCity(e: any) {
    this.passengerID?.setValue(e.target.value, {
      onlySelf: true,
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
  // get time() {
  //   return this.JMPForm.get('time');
  // }

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
  get qHSEManagerMustApprove() {
    return this.JMPForm.get('qHSEManagerMustApprove');
  }
  get managerNumber() {
    return this.JMPForm.get('managerNumber');
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


  onChange(event: any) {
    console.log(event.target.value)
    this.dataService.GetDriverData(event.target.value).subscribe({
      next: data => {
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
      error: err => this.ErrorMessage = err
    });

  }

  OnVehiclehange(event: any) {
    console.log(event.target.value)
    this.dataService.GetVehicleData(event.target.value).subscribe({
      next: data => {
        this.Vehicle = data.data,
          this.vehicleType = this.Vehicle.type
        this.vehicleColor = this.Vehicle.color
        this.vehicleLicenceExpire = this.Vehicle.licenceExpireData;
        this.vehicleLicenceNo = this.Vehicle.licenceNumber;
      },
      error: err => this.ErrorMessage = err
    });
  }


  submitData() {
    this.jmpservice.AddJMP(this.JMPForm.value).subscribe({
      next: data => {
        console.log(data)
        console.log(this.JMPForm.value)
        location.reload();
      },
      error: error => console.log(error)
    });
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet('SJP Data');

    let header = Object.keys(this.json_data[0]);

    let headerRow = worksheet.addRow(header);

    headerRow.fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: {
        argb: 'ff0e0a27',
      },
    };

    headerRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
      color: {
        argb: 'ffffffff',
      },
    };

    headerRow.alignment = {
      horizontal: 'center',
      vertical: 'middle',
      wrapText: true,
    };

    headerRow.eachCell((cell, colNumber) => {
      worksheet.getColumn(colNumber).width = Math.max(
        header[colNumber - 1].length + 10,
        15
      );
      worksheet.getRow(1).height = 35;
    });

    for (let x1 of this.json_data) {
      let x2 = Object.keys(x1);
      let temp: any[] = [];
      for (let y of x2) {
        if (typeof x1[y] === 'object' && x1[y] instanceof Array) {
          for (let z of x1[y]) {
            temp.push(z.passengerName);
            temp.push(z.passengerTelephone);
          }
        } else {
          temp.push(x1[y]);
        }
      }
      worksheet.addRow(temp);
    }

    const columnNumberStart = 38;
    const rowNumber = 1;
    const cell = worksheet.getCell(Number(rowNumber), Number(columnNumberStart));
    const columnName = cell.address.split(/(\$?[A-Z]+)/)[1]; // extracts the column name from the cell address
    const cellAddress = columnName + rowNumber;
    const columnNumberEnd = workbook.getWorksheet('SJP Data').lastColumn.number;;
    const cellEnd = worksheet.getCell(Number(rowNumber), Number(columnNumberEnd));
    const columnNameEnd = cellEnd.address.split(/(\$?[A-Z]+)/)[1]; // extracts the column name from the cell address
    const cellAddressEnd = columnNameEnd + rowNumber;
    const mergeCell = `${cellAddress}:${cellAddressEnd}`;
    worksheet.mergeCells(mergeCell);

    console.log('mergeCell');
    console.log(mergeCell);

    let fname = 'SJP Report';

    // add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], {
        type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
      });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}


