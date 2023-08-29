import { Component } from '@angular/core';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
import { BehaviorSubject } from 'rxjs';
import { AddBOPService } from 'Services/add-bop.service';
import { LoginService } from 'Services/login.service';
import { IBOP } from 'SharedClasses/IBOP';

@Component({
  selector: 'app-bop-table',
  templateUrl: './bop-table.component.html',
  styleUrls: ['./bop-table.component.scss']
})
export class BopTableComponent {
  ErrorMessage = '';
  private ListOfBOP = new BehaviorSubject<any[]>([]);
  readonly BopList = this.ListOfBOP.asObservable();
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

  User:any;
  constructor(private BopService: AddBOPService, private loginService: LoginService) {
    console.log("fffffffffffffffffffff")
    this.User=this.loginService.currentUser.getValue();
    console.log( this.User)
   }

  ngOnInit() {
    this.getpages(1)
 
    this.User=this.loginService.currentUser.getValue();
    console.log("fffffffffffffffffffff")
    console.log( this.User)
    this.loginService.isAdmin.subscribe({
      next: data => {
        this.IsAdmin = data
        console.log("kkkookokokokokok")
        console.log(this.IsAdmin)
      }
    })
    this.loginService.isRadio.subscribe({
      next: data => {
        this.IsRadio = data
      }
    })
    this.loginService.isUser.subscribe({
      next: data => {
        this.IsUser = data
      }
    })

    this.BopService.GetBOPForExcel(this.User.ID,this.User.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    })
  }

  DeleteJMP(Bop: IBOP) {
    if (confirm("Are you sure you want to delete this Record?")) {
      // user clicked "Yes"
      // do something, such as call an API to delete the item
      this.BopService.DeleteBOP(Bop).subscribe({
        next: data => {
          console.log(data)
          this.getpages(this.indexofPages)
        },
        error: err => {
          console.log(err);
        }
      })
    } else {
      // user clicked "No"
      // do nothing
    }

  }
  getpages(num: number) {
    this.User=this.loginService.currentUser.getValue();
    this.BopService.GetBOPByPage(num,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.ListOfBOP.next(data.items)
        console.log(data.items);
        this.countOfPage = data.count;
        this.TempArray = new Array(this.countOfPage);
      },
      error: err => {
        console.log(err)

      }
    })
    this.indexofPages = num;
    console.log("getpages" + this.indexofPages);
    console.log("getpages vvvvvvvvvv list");

    console.log(this.ListOfBOP.getValue());

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

    let worksheet = workbook.addWorksheet('BOP Data');

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
    const columnNumberEnd = workbook.getWorksheet('BOP Data').lastColumn.number;;
    const cellEnd = worksheet.getCell(Number(rowNumber), Number(columnNumberEnd));
    const columnNameEnd = cellEnd.address.split(/(\$?[A-Z]+)/)[1]; // extracts the column name from the cell address
    const cellAddressEnd = columnNameEnd + rowNumber;
    const mergeCell = `${cellAddress}:${cellAddressEnd}`;
    worksheet.mergeCells(mergeCell);

    console.log('mergeCell');
    console.log(mergeCell);

    let fname = 'BOP Report';

    // add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], {
        type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
      });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
