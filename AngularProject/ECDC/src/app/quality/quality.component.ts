import { Component } from '@angular/core';

@Component({
  selector: 'app-quality',
  templateUrl: './quality.component.html',
  styleUrls: ['./quality.component.scss']
})
export class QualityComponent {
  Quality:any[];
  constructor()
  {
    this.Quality=['ECDC-QHSE-FM-104 Corrective Action new','ECDC-QHSE-PR-48-Document Control Procedure Version A',
  'ECDC-QHSE-PR-49-Meeting Procedure Version A','ECDC-QHSE-PR-50-POB Procedure Version A',
  'ECDC-QHSE-PR-51-Safety Training Observation Programme Version A(EN-CHN)',
'ECDC-QHSE-PR-52-Safety Induction Procedure Version A','ECDC-QHSE-PR-53-Short Service Employee  Program Version A',
'ECDC-QHSE-PR-54-Alerts And General HSE Promotion version A(EN-CHN)','ECDC-QHSE-PR-55-Inspection Auditng And Reporting Version A',
'ECDC-QHSE-PR-56-Leadership Site Visit Procedure Version A','ECDC-QHSE-PR-57-Preventive And Corrective Action Procedure Version A',
'ECDC-QHSE-PR-58-HSE Verification Program- Version A','ECDC-QHSE-PR-59-Subcontractor HSE  Management version A(EN-CHN)',
'ECDC-QHSE-PR-60-Incident Management Procedure Version A(EN-CHN)','ECDC-QHSE-PR-61-Management Of Change Procedure Version A(EN-CHN)',
'ECDC-QHSE-PR-76-stakeholder-engagement-procedure-2021-en - ECDC'] 
  }
  
  downloadFile(item:string) {
    const filePath = `/assets/managment system/Quality/${item}.docx`; // Replace 'your-file-name' with the actual file name and extension
    const link = document.createElement('a');
    link.href = filePath;
    link.download = `${item}.docx`; // Replace 'your-file-name' with the actual file name and extension
    link.click();
  }
}
