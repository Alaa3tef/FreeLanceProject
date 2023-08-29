import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { DataService } from './data.service';
import { Notification } from 'SharedClasses/Notification';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  private hubConnection!: signalR.HubConnection;

  constructor(private dataServise:DataService) {

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
    this.hubConnection.on('SendMessage',(notification: Notification) => {
      this.showNotification(notification);
      console.log("showNotificationnnnnnnnnn")

      // this.dataServise.GetJMPs();
    });
  }

  showNotification(notification: Notification) {
    console.log("showNotificationFunctioooooon")
    alert(notification.formId + notification.message + notification.user)
  }

}
