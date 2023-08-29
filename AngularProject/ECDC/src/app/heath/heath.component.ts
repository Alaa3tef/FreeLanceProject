import { Component } from '@angular/core';
@Component({
  selector: 'app-heath',
  templateUrl: './heath.component.html',
  styleUrls: ['./heath.component.scss']
})
export class HeathComponent {
  health:any[];
  constructor()
  {
    this.health=['1.ECDC-QHSE-PR-01-Health Management Plan','2.ECDC-QHSE-PR-02-Food Hygiene Management work instruction'
   ,'3.ECDC-QHSE-PR-03-Heat Management Plan','4.ECDC-QHSE-PR-04-Manual Handling','5.ECDC-QHSE-PR-05-PPE Procedure',
 '6.ECDC-QHSE-PR-06-Hazardous Areas work instruction','7.ECDC-QHSE-PR-07-First Aid work instruction'] 
  }
  
  downloadFile(item:string) {
    const filePath = `/assets/managment system/Health/${item}.docx`; // Replace 'your-file-name' with the actual file name and extension
    const link = document.createElement('a');
    link.href = filePath;
    link.download = `${item}.docx`; // Replace 'your-file-name' with the actual file name and extension
    link.click();
  }
  
}
