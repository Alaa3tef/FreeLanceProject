import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { DeleteDataService } from 'Services/delete-data.service';
import { GetdataByPageService } from 'Services/getdata-by-page.service';
import { LoginService } from 'Services/login.service';
import { IDriver } from 'SharedClasses/IDriver';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-driver',
  templateUrl: './driver.component.html',
  styleUrls: ['./driver.component.scss']
})
export class DriverComponent {
  private ListOfDriver = new BehaviorSubject<IDriver[]>([]);
  readonly DriverList = this.ListOfDriver.asObservable();
  page: number = 1;
  count: number = 0;
  productSize: number = 5;
  indexofPages: number = 1;
  countOfPage: number = 0;
  TempArray: any[] = [];
  IsUser: boolean = false;
  IsRadio: boolean = false;
  IsAdmin: boolean = false;
  json_data: any[] = [];

  constructor(private getDataByPage: GetdataByPageService, private dataService: DataService, private deleteService: DeleteDataService, private loginService: LoginService) { }

  ngOnInit(): void {
    this.getpages(1)
    this.loginService.isAdmin.subscribe({
      next: data => {
        this.IsAdmin = data
      }
    })
    this.loginService.isRadio.subscribe({
      next: data => {
        this.IsRadio = data
      }
    })
    this.dataService.GetDriverDataForExcel().subscribe({
      next: data => this.json_data = data.data,
      error: err => console.log(err)
    })
  }

  DeleteDriver(Driver: IDriver) {
    if (confirm("Are you sure you want to delete this Record?")) {
      // user clicked "Yes"
      // do something, such as call an API to delete the item
      this.deleteService.DeleteDrivers(Driver).subscribe({
        next: data => {
          console.log(data)
          this.getpages(this.indexofPages)
        },
        error: err => {
          console.log(err);
        }
      })
    }
    else {
      // user clicked "No"
      // do nothing
    }
  }

  getpages(num: number) {
    this.getDataByPage.GetDriverByPage(num).subscribe({
      next: data => {
        this.ListOfDriver.next(data.items)
        this.countOfPage = data.count;
        this.TempArray = new Array(this.countOfPage);
      },
      error: err => {
        console.log(err)
      }
    })
    this.indexofPages = num;
    console.log("getpages" + this.indexofPages);
  }
  gotleft() {
    (this.indexofPages > 1) ? this.indexofPages -= 1 : this.indexofPages = 1;
    this.getpages(this.indexofPages);
    console.log("gotleft" + this.indexofPages);
  }
  gotoright() {

    (this.indexofPages < this.countOfPage) ? this.indexofPages += 1 : this.indexofPages = this.countOfPage;
    this.getpages(this.indexofPages);
    console.log("gotoright" + this.indexofPages);
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Drivers Data");


    let header = Object.keys(this.json_data[0]);

    let headerRow = worksheet.addRow(header);

    headerRow.fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: {
        argb: 'ff0e0a27'
      }
    }

    headerRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
      color: {
        argb: 'ffffffff'
      }
    }

    headerRow.alignment = {
      horizontal: 'center',
      vertical: 'middle',
      wrapText: true
    }

    headerRow.eachCell((cell, colNumber) => {
      worksheet.getColumn(colNumber).width = Math.max((header[colNumber - 1].length) + 10, 15);
      worksheet.getRow(1).height = 35;
    });



    for (let x1 of this.json_data) {
      let x2 = Object.keys(x1);
      let temp: any[] = []
      for (let y of x2) {
        temp.push(x1[y])
      }
      worksheet.addRow(temp)
    }

    let fname = "Drivers Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
