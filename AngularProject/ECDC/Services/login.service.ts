import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User_Login } from 'SharedClasses/User_Login';
import { BehaviorSubject, Observable } from 'rxjs';
import jwtDecode from 'jwt-decode';
import { IChangePaassword } from 'SharedClasses/IChangePaassword';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  currentUser = new BehaviorSubject(null);
  IsLogged: boolean = false;
  User:any;
  UserObj:any;
  sharedIsLogin= new BehaviorSubject(false);
  isAdmin= new BehaviorSubject(false);
  isRadio= new BehaviorSubject(false);
  isUser= new BehaviorSubject(false);
  isLogin= new BehaviorSubject(false);

  Url: string = "http://localhost:5000/api/Account/login";


  constructor (private http: HttpClient,private router:Router)
  {
    if (localStorage.getItem('UserToken') != null)
    {
      this.IsLogged = true
      // this.isLogin.next(true);
      this.saveCurrentUser()
    }
    else
    {
      this.IsLogged = false
      // this.isLogin.next(false)
    }
  }

  Login(user: User_Login): Observable<any>
  {
    return this.http.post<any>(this.Url, user);
  }

  saveCurrentUser()
  {
    let token: any = localStorage.getItem('UserToken');
    this.currentUser.next(jwtDecode(token));
    this.UserObj= this.currentUser.getValue();
    this.isLogin.next(true)
   if(this.UserObj.Role=="Admin")
   {
    this.isAdmin.next(true);
    this.sharedIsLogin.next(true);

   }
   else if (this.UserObj.Role=="Radio")
   {
       this.isRadio.next(true);

   }
   else if (this.UserObj.Role=="User")
   {
       this.isUser.next(true);
   }
   else
   {
    this.isAdmin.next(false);
   }



  }


  ChangePassword(ChangePaassword:IChangePaassword): Observable<IChangePaassword> {
    console.log("lofin serrvixceeee")

    this.User=this.currentUser.getValue();
    console.log(this.User.ID)
    return this.http.put<IChangePaassword>(`http://localhost:5000/api/Account/ChangePassword`,ChangePaassword);
  }

  SignOut() {
    this.currentUser.next(null);
    localStorage.removeItem('UserToken');
    this.router.navigate(['/Login'])
    console.log("SignOut Done")
    this.isAdmin.next(false);
    this.isUser.next(false);
    this.isRadio.next(false);
    this.sharedIsLogin.next(false);
    this.isLogin.next(false)


  }
}

