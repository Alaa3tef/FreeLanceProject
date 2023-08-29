import { AddNewAccidentService } from './../../../Services/add-new-accident.service';
import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-report-accident',
  templateUrl: './report-accident.component.html',
  styleUrls: ['./report-accident.component.scss']
})
export class ReportAccidentComponent {

  Accident: any[] = [];
  ErrorMessage: string = '';
  Classification!: string;
  AccidentRecord: any[] = [];
  Data: boolean = false;
  User:any;
  date!: Date;


  constructor(private loginService:LoginService,private AccidentService: AddNewAccidentService, private dataService: DataService) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.dataService.GetAccidents(this.User.ID,this.User.Role).subscribe({
      next: data => {


        data.data.forEach((ele: any) => {
          this.Accident.push(ele.dateOfEvent)
        });
        console.log(this.Accident)
        // this.Accident = data.data;
        this.Accident = Array.from(new Set(this.Accident))
        // this.Accident = data.data
        // console.log(this.Accident)
      },
      error: error => this.ErrorMessage = error
    })
  }

  ClassificationSelected(event: any) {
    console.log()
    this.AccidentService.GetAccidentByClassi(event.target.value,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.AccidentRecord = data.data;
        this.Data = true;
        console.log("done");
      },
      error: error => {
        this.ErrorMessage = error;
        console.log("Error");
      }
    })
  }

  print(): void {
    const elements = Array.from(document.getElementsByClassName("print-section"));

    const iframe = document.body.appendChild(document.createElement("iframe"));
    iframe.style.display = "none";
    const idoc = iframe.contentDocument;

    if (idoc != null) {
      idoc.head.innerHTML = document.head.innerHTML;
      elements.forEach(element => {
        idoc.body.appendChild(element.cloneNode(true));
      });

      const pageStyles = window.getComputedStyle(document.body);

      const style = document.createElement('style');
      style.textContent = pageStyles.cssText;
      idoc.head.appendChild(style);

      const breakRule = `@media print {
    .print-section {
      page-break-before: always;
    }
  }`;

      style.textContent += breakRule;

      window.setTimeout(() => {
        iframe.contentWindow?.print();
        document.body.removeChild(iframe);
      }, 1000);
    }
  }

}
