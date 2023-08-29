import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { LoginService } from 'Services/login.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserauthGuard implements CanActivate {
  User: any = this._LoginService.currentUser.getValue();
  constructor(private _LoginService: LoginService, private router: Router) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if ((this.User != null) && ((this.User.Role == "User") || (this.User.Role == "Admin"))) {
      console.log("auth gaaaaaaarddddddddd")
      console.log(this.User.Role)
      //console.log(this.User.Role=="User")

      return true;
    }
    else {
      this.router.navigate(['/Login'])
      return false;
    }
  }

}
