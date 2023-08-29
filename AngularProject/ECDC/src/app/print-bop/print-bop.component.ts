import { Component } from '@angular/core';
import { AddBOPService } from 'Services/add-bop.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-bop',
  templateUrl: './print-bop.component.html',
  styleUrls: ['./print-bop.component.scss']
})
export class PrintBopComponent {
  BOPDateList: any[] = [];
  ErrorMessage: string = '';
  date!: Date;

  Data:boolean=false;
  BopArray!:any;
  User:any;

  constructor(private addBopService:AddBOPService,private loginService:LoginService) { }
  ngOnInit() {
   this.User= this.loginService.currentUser.getValue();
    this.addBopService.GetBOP(this.User.ID,this.User.Role).subscribe({
     next:data=>{   data.data.forEach((ele: any) => {
      this.BOPDateList.push(ele.date)
    });
    console.log(this.BOPDateList)
    // this.Accident = data.data;
    this.BOPDateList = Array.from(new Set(this.BOPDateList))}
    ,


      error: error => this.ErrorMessage = error

    })

  }



  DateSelected(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    console.log(this.date)
    this.addBopService.GetBOPByDate(event.target.value,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log("data.data")
        console.log(data.data)
        this.BopArray = data.data;
        console.log("BBOOOOOOOPPPP************************")
        console.log(this.BopArray)

        this.Data=true;
      },
      error: error => {
        this.ErrorMessage = error;
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
