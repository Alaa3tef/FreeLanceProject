import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from 'Services/login.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {
  User: any = this._LoginService.currentUser.getValue();
  constructor(private _LoginService: LoginService, private router: Router) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if ((this.User != null) && (this.User.Role == "Admin")) {
      console.log("auth gaaaaaaarddddddddd")
      console.log(this.User.Role)
      console.log(this.User.Role == "Admin")

      return true;
    }
    else {
      console.log("this.User")
      console.log(this.User)
      this.router.navigate(['/Login'])
      return false;
    }
  }

}
