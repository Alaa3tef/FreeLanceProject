import { Component } from '@angular/core';
import { AddRigMovePerformanceEvaluationService } from 'Services/add-rig-move-performance-evaluation.service';
import { LoginService } from 'Services/login.service';
import { IRigMovePerformanceEvaluation } from 'SharedClasses/IRigMovePerformanceEvaluation';

@Component({
  selector: 'app-print-rig-performance',
  templateUrl: './print-rig-performance.component.html',
  styleUrls: ['./print-rig-performance.component.scss']
})
export class PrintRigPerformanceComponent {

  RigMovePerformances: any[] = [];
  ErrorMessage: string = '';
  date!: Date;

  Data:boolean=false;
  RigPerformance!:any;
  User:any;

  constructor(private addRigPerformance:AddRigMovePerformanceEvaluationService,private loginService:LoginService) { }
  ngOnInit() {
   this.User= this.loginService.currentUser.getValue();
    this.addRigPerformance.GetRigMovePerformanceEvaluation(this.User.ID,this.User.Role).subscribe({
     next:data=> this.RigMovePerformances=data.data
    ,


      error: error => this.ErrorMessage = error

    })

  }



  DateSelected(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    console.log(this.date)
    this.addRigPerformance.GetAllRigPerformanceWithDataByDate(this.date,this.User.ID,this.User.Role).subscribe({


      next: data => {
        this.RigPerformance = data.data;

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
