import { Component } from '@angular/core';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
  IsLoging:boolean=false;

  constructor(private loginService: LoginService) {

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.loginService.isLogin.subscribe({

      next: (data: any) => {

        console.log("-------------------------------------+");

        console.log(data);

        this.IsLoging=data
}

    })
  }
}
