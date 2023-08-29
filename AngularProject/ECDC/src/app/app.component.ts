import { Component, Renderer2 } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { AddnewJMPService } from 'Services/addnew-jmp.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { SignalrService } from 'Services/signalr.service';
import { ArrivalNotification } from 'SharedClasses/ArrivalNotification';
import { Notification } from 'SharedClasses/Notification';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],

})


export class AppComponent {
  title = 'ECDC';

  IsAdmin: boolean = false;

  IsLoging: boolean = false;

  private hubConnection!: signalR.HubConnection;

  constructor(
    private dataServise: DataService,
    private loginService: LoginService,
    private JMPService:AddnewJMPService,
    private renderer: Renderer2
    ) {

  }
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5000/NotificationHub', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addFormListner = () => {
    console.log("addFormmmmm")
    this.hubConnection.on('SendMessage', (notification: Notification) => {
      this.showNotification(notification);
      console.log("showNotificationnnnnnnnnn")
      console.log(notification)
      this.dataServise.GetPendingJMP(1).subscribe({
        next: data => {
          console.log("data.items.length")
          console.log(data.items.length)
          this.JMPService.PendingJMP.next(data.items.length)
          console.log(this.JMPService.PendingJMP.getValue())
        },
        error: err => {
          console.log(err)
        }
      })
    });
  }

  showNotification(notification: Notification) {
    console.log("showNotificationFunctioooooon")
    const myElement = document.querySelector('#notify') as HTMLElement;
    myElement.style.display = 'block';
    myElement.innerHTML = notification.message + " by " + '<strong>' + notification.user +
      '</strong>' + ' with id ' + notification.formId +
      '<br> <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>'
    myElement.style.visibility = 'visible';

    setTimeout(() => {
      this.renderer.setStyle(myElement, 'display', 'none');
    }, 5000);
  }

  //////////////////////////////////////////////////////////////

  public startConnection2 = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5000/ArrivalNotificationHub', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started ****** ArrivalNotificationHub'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addFormListner2 = () => {
    console.log("addFormmmmm****ArrivalNotificationHub")
    this.hubConnection.on('SendMessage2', (notification: ArrivalNotification) => {
      this.showNotification2(notification);
      console.log("showNotification*******ArrivalNotificationHub")
      console.log(notification)
    });
  }

  showNotification2(notification: ArrivalNotification) {
    console.log("showNotificationFunctioooooon")
    const myElement = document.querySelector('#notify2') as HTMLElement;
    myElement.style.display = 'block';
    myElement.innerHTML = notification.message + " with SN. " + '<strong>' + notification.serialNo +
      '</strong>' + ' to ' + notification.destination + ' at ' + notification.arrivalTime
    myElement.style.visibility = 'visible';


    setTimeout(() => {
      this.renderer.setStyle(myElement, 'display', 'none');
    }, 5000);
  }

  ///////////////////////////////////////////////////////////////////////

  ngOnInit(): void {
    this.loginService.isAdmin.subscribe({
      next: data => {
        this.IsAdmin = data
      }
    })

    this.loginService.isLogin.subscribe({
      next: (data: any) => {
        console.log("-------------------------------------+");
        console.log(data);
        this.IsLoging = data
      }
    })

    this.startConnection()
    this.addFormListner()
    this.startConnection2()
    this.addFormListner2()
  }

}
