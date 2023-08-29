import { Component } from '@angular/core';
import { TestService } from 'Services/test.service';
import * as signalR from '@aspnet/signalr';


@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss']
})
export class ContactUsComponent {
  Hub = new signalR.HubConnectionBuilder().withUrl("http://localhost:5082/TestHub",{
    skipNegotiation: true,
    transport: signalR.HttpTransportType.WebSockets
  }).build();
  // constructor(private signalR:TestService){
  //   this.signalR.startConnection();
  // }

  // sendData(){
  //   this.signalR.addFormListner();
  //   // alert("Data invoked")
  // }

  constructor(){
  }

  public startConnection = ()=>{
    this.Hub.start().
    then(function(){
        console.log("Connect Success");
    });
  }

  public addRecord(){
    this.Hub.invoke("Test");
  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.startConnection();
    this.Hub.on("NewCommentNotify", function(name){
      console.log(name)
      alert(name)
    })
    // this.Hub.invoke("Test");

  }

}
