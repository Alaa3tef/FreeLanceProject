import { Component } from '@angular/core';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: ['./policy.component.scss']
})
export class PolicyComponent {
  policy:any[];
  constructor()
  {
    this.policy=['1- QHSE IMS Policy.pdf','2- Confined Space Entry Policy.pdf',
  '5- Energy Isolation Policy.pdf','6- Environmental Policy.pdf','7- Facial and Hair Policy.pdf',
'8- Ground Disturbance Policy.pdf','9- Health and Safety Policy.pdf','11- MOC policy.pdf',
'12- Smoking Policy.pdf','13- Permit to Work Policy.pdf','15- Working At Height Policy.pdf',
'16- Code of Ethical Conduct.pdf','17- Alcohol and Drugs Policy.pdf'] 
  }

 
  
  isPDFFile(fileName: string): boolean {
    const extension = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
    console.log(extension==='pdf')
    return extension === 'pdf' ;
  }

 
 
  downloadFile(item:string) {
    if(this.isPDFFile(item)){
      const filePath = `/assets/managment system/Policies/Policies/${item}`; // Replace 'your-file-name' with the actual file name and extension
      const link = document.createElement('a');
      link.href = filePath;
      link.download = `${item}`; // Replace 'your-file-name' with the actual file name and extension
      link.click();
    }
   
   
  }
}
