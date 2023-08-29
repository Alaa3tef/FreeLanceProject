import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { DeleteDataService } from 'Services/delete-data.service';
import { IStopCardRegister } from 'SharedClasses/IStopCardRegister';
import { BehaviorSubject } from 'rxjs';
import { stopcardservice } from 'Services/stop-card.service';
import { GetdataByPageService } from 'Services/getdata-by-page.service';
import { LoginService } from 'Services/login.service';
import * as saveAs from 'file-saver';
import { Workbook } from 'exceljs';

@Component({
  selector: 'app-stopcard-table',
  templateUrl: './stopcard-table.component.html',
  styleUrls: ['./stopcard-table.component.scss']
})
export class StopcardTableComponent {
  json_data: any[] = [];

  ErrorMessage = '';
  SearchList:string[]=['Open','Closed'];
  private ListOfstopCard = new BehaviorSubject<any[]>([]);
  readonly stopCardList = this.ListOfstopCard.asObservable();
  page:number=1;
  count:number=0;
  productSize:number=5;
  indexofPages: number=1;
  countOfPage:number=0;
  TempArray:any[]=[];
  IsUser:boolean=false;
  IsRadio:boolean=false;
  IsAdmin:boolean=false;

  User:any;

  constructor(private StopCardService: stopcardservice,private getByPage:GetdataByPageService,private dataService: DataService, private deleteService: DeleteDataService,private stopCardService:stopcardservice,private loginService:LoginService) { }

  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.dataService.GetClassification().subscribe({
      next: data => {

        data.data.forEach((element: { name: string; }) => {

          this.SearchList.push(element.name)
        });
        console.log(this.SearchList)
      }

    })
    ,
    this.getpages(1);
    this.loginService.isAdmin.subscribe({
      next: data => {
        this.IsAdmin=data
      }
     })
     this.loginService.isUser.subscribe({
      next: data => {
        this.IsUser=data
      }
     })

     this.StopCardService.GetStopCard(this.User.ID,this.User.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    })
  }



  selectedMenace( event:any)
  {
    console.log(event.target.value)
    this.stopCardService.GetDataByClassification(event.target.value,this.User.ID,this.User.Role).subscribe({
      next:data=> this.ListOfstopCard.next(data.data),
      error: err => {
        this.getpages(1)
        console.log(err);
      }
    })

  }


  DeleteStopCard(StopCardRegister: IStopCardRegister) {
    if (confirm("Are you sure you want to delete this Record?")) {
      // user clicked "Yes"
      // do something, such as call an API to delete the item
      this.deleteService.DeleteStopCard(StopCardRegister).subscribe({
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


  getpages(num:number)
  {
    this.getByPage.GetStopCardByPage(num,this.User.ID,this.User.Role).subscribe({
      next: (data)=>{
        this.ListOfstopCard.next(data.items) ;
        this.countOfPage=data.count;
        this.TempArray= new Array(this.countOfPage);
        console.log(data)
      }
      ,
      error: (error)=>{console.log(error); }

    });
    this.indexofPages=num;
    console.log("getpages"+this.indexofPages);
  }
  gotleft()
  {
    (this.indexofPages>1)?this.indexofPages-=1:this.indexofPages=1;
    this.getpages(this.indexofPages);
    console.log("gotleft"+this.indexofPages);
  }
  gotoright()
  {

    (this.indexofPages<this.countOfPage)?this.indexofPages+=1:this.indexofPages=this.countOfPage;
    this.getpages(this.indexofPages);
    console.log("gotoright"+this.indexofPages);
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Stop Card Data");

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

    let fname = "Stop Card Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }

}


