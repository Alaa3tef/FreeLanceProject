import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  private hubConnection!: signalR.HubConnection;

  constructor() {

  }
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5000/TestHub', {
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
    this.hubConnection.on('Test',(data) => {
      console.log("done")
      this.hubConnection.invoke('Test')
      console.log(data)
    });
  }
}
