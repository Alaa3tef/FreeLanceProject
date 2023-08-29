import { Component } from '@angular/core';
import { LoginService } from 'Services/login.service';
import { stopcardservice } from 'Services/stop-card.service';
import { IStopCardRegister } from 'SharedClasses/IStopCardRegister';

@Component({
  selector: 'app-stop-card-report',
  templateUrl: './stop-card-report.component.html',
  styleUrls: ['./stop-card-report.component.scss']
})
export class StopCardReportComponent {
  StopCards: any[] = [];
  ErrorMessage: string = '';
  date!: Date;
  StopCardsList: any[] = [];
  Data: boolean = false;

  User: any;

  constructor(private loginService: LoginService, private stopCardService: stopcardservice) { }
  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.stopCardService.GetStopCard(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          this.StopCards.push(ele.date)
        });
        console.log(this.StopCards)
        // this.Accident = data.data;
        this.StopCards = Array.from(new Set(this.StopCards))
      },
      error: error => this.ErrorMessage = error

    })
  }



  DateSelected(event: any) {
    this.stopCardService.GetStopCardByDate(this.date, this.User.ID, this.User.Role).subscribe({


      next: data => {
        this.StopCardsList = data.data;
        this.Data = true;
      },
      error: error => {
        this.ErrorMessage = error;
      }

    })
  }

  print(): void {
    // let element: any = document.getElementById("print-section");
    // const iframe = document.body.appendChild(document.createElement("iframe"));

    // iframe.style.display = "none";

    // const idoc = iframe.contentDocument;
    // if (idoc != null) {
    //   idoc.head.innerHTML = document.head.innerHTML;
    //   idoc.body.innerHTML = element.innerHTML;

    //   window.setTimeout(() => {
    //     iframe.contentWindow?.print();
    //     document.body.removeChild(iframe);
    //   }, 1000);
    // }

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

    //   const elements = Array.from(document.getElementsByClassName("print-section"));

    // const iframe = document.body.appendChild(document.createElement("iframe"));
    // iframe.style.display = "none";
    // const idoc = iframe.contentDocument;

    // if (idoc != null) {
    //   idoc.head.innerHTML = document.head.innerHTML;
    //   elements.forEach(element => {
    //     idoc.body.appendChild(element.cloneNode(true));
    //   });

    //   // Get the styles of the entire HTML page
    //   const pageStyles = window.getComputedStyle(document.body);

    //   // Append the styles to the head element of the iframe
    //   const style = document.createElement('style');
    //   style.textContent = pageStyles.cssText;
    //   idoc.head.appendChild(style);

    //   // Add CSS rule to define a page break before each element in the print media
    //   const breakRule = `@media print {
    //     .print-section {
    //       page-break-before: always;
    //     }
    //   }`;

    //   style.textContent += breakRule;

    //   // Add CSS rule to change the text of the footer when the page is printed
    //   const footerRule = `@media print {
    //     .print-footer {
    //       text-align: center;
    //       font-size: 20px;
    //       background-color:red;
    //       color: white;
    //     }
    //   }`;

    //   style.textContent += footerRule;

    //   // Add CSS rule to add the current date and time to the footer when the page is printed
    //   const dateRule = `@media print {
    //     .footer::after {
    //       content: "Printed on: " + new Date().toLocaleString();
    //     }
    //   }`;

    //   style.textContent += dateRule;

    //   window.setTimeout(() => {
    //     iframe.contentWindow?.print();
    //     document.body.removeChild(iframe);
    //   }, 1000);
    // }


  }

}

