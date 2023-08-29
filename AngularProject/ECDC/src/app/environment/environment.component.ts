import { Component } from '@angular/core';

@Component({
  selector: 'app-environment',
  templateUrl: './environment.component.html',
  styleUrls: ['./environment.component.scss']
})
export class EnvironmentComponent {
  Environmet:any[];
  constructor()
  {
    this.Environmet=['ECDC-QHSE-PR-44-Waste Management Plan Version A','ECDC-QHSE-PR-45-Handling And Storing Hazardous Material Procedure Version A',
  'ECDC-QHSE-PR-46-Oil Spill Control Procedure Version A','ECDC-QHSE-PR-47-Housekeeping and Personal Hygiene  work instruction Version A'] 
  }
  
  downloadFile(item:string) {
    const filePath = `/assets/managment system/Environment/${item}.docx`; // Replace 'your-file-name' with the actual file name and extension
    const link = document.createElement('a');
    link.href = filePath;
    link.download = `${item}.docx`; // Replace 'your-file-name' with the actual file name and extension
    link.click();
  }
}
