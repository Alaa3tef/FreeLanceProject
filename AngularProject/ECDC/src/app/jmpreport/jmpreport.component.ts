import { Component } from '@angular/core';
import { AddnewJMPService } from 'Services/addnew-jmp.service';

@Component({
  selector: 'app-jmpreport',
  templateUrl: './jmpreport.component.html',
  styleUrls: ['./jmpreport.component.scss']
})
export class JMPReportComponent {
  JMP: any[] = [];
  ErrorMessage: string = '';
  SerialNo!: number;
  JMPRecord: any;
  Approve: boolean = false;
  instructions: boolean = false;
  constructor(private jmpService: AddnewJMPService) { }
  ngOnInit() {

    this.jmpService.GetJMPs().subscribe({
      next: data => {
        this.JMP = data.data
      },
      error: error => this.ErrorMessage = error

    })
  }

  SNSelected(event: any) {
    console.log(this.SerialNo)
    console.log('**************************************************')
    this.jmpService.GetJMPBySN(this.SerialNo).subscribe({
      next: data => {
        this.JMPRecord = data.data;
        // if (this.JMPRecord != null) { this.instructions = true }
        // this.JMPRecord.forEach((obj) => {
        //   if (obj.qhseManagerMustApprove) {
        //     this.Approve = true
        //   } else {
        //     this.Approve = false
        //   }
        // });
        console.log("done");
        console.log(this.JMPRecord);
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
