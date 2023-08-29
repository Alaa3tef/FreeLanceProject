import { Component } from '@angular/core';

@Component({
  selector: 'app-qsheforms',
  templateUrl: './qsheforms.component.html',
  styleUrls: ['./qsheforms.component.scss']
})
export class QSHEFormsComponent {
  qshe:any[];
  constructor()
  {
    this.qshe=['ECDC-QHSE-FM-99- TBT.pdf','ECDC-QHSE-FM-98-Third Part Inspection Checklist.docx',
  'ECDC-QHSE-FM-97-Man Riding Winch Checklist.doc','ECDC-QHSE-FM-96-Shift Handover.doc',
'ECDC-QHSE-FM-82-Accident-Incident Report.docx','ECDC-QHSE-FM-77-Corrective_Action_Register Version V.3.1.xlsx',
'ECDC-QHSE-FM-76-Leadership Site Visit Register Version A.xls','ECDC-QHSE-FM-71-Safety Alert Report.pptx',
'ECDC-QHSE-FM-70-Visitor Induction Confirmation.doc','ECDC-QHSE-FM-64- Daily BOP Report.xlsx',
'ECDC-QHSE-FM-60-PTSM.docx','ECDC-QHSE-FM-54 -Daily Report - ECDC Rig ##.xlsx',
'ECDC-QHSE-FM-45-HSE Emergency Drill.docx','ECDC-QHSE-FM-42-Fortlift Weekly Check Version A.xls',
'ECDC-QHSE-FM-21-Crane Weekly Check Version A.xls',
'ECDC-QHSE-FM-17-Lifting Operation Plan.xlsx','ECDC-QHSE-FM-12-Rig ### STOP Card Register.xlsx',
'ECDC-QHSE-FM-09-Risk Assessment FORM.docx','ECDC-QHSE-FM-08-PTW_Register Version A.xlsx',
'ECDC-QHSE-FM-07-Confined Space Entry Certificate Version A.doc',
'ECDC-QHSE-FM-06-Isolation Certificate.doc','ECDC-QHSE-FM-04-First Aid Report.docx',
'40.ECDC-QHSE-FM-113-Sign IN.docx'] 
  }

   isWordFile(fileName: string): boolean {
    const extension = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
    console.log(extension==='docx'||extension === 'doc')
    return extension === 'doc' || extension === 'docx';
  }
  
  isPDFFile(fileName: string): boolean {
    const extension = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
    console.log(extension==='pdf'||extension === 'pdf')
    return extension === 'pdf' || extension === 'pdf';
  }

  isPPTXFile(fileName: string): boolean {
    const extension = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
    console.log(extension==='pptx')
    return extension === 'pptx' ;
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
      const filePath = `/assets/managment system/Forms/Medical Forms/QSHE/${item}`; // Replace 'your-file-name' with the actual file name and extension
      const link = document.createElement('a');
      link.href = filePath;
      link.download = `${item}`; // Replace 'your-file-name' with the actual file name and extension
      link.click();
    }
    else if(this.isExcelFile(item)||this.isExcelFileByMimeType(item)){
      const filePath =`/assets/managment system/Forms/Medical Forms/QSHE/${item}`; // Replace 'your-file-name' with the actual file name and extension
      const link = document.createElement('a');
      link.href = filePath;
      link.download =`${item}`; // Replace 'your-file-name' with the actual file name and extension
      link.click();
    }
    else if(this.isPDFFile(item)||this.isExcelFileByMimeType(item)){
      const filePath =`/assets/managment system/Forms/Medical Forms/QSHE/${item}`; // Replace 'your-file-name' with the actual file name and extension
      const link = document.createElement('a');
      link.href = filePath;
      link.download =`${item}`; // Replace 'your-file-name' with the actual file name and extension
      link.click();
    }
    else if(this.isPPTXFile(item)||this.isExcelFileByMimeType(item)){
      const filePath =`/assets/managment system/Forms/Medical Forms/QSHE/${item}`; // Replace 'your-file-name' with the actual file name and extension
      const link = document.createElement('a');
      link.href = filePath;
      link.download =`${item}`; // Replace 'your-file-name' with the actual file name and extension
      link.click();
    }
  }
}
