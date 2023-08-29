import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { User_Register } from 'SharedClasses/User_Register';

@Injectable({
  providedIn: 'root'
})
  export class RegisterService {

    _url:string="http://localhost:5000/api/Account/register";
    constructor(private http:HttpClient) { }

    Register(user:User_Register){
      return this.http.post(this._url,user);
    }
    GetRoles():Observable<any>
    {
      return this.http.get("http://localhost:5000/api/Account/getRoles").pipe(catchError((error)=>error.message));
    }

  }
