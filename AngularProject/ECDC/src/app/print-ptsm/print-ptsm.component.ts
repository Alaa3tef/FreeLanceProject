import { Component } from '@angular/core';
import { LoginService } from 'Services/login.service';
import { PTSMService } from 'Services/ptsm.service';
import { Time } from '@angular/common';

@Component({
  selector: 'app-print-ptsm',
  templateUrl: './print-ptsm.component.html',
  styleUrls: ['./print-ptsm.component.scss']
})
export class PrintPTSMComponent {
  PTSMList: any[] = [];
  PTSMTimeList: any[] = [];
  ErrorMessage: string = '';
  date!: Date;
  Time!: Time;

  PTSMObject:any[]=[];

  Data:boolean=false;
  PTSM!:any;
  User:any;

  constructor(private PTSMService:PTSMService,private loginService:LoginService) { }
  ngOnInit() {
   this.User= this.loginService.currentUser.getValue();
    this.PTSMService.GetPTSM(this.User.ID,this.User.Role).subscribe({
     next:data=> {
      data.data.forEach((ele: any) => {
        this.PTSMList.push(ele.date)
      });
      console.log(this.PTSMList)
      // this.Accident = data.data;
      this.PTSMList = Array.from(new Set(this.PTSMList))
      this.PTSMTimeList=data.data

    },
      error: error => this.ErrorMessage = error
    })

  }



  DateSelected(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    console.log(this.date)
    this.date=event.target.value;
    this.PTSMObject=this.PTSMTimeList.filter(element => element.date==event.target.value );
    this.Data=true;
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

      // Get the styles of the entire HTML page
      const pageStyles = window.getComputedStyle(document.body);

      // Append the styles to the head element of the iframe
      const style = document.createElement('style');
      style.textContent = pageStyles.cssText;
      idoc.head.appendChild(style);

      // Add CSS rule to define a page break before each element in the print media
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
