import { Component } from '@angular/core';

@Component({
  selector: 'app-safety',
  templateUrl: './safety.component.html',
  styleUrls: ['./safety.component.scss']
})
export class SafetyComponent {
  health:any[];
  constructor()
  {
    this.health=['ECDC Specific QHSE Plan.xls','ECDC-QHSE-PR-08-Permit To Work Procedure.docx','ECDC-QHSE-PR-09-Confined Space Entry Procedure.docx',
  'ECDC-QHSE-PR-10-Lockout Tagout Procedure.docx','ECDC-QHSE-PR-11-Job Safety Analysis Procedure.docx','ECDC-QHSE-PR-12-Risk Notification Procedure.docx',
'ECDC-QHSE-PR-13-Land Transportation Procedure.docx','ECDC-QHSE-PR-14-Lifting Procedure.docx',
'ECDC-QHSE-PR-15-Working At Height Procedure.docx','ECDC-QHSE-PR-16-Working At Height Rescue Plan.docx',
'ECDC-QHSE-PR-17-Dropped Object Prevention Guidelines.docx','ECDC-QHSE-PR-18-Drops Standard.docx',
'ECDC-QHSE-PR-19-Fire Precautions work instruction.docx','ECDC-QHSE-PR-20-Control of Ignition Sources version A.docx',
'ECDC-QHSE-PR-21-Welding and Cutting Procedure Version A.docx','ECDC-QHSE-PR-22-H2S Safety Procedure Version A.docx',
'ECDC-QHSE-PR-23-H2S Contingency Plan Version A.docx','ECDC-QHSE-PR-24-SCBA Procedure Version A.docx',
'ECDC-QHSE-PR-25-Electrical Safety Procedure Version A.docx','ECDC-QHSE-PR-26-Blackout and Startup Procedure Version A.docx',
'ECDC-QHSE-PR-27-Mechanical Equipment Precautions  work instruction Version A.docx','ECDC-QHSE-PR-28-Safe use of Tools and Equipment Procedure Version A.docx',
'ECDC-QHSE-PR-29-Prohibited items Version A.docx','ECDC-QHSE-PR-30-Pipe Handling work instruction Version A.docx',
'ECDC-QHSE-PR-31-Manlift Safety  work instruction Version A(EN-CHN).docx','ECDC-QHSE-PR-32-Forklift Safety work instruction Version A(EN-CHN).docx',
'ECDC-QHSE-PR-33-Sandblasting and Grinders Version A.docx','ECDC-QHSE-PR-34-Abrasive Wheels and Grinders Version A.docx',
'ECDC-QHSE-PR-35-Pressure Testing Safety  work instruction Version A.docx','ECDC-QHSE-PR-36-Compressed Gas Cylinder Safety Procedure Version A.docx',
'ECDC-QHSE-PR-37-Nitrogen Filling Procedure Version A.docx','ECDC-QHSE-PR-38-Pressure Jetting  work instruction Version A.docx',
'ECDC-QHSE-PR-39-Safety Signages Procedure Version A.docx','ECDC-QHSE-PR-40-General Office Safety  work instruction Version A.docx',
'ECDC-QHSE-PR-41-Rig Emergency Response Procedure Version A.docx','ECDC-QHSE-PR-42-Emergency Response Plan Version A.docx',
'ECDC-QHSE-PR-43-Airconditioner Check Version A.xls'] 
  }
   isWordFile(fileName: string): boolean {
    const extension = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
    console.log(extension==='docx'||extension === 'doc')
    return extension === 'doc' || extension === 'docx';
  }
  
   isExcelFile(fileName: string): boolean {
    const extension = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
    return extension === 'xls' || extension === 'xlsx';
  }
   isExcelFileByMimeType(mimeType: string): boolean {
    return mimeType === 'application/vnd.ms-excel' || mimeType === 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';
  }
  downloadFile(item:string) {
    if(this.isWordFile(item)){
      const filePath = `/assets/managment system/Safety/${item}`; // Replace 'your-file-name' with the actual file name and extension
      const link = document.createElement('a');
      link.href = filePath;
      link.download = `${item}`; // Replace 'your-file-name' with the actual file name and extension
      link.click();
    }
    else if(this.isExcelFile(item)||this.isExcelFileByMimeType(item)){
      const filePath =`/assets/managment system/Safety/${item}`; // Replace 'your-file-name' with the actual file name and extension
      const link = document.createElement('a');
      link.href = filePath;
      link.download =`${item}`; // Replace 'your-file-name' with the actual file name and extension
      link.click();
    }
    
  }
}
