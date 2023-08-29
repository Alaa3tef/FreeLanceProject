import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { DeleteDataService } from 'Services/delete-data.service';
import { GetdataByPageService } from 'Services/getdata-by-page.service';
import { LoginService } from 'Services/login.service';
import { IRigMovePerformanceEvaluation } from 'SharedClasses/IRigMovePerformanceEvaluation';
import { BehaviorSubject } from 'rxjs';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
import { AddRigMovePerformanceEvaluationService } from 'Services/add-rig-move-performance-evaluation.service';


@Component({
  selector: 'app-rig-move-performance-evaluation',
  templateUrl: './rig-move-performance-evaluation.component.html',
  styleUrls: ['./rig-move-performance-evaluation.component.scss']
})
export class RigMovePerformanceEvaluationComponent {
  ErrorMessage = '';
  private ListOfRigPerformance = new BehaviorSubject<any[]>([]);
  readonly RigPerformanceList = this.ListOfRigPerformance.asObservable();
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
  json_data: any[] = [];


  constructor(private getDataByPage:GetdataByPageService,private dataService: DataService,
    private addRigPerformance: AddRigMovePerformanceEvaluationService,
    private deleteService: DeleteDataService,private loginService:LoginService) { }

  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.getpages(1)
    this.loginService.isAdmin.subscribe({
      next: data => {
        this.IsAdmin=data
      }
     })

     this.addRigPerformance.GetRigMovePerformanceEvaluationWithDataExcel(this.User.ID,this.User.Role).subscribe({
      next: (data) => {
        this.json_data = data.data
      },
      error: (err) => this.ErrorMessage = err
    });
  }

  DeleteRigPerformance(RigPerformance: IRigMovePerformanceEvaluation) {
    if (confirm("Are you sure you want to delete this Record?")) {
      // user clicked "Yes"
      // do something, such as call an API to delete the item
      this.deleteService.DeleteRigPerformance(RigPerformance).subscribe({
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
  getpages(num:number)
  {
    this.getDataByPage.GetRigMovePerformanceByPage(num,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.ListOfRigPerformance.next(data.items)
        this.countOfPage=data.count;
        this.TempArray= new Array(this.countOfPage);
      },
      error: err => {
        console.log(err)
      }
    })
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

    let worksheet = workbook.addWorksheet('RMPE Data');

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
        temp.push(x1[y]);
      }
      worksheet.addRow(temp);
    }

    let fname = 'RMPE Report';

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], {
        type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
      });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
