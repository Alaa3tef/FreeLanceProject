import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {
  user:any;
  constructor(private loginService:LoginService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.loginService.currentUser.subscribe({
      next:(data:any)=>{
         this.user=(data);
         console.log("From loginServiceeeee "+this.user);
         console.log(this.user);

        }
    });


    let token=localStorage.getItem('UserToken');
    console.log(token);
    req=req.clone({headers:req.headers.set('Authorization','Bearer '+token)});

    return next.handle(req).pipe(catchError(err=>{return throwError(err.error.message);}));   
}
}
